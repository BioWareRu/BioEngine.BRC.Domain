using System.Threading.Tasks;
using BioEngine.Core.Comments;
using BioEngine.Core.DB;
using BioEngine.Core.Posts;
using BioEngine.Core.Posts.Db;
using BioEngine.Core.Posts.Entities;
using BioEngine.Core.Posts.Site;
using BioEngine.Core.Repository;
using BioEngine.Core.Site.Model;
using BioEngine.Core.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    public class PostsController : BasePostsController
    {
        private readonly IAuthorizationService _authorizationService;

        public PostsController(BaseControllerContext<Post, PostsRepository> context,
            TagsRepository tagsRepository, ICommentsProvider commentsProvider,
            IAuthorizationService authorizationService) : base(context, tagsRepository,
            commentsProvider)
        {
            _authorizationService = authorizationService;
        }

        protected override IActionResult PageNotFound()
        {
            return View("~/Views/Errors/Error.cshtml", new ErrorsViewModel(GetPageContext(), 404));
        }

        protected override async Task<BioQuery<Post>> ApplyPublishConditionsAsync(BioQuery<Post> query)
        {
            if (CurrentUser != null)
            {
                if ((await _authorizationService.AuthorizeAsync(User, PostsPolicies.Posts)).Succeeded)
                {
                    return query;
                }

                return query.Where(e => e.IsPublished || e.AuthorId == CurrentUser.Id);
            }

            return await base.ApplyPublishConditionsAsync(query);
        }
    }
}
