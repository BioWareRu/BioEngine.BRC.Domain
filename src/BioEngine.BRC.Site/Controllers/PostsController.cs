using System.Threading.Tasks;
using BioEngine.Core.Comments;
using BioEngine.Posts.Db;
using BioEngine.Posts.Entities;
using BioEngine.Posts.Routing;
using BioEngine.Posts.Site;
using BioEngine.Core.Repository;
using BioEngine.Core.Web;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    [Route("/")]
    public class PostsController : BasePostsController
    {
        public PostsController(BaseControllerContext<Post, PostsRepository> context,
            TagsRepository tagsRepository, ICommentsProvider commentsProvider) : base(context, tagsRepository,
            commentsProvider)
        {
        }

        [HttpGet]
        public override Task<IActionResult> ListAsync()
        {
            return base.ListAsync();
        }

        [HttpGet("/posts/{url}.html", Name = BioEnginePostsRoutes.Post)]
        public override Task<IActionResult> ShowAsync(string url)
        {
            return base.ShowAsync(url);
        }

        [HttpGet("page/page.html", Name = BioEnginePostsRoutes.PostsPage)]
        public override Task<IActionResult> ListPageAsync(int page)
        {
            return base.ListPageAsync(page);
        }

        [HttpGet("posts/tags/{tagNames}/page/page.html", Name = BioEnginePostsRoutes.PostsByTagsPage)]
        public override Task<IActionResult> ListByTagPageAsync(string tagNames, int page)
        {
            return base.ListByTagPageAsync(tagNames, page);
        }

        [HttpGet("posts/tags/{tagNames}.html", Name = BioEnginePostsRoutes.PostsByTags)]
        public override Task<IActionResult> ListByTagAsync(string tagNames)
        {
            return base.ListByTagAsync(tagNames);
        }

        [HttpGet("/rss.xml")]
        public override Task<IActionResult> RssAsync()
        {
            return base.RssAsync();
        }
    }
}
