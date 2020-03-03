using System.Globalization;
using BioEngine.BRC.Common;
using BioEngine.Core.Logging.Controllers;
using BioEngine.Core.Site;
using BioEngine.Extra.Ads.Site;
using BioEngine.Extra.IPB.Controllers;
using Elastic.Apm.NetCoreAll;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BioEngine.BRC.Site
{
    public abstract class BrcSiteStartup : BioEngineSiteStartup
    {
        protected BrcSiteStartup(IConfiguration configuration, IHostEnvironment environment) : base(configuration,
            environment)
        {
        }

        protected override IMvcBuilder ConfigureMvc(IMvcBuilder mvcBuilder)
        {
            base.ConfigureMvc(mvcBuilder).AddApplicationPart(typeof(LogsController).Assembly)
                .AddApplicationPart(typeof(UserController).Assembly)
                .AddApplicationPart(typeof(BrcSiteModule).Assembly)
                .AddApplicationPart(typeof(AdsSiteController).Assembly);

            if (Environment.IsDevelopment())
            {
                mvcBuilder.AddRazorRuntimeCompilation();
            }

            return mvcBuilder;
        }

        protected override void ConfigureAfterRouting(IApplicationBuilder app, IHostEnvironment env)
        {
            base.ConfigureAfterRouting(app, env);
            app.UseAuthentication();
            app.UseAuthorization();
        }

        protected override void ConfigureBeforeRouting(IApplicationBuilder app, IHostEnvironment env)
        {
            base.ConfigureBeforeRouting(app, env);
            var supportedCultures = new[] {new CultureInfo("ru-RU"), new CultureInfo("ru")};

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ru-RU"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
        }

        protected override void ConfigureEndpoints(IApplicationBuilder app, IHostEnvironment env,
            IEndpointRouteBuilder endpoints)
        {
            endpoints.AddBrcRoutes();
            base.ConfigureEndpoints(app, env, endpoints);
        }

        protected override void ConfigureStart(IApplicationBuilder appBuilder)
        {
            base.ConfigureStart(appBuilder);
            if (Environment.IsProduction())
            {
                appBuilder.UseAllElasticApm(Configuration);
            }
        }
    }
}
