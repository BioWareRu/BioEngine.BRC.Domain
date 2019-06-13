using BioEngine.BRC.Domain;
using BioEngine.Core.Routing;
using BioEngine.Pages.Routing;
using BioEngine.Posts.Routing;
using Microsoft.AspNetCore.Routing;

namespace BioEngine.BRC.Common
{
    public static class BrcRoutes
    {
        public static IEndpointRouteBuilder AddBrcRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints
                .MapRoute("root", "/", "Posts", "List")
                .MapRoute("rss", "/rss.xml", "Posts", "Rss")
                .MapRoute(BioEnginePostsRoutes.Post, "/posts/{url}.html", "Posts", "Show")
                .MapRoute(BioEnginePostsRoutes.PostsPage, "page/page.html", "Posts", "ListPage")
                .MapRoute(BioEnginePostsRoutes.PostsByTags, "posts/tags/{tagNames}.html", "Posts", "ListByTag")
                .MapRoute(BioEnginePostsRoutes.PostsByTagsPage, "posts/tags/{tagNames}/page/page.html", "Posts",
                    "ListByTagPage")
                .MapRoute(BrcDomainRoutes.DeveloperPublic, "/developers/{url}/about.html", "Developers", "Show")
                .MapRoute(BrcDomainRoutes.DeveloperPosts, "/developers/{url}/posts.html", "Developers", "Posts")
                .MapRoute(BrcDomainRoutes.GamePostsPage, "/developers/{url}/posts/page/{page:int}.html", "Developers",
                    "PostsPage")
                .MapRoute(BrcDomainRoutes.GamePublic, "/games/{url}/about.html", "Games", "Show")
                .MapRoute(BrcDomainRoutes.GamePosts, "/games/{url}/posts.html", "Games", "Posts")
                .MapRoute(BrcDomainRoutes.GamePostsPage, "/games/{url}/posts/page/{page:int}.html", "Games",
                    "PostsPage")
                .MapRoute(BioEnginePagesRoutes.Page, "/pages/{url.html}", "Pages", "Show")
                ;

            return endpoints;
        }


    }
}
