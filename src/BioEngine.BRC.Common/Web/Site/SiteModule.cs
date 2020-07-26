using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Repository;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sitko.Core.App;

namespace BioEngine.BRC.Common.Web.Site
{
    public class SiteModule : WebModule<SiteModuleConfig>
    {
        public SiteModule(SiteModuleConfig config, Application application) : base(config, application)
        {
        }

        public override void CheckConfig()
        {
            base.CheckConfig();
            if (Config.SiteId == null)
            {
                throw new ArgumentException("Site id can't be null");
            }
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            services.AddSingleton(Config);
            services.AddHttpContextAccessor();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }
    }

    [UsedImplicitly]
    public class CurrentSiteMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SiteModuleConfig _options;
        private readonly ILogger<CurrentSiteMiddleware> _logger;
        private Entities.Site? _site;

        public CurrentSiteMiddleware(RequestDelegate next, SiteModuleConfig options,
            ILogger<CurrentSiteMiddleware> logger)
        {
            _next = next;
            _options = options;
            _logger = logger;
        }

        [UsedImplicitly]
        [SuppressMessage("ReSharper", "VSTHRD200")]
        public async Task Invoke(HttpContext context)
        {
            if (_site == null)
            {
                try
                {
                    var repository = context.RequestServices.GetRequiredService<SitesRepository>();
                    _site = await repository.GetByIdAsync(_options.SiteId!.Value);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in site middleware: {errorText}", ex.ToString());
                }

                if (_site == null)
                {
                    throw new Exception("Site is not configured");
                }
            }


            context.Features.Set(new CurrentSiteFeature(_site));
            await _next.Invoke(context);
        }
    }

    public class SiteModuleConfig : WebModuleConfig
    {
        public Guid? SiteId { get; set; }
    }
}
