using System.Globalization;
using BioEngine.BRC.Domain;
using BioEngine.Core.Logging.Controllers;
using BioEngine.Posts.Routing;
using BioEngine.Core.Site;
using BioEngine.Extra.Ads.Site;
using BioEngine.Extra.IPB.Controllers;
using BioEngine.Pages.Routing;
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
        private readonly IHostEnvironment _environment;

        protected BrcSiteStartup(IConfiguration configuration, IHostEnvironment environment) : base(configuration)
        {
            _environment = environment;
        }

        protected override IMvcBuilder ConfigureMvc(IMvcBuilder mvcBuilder)
        {
            base.ConfigureMvc(mvcBuilder).AddApplicationPart(typeof(LogsController).Assembly)
                .AddApplicationPart(typeof(UserController).Assembly)
                .AddApplicationPart(typeof(BrcSiteModule).Assembly)
                .AddApplicationPart(typeof(AdsSiteController).Assembly);
            if (_environment.IsDevelopment())
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

        public override void RegisterEndpoints(IEndpointRouteBuilder endpoints)
        {
            base.RegisterEndpoints(endpoints);
            endpoints.MapControllerRoute(BioEnginePostsRoutes.Post, "/posts/{url:string}.html");
            endpoints.MapControllerRoute(BioEnginePagesRoutes.Page, "/pages/{url:string}.html");
            endpoints.MapControllerRoute(BrcDomainRoutes.GamePublic, "/games/{gameUrl:string}/about.html");
            endpoints.MapControllerRoute(BrcDomainRoutes.GamePosts, "/games/{gameUrl:string}/posts.html");
            endpoints.MapControllerRoute(BrcDomainRoutes.DeveloperPublic, "/developers/{gameUrl:string}/about.html");
            endpoints.MapControllerRoute(BrcDomainRoutes.DeveloperPosts, "/developers/{gameUrl:string}/posts.html");
            endpoints.MapControllerRoute(BrcDomainRoutes.TopicPublic, "/topics/{gameUrl:string}/about.html");
            endpoints.MapControllerRoute(BrcDomainRoutes.TopicPosts, "/topics/{gameUrl:string}/posts.html");
            endpoints.MapControllerRoute(BioEnginePostsRoutes.PostsByTags, "posts/tags/{tagNames}.html");
            endpoints.MapControllerRoute(BioEnginePostsRoutes.PostsByTagsPage, "posts/tags/{tagNames}/page/page.html");
            endpoints.MapControllerRoute(BioEnginePostsRoutes.PostsPage, "page/page.html");
        }
    }
}
