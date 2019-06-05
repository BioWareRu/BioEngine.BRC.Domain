using System.Threading.Tasks;
using BioEngine.Core.Comments;
using BioEngine.Core.Posts.Db;
using BioEngine.Core.Posts.Entities;
using BioEngine.Core.Posts.Routing;
using BioEngine.Core.Posts.Site;
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

        [HttpGet(BioEnginePostsRoutes.Post)]
        public override Task<IActionResult> ShowAsync(string url)
        {
            return base.ShowAsync(url);
        }

        [HttpGet(BioEnginePostsRoutes.PostsPage)]
        public override Task<IActionResult> ListPageAsync(int page)
        {
            return base.ListPageAsync(page);
        }

        [HttpGet(BioEnginePostsRoutes.PostsByTagsPage)]
        public override Task<IActionResult> ListByTagPageAsync(string tagNames, int page)
        {
            return base.ListByTagPageAsync(tagNames, page);
        }

        [HttpGet(BioEnginePostsRoutes.PostsByTags)]
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
