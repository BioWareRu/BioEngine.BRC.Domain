using BioEngine.BRC.Common.Web.RenderService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BioEngine.BRC.Common.Web.Api
{
    public abstract class BRCApiStartup : BRCStartup
    {
        protected BRCApiStartup(IConfiguration configuration, IHostEnvironment environment) : base(
            configuration, environment)
        {
        }

        protected override IMvcBuilder ConfigureMvc(IMvcBuilder mvcBuilder)
        {
            return base.ConfigureMvc(mvcBuilder)
                .AddNewtonsoftJson()
                .AddApplicationPart(typeof(ResponseRestController<,,,>).Assembly);
        }

        protected override void ConfigureAppServices(IServiceCollection services)
        {
            base.ConfigureAppServices(services);
            services.AddScoped<IViewRenderService, ViewRenderService>();
        }

        protected override void ConfigureAfterRoutingMiddleware(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
