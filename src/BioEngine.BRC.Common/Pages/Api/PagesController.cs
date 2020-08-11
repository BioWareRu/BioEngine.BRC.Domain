﻿using System;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Policies;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Web;
using BioEngine.BRC.Common.Web.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Common.Pages.Api
{
    [Authorize(Policy = PagesPolicies.Pages)]
    public abstract class
        ApiPagesController : ContentEntityController<Page, PagesRepository, Entities.Page, Entities.Page>
    {
        private readonly StorageItemsRepository _storageItemsRepository;

        protected ApiPagesController(BaseControllerContext<Page, Guid, PagesRepository> context,
            ContentBlocksRepository blocksRepository, StorageItemsRepository storageItemsRepository) : base(context,
            blocksRepository)
        {
            _storageItemsRepository = storageItemsRepository;
        }

        public override async Task<ActionResult<StorageItem>> UploadAsync(string name)
        {
            var uploaded = await Storage.SaveFileAsync(await GetBodyAsStreamAsync(), name,
                $"pages/{DateTimeOffset.UtcNow.Year.ToString()}/{DateTimeOffset.UtcNow.Month.ToString()}");
            var item = StorageItem.FromCore(uploaded);
            await _storageItemsRepository.AddAsync(item);
            return item;
        }

        [Authorize(Policy = PagesPolicies.PagesAdd)]
        public override Task<ActionResult<Entities.Page>> AddAsync(Entities.Page item)
        {
            return base.AddAsync(item);
        }

        [Authorize(Policy = PagesPolicies.PagesEdit)]
        public override Task<ActionResult<Entities.Page>> UpdateAsync(Guid id, Entities.Page item)
        {
            return base.UpdateAsync(id, item);
        }

        [Authorize(Policy = PagesPolicies.PagesPublish)]
        public override Task<ActionResult<Entities.Page>> PublishAsync(Guid id)
        {
            return base.PublishAsync(id);
        }

        [Authorize(Policy = PagesPolicies.PagesPublish)]
        public override Task<ActionResult<Entities.Page>> HideAsync(Guid id)
        {
            return base.HideAsync(id);
        }

        [Authorize(Policy = PagesPolicies.PagesDelete)]
        public override Task<ActionResult<Entities.Page>> DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }

        [Authorize(Policy = PagesPolicies.PagesAdd)]
        public override Task<ActionResult<Entities.Page>> NewAsync()
        {
            return base.NewAsync();
        }
    }
}