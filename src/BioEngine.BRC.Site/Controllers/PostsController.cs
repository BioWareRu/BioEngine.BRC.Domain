using System.Threading.Tasks;
using BioEngine.Core.Comments;
using BioEngine.Core.DB;
using BioEngine.Core.Posts;
using BioEngine.Core.Posts.Db;
using BioEngine.Core.Posts.Entities;
using BioEngine.Core.Posts.Site;
using BioEngine.Core.Repository;
using BioEngine.Core.Site.Model;
using BioEngine.Core.Users;
using BioEngine.Core.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    public class PostsController : BasePostsController<string>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ICurrentUserProvider<string> _currentUserProvider;

        public PostsController(BaseControllerContext<Post<string>, PostsRepository<string>> context,
            TagsRepository tagsRepository, ICommentsProvider<string> commentsProvider,
            IAuthorizationService authorizationService, ICurrentUserProvider<string> currentUserProvider) : base(
            context, tagsRepository,
            commentsProvider)
        {
            _authorizationService = authorizationService;
            _currentUserProvider = currentUserProvider;
        }

        protected override IActionResult PageNotFound()
        {
            return View("~/Views/Errors/Error.cshtml", new ErrorsViewModel(GetPageContext(), 404));
        }

        protected override async Task<BioQuery<Post<string>>> ApplyPublishConditionsAsync(BioQuery<Post<string>> query)
        {
            var currentUser = _currentUserProvider.CurrentUser;
            if (currentUser != null)
            {
                if ((await _authorizationService.AuthorizeAsync(User, PostsPolicies.Posts)).Succeeded)
                {
                    return query;
                }

                return query.Where(e => e.IsPublished || e.AuthorId == currentUser.Id);
            }

            return await base.ApplyPublishConditionsAsync(query);
        }
    }
}
