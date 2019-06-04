using System.Threading.Tasks;
using BioEngine.Core.Comments;
using BioEngine.Core.DB;
using BioEngine.Core.Posts.Db;
using BioEngine.Core.Posts.Entities;
using BioEngine.Core.Posts.Site;
using BioEngine.Core.Repository;
using BioEngine.Core.Routing;
using BioEngine.Core.Web;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    [Route("/")]
    public class PostsController : BasePostsController
    {
        public PostsController(BaseControllerContext<Post, ContentEntityQueryContext<Post>, PostsRepository> context,
            TagsRepository tagsRepository, ICommentsProvider commentsProvider) : base(context, tagsRepository,
            commentsProvider)
        {
        }

        [HttpGet]
        public override Task<IActionResult> ListAsync()
        {
            return base.ListAsync();
        }

        [HttpGet(BioEngineCoreRoutes.Post)]
        public override Task<IActionResult> ShowAsync(string url)
        {
            return base.ShowAsync(url);
        }

        [HttpGet(BioEngineCoreRoutes.PostsPage)]
        public override Task<IActionResult> ListPageAsync(int page)
        {
            return base.ListPageAsync(page);
        }

        [HttpGet(BioEngineCoreRoutes.PostsByTagsPage)]
        public override Task<IActionResult> ListByTagPageAsync(string tagNames, int page)
        {
            return base.ListByTagPageAsync(tagNames, page);
        }

        [HttpGet(BioEngineCoreRoutes.PostsByTags)]
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
