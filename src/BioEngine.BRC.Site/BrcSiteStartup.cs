using System.Globalization;
using BioEngine.BRC.Common;
using BioEngine.BRC.Common.Ads.Site;
using BioEngine.BRC.Common.IPB.Controllers;
using BioEngine.BRC.Common.Web.Site;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BioEngine.BRC.Site
{
    public abstract class BrcSiteStartup : BRCSiteStartup
    {
        protected BrcSiteStartup(IConfiguration configuration, IHostEnvironment environment) : base(configuration,
            environment)
        {
        }

        protected override IMvcBuilder ConfigureMvc(IMvcBuilder mvcBuilder)
        {
            base.ConfigureMvc(mvcBuilder)
                .AddApplicationPart(typeof(UserController).Assembly)
                .AddApplicationPart(typeof(BrcSiteModule).Assembly)
                .AddApplicationPart(typeof(AdsSiteController).Assembly);

            if (Environment.IsDevelopment())
            {
                mvcBuilder.AddRazorRuntimeCompilation();
            }

            return mvcBuilder;
        }

        protected override void ConfigureAfterRoutingMiddleware(IApplicationBuilder app)
        {
            base.ConfigureAfterRoutingMiddleware(app);
            app.UseAuthentication();
            app.UseAuthorization();
        }

        protected override void ConfigureBeforeRoutingMiddleware(IApplicationBuilder app)
        {
            base.ConfigureBeforeRoutingMiddleware(app);
            var supportedCultures = new[] {new CultureInfo("ru-RU"), new CultureInfo("ru")};

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ru-RU"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
        }

        protected override void ConfigureEndpoints(IApplicationBuilder app, IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.AddBrcRoutes();
            base.ConfigureEndpoints(app, endpointRouteBuilder);
        }
    }
}
