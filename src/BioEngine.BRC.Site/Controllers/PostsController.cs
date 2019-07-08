using System.Security.Claims;
using BioEngine.Core.Comments;
using BioEngine.Core.Posts.Db;
using BioEngine.Core.Posts.Entities;
using BioEngine.Core.Posts.Site;
using BioEngine.Core.Repository;
using BioEngine.Core.Site.Model;
using BioEngine.Core.Web;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    public class PostsController : BasePostsController
    {
        public PostsController(BaseControllerContext<Post, PostsRepository> context,
            TagsRepository tagsRepository, ICommentsProvider commentsProvider) : base(context, tagsRepository,
            commentsProvider)
        {
        }

        protected override IActionResult PageNotFound()
        {
            return View("~/Views/Errors/Error.cshtml", new ErrorsViewModel(GetPageContext(), 404));
        }

        protected override BioRepositoryQuery<Post> ApplyPublishConditions(BioRepositoryQuery<Post> query)
        {
            if (CurrentUser != null)
            {
                if (User.HasClaim(ClaimTypes.Role, "admin"))
                {
                    return query;
                }

                return query.Where(e => e.IsPublished || e.AuthorId == CurrentUser.Id);
            }

            return base.ApplyPublishConditions(query);
        }
    }
}
