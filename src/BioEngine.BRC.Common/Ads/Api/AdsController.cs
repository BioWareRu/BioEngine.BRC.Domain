using System;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Policies;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Web;
using BioEngine.BRC.Common.Web.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Common.Ads.Api
{
    [Authorize(Policy = AdsPolicies.Ads)]
    public abstract class
        AdsApiController : ContentEntityController<Ad, AdsRepository, Entities.Ad, Entities.Ad>
    {
        private readonly StorageItemsRepository _storageItemsRepository;

        protected AdsApiController(BaseControllerContext<Ad, Guid, AdsRepository> context,
            ContentBlocksRepository blocksRepository, StorageItemsRepository storageItemsRepository) : base(context,
            blocksRepository)
        {
            _storageItemsRepository = storageItemsRepository;
        }

        public override async Task<ActionResult<StorageItem>> UploadAsync(string name)
        {
            var uploaded = await Storage.SaveFileAsync(await GetBodyAsStreamAsync(), name,
                $"ads/{DateTimeOffset.UtcNow.Year.ToString()}/{DateTimeOffset.UtcNow.Month.ToString()}");
            var item = StorageItem.FromCore(uploaded);
            await _storageItemsRepository.AddAsync(item);
            return item;
        }

        [Authorize(Policy = AdsPolicies.AdsAdd)]
        public override Task<ActionResult<Entities.Ad>> NewAsync()
        {
            return base.NewAsync();
        }

        [Authorize(Policy = AdsPolicies.AdsAdd)]
        public override Task<ActionResult<Entities.Ad>> AddAsync(Entities.Ad item)
        {
            return base.AddAsync(item);
        }

        [Authorize(Policy = AdsPolicies.AdsEdit)]
        public override Task<ActionResult<Entities.Ad>> UpdateAsync(Guid id, Entities.Ad item)
        {
            return base.UpdateAsync(id, item);
        }

        [Authorize(Policy = AdsPolicies.AdsDelete)]
        public override Task<ActionResult<Entities.Ad>> DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }

        [Authorize(Policy = AdsPolicies.AdsPublish)]
        public override Task<ActionResult<Entities.Ad>> PublishAsync(Guid id)
        {
            return base.PublishAsync(id);
        }

        [Authorize(Policy = AdsPolicies.AdsPublish)]
        public override Task<ActionResult<Entities.Ad>> HideAsync(Guid id)
        {
            return base.HideAsync(id);
        }
    }
}
