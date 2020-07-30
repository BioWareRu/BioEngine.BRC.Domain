using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Policies;
using BioEngine.BRC.Common.Posts.Api.Entities;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Users;
using BioEngine.BRC.Common.Web;
using BioEngine.BRC.Common.Web.Api;
using BioEngine.BRC.Common.Web.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post = BioEngine.BRC.Common.Posts.Api.Entities.Post;

namespace BioEngine.BRC.Common.Posts.Api
{
    [Authorize(Policy = PostsPolicies.Posts)]
    public abstract class
        ApiPostsController : ContentEntityController<BRC.Common.Entities.Post, PostsRepository, Post, PostRequestItem>
    {
        private readonly IUserDataProvider _userDataProvider;
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly StorageItemsRepository _storageItemsRepository;

        protected ApiPostsController(
            BaseControllerContext<BRC.Common.Entities.Post, Guid, PostsRepository> context,
            ContentBlocksRepository blocksRepository, IUserDataProvider userDataProvider,
            ICurrentUserProvider currentUserProvider, StorageItemsRepository storageItemsRepository) : base(context,
            blocksRepository)
        {
            _userDataProvider = userDataProvider;
            _currentUserProvider = currentUserProvider;
            _storageItemsRepository = storageItemsRepository;
        }

        public override async Task<ActionResult<StorageItem>> UploadAsync(string name)
        {
            var uploaded = await Storage.SaveFileAsync(await GetBodyAsStreamAsync(), name,
                $"posts/{DateTimeOffset.UtcNow.Year.ToString()}/{DateTimeOffset.UtcNow.Month.ToString()}");
            var item = StorageItem.FromCore(uploaded);
            await _storageItemsRepository.AddAsync(item);
            return item;
        }

        [HttpGet("{postId}/versions")]
        [Authorize(Policy = PostsPolicies.PostsEdit)]
        public async Task<ActionResult<List<ContentItemVersionInfo>>> GetVersionsAsync(Guid postId)
        {
            var versions = await Repository.GetVersionsAsync(postId);
            var userIds =
                await _userDataProvider.GetDataAsync(versions.Select(v => v.ChangeAuthorId).Distinct().ToArray());
            return Ok(versions.Select(v =>
                    new ContentItemVersionInfo(v.Id, v.DateAdded,
                        userIds.FirstOrDefault(u => u.Id.Equals(v.ChangeAuthorId))))
                .ToList());
        }

        [HttpGet("{postId}/versions/{versionId}")]
        [Authorize(Policy = PostsPolicies.PostsEdit)]
        public async Task<ActionResult<Post>> GetVersionAsync(Guid postId, Guid versionId)
        {
            var version = await Repository.GetVersionAsync(postId, versionId);
            if (version == null)
            {
                return NotFound();
            }

            var post = version.GetContent<BRC.Common.Entities.Post>();
            return Ok(await MapRestModelAsync(post));
        }

        [Authorize(Policy = PostsPolicies.PostsAdd)]
        public override Task<ActionResult<Post>> NewAsync()
        {
            return base.NewAsync();
        }

        [Authorize(Policy = PostsPolicies.PostsAdd)]
        public override Task<ActionResult<Post>> AddAsync(PostRequestItem item)
        {
            return base.AddAsync(item);
        }

        [Authorize(Policy = PostsPolicies.PostsEdit)]
        public override Task<ActionResult<Post>> UpdateAsync(Guid id, PostRequestItem item)
        {
            return base.UpdateAsync(id, item);
        }

        [Authorize(Policy = PostsPolicies.PostsDelete)]
        public override Task<ActionResult<Post>> DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }

        [Authorize(Policy = PostsPolicies.PostsPublish)]
        public override Task<ActionResult<Post>> PublishAsync(Guid id)
        {
            return base.PublishAsync(id);
        }

        [Authorize(Policy = PostsPolicies.PostsPublish)]
        public override Task<ActionResult<Post>> HideAsync(Guid id)
        {
            return base.HideAsync(id);
        }

        protected override async Task<BRC.Common.Entities.Post> MapDomainModelAsync(
            PostRequestItem restModel, BRC.Common.Entities.Post domainModel = null)
        {
            domainModel = await base.MapDomainModelAsync(restModel, domainModel);
            if (domainModel.AuthorId == null)
            {
                domainModel.AuthorId = _currentUserProvider.CurrentUser.Id;
            }

            return domainModel;
        }
    }
}
