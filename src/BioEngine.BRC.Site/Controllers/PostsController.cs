using BioEngine.Core.Comments;
using BioEngine.Posts.Db;
using BioEngine.Posts.Entities;
using BioEngine.Posts.Site;
using BioEngine.Core.Repository;
using BioEngine.Core.Web;

namespace BioEngine.BRC.Site.Controllers
{
    public class PostsController : BasePostsController
    {
        public PostsController(BaseControllerContext<Post, PostsRepository> context,
            TagsRepository tagsRepository, ICommentsProvider commentsProvider) : base(context, tagsRepository,
            commentsProvider)
        {
        }
    }
}
