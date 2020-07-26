using System;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Comments;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Policies;
using BioEngine.BRC.Common.Posts.Site;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Users;
using BioEngine.BRC.Common.Web;
using BioEngine.BRC.Common.Web.Site.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sitko.Core.Repository;

namespace BioEngine.BRC.Site.Controllers
{
    public class PostsController : BasePostsController
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ICurrentUserProvider _currentUserProvider;

        public PostsController(BaseControllerContext<Post, Guid, PostsRepository> context,
            TagsRepository tagsRepository, ICommentsProvider commentsProvider,
            IAuthorizationService authorizationService, ICurrentUserProvider currentUserProvider) : base(
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

        protected override async Task<IRepositoryQuery<Post>> ApplyPublishConditionsAsync(IRepositoryQuery<Post> query)
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
