using System;
using System.IO;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Entities.Abstractions;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Repository.Abstractions;
using BioEngine.BRC.Common.Users;
using BioEngine.BRC.Common.Web.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sitko.Core.Repository;

namespace BioEngine.BRC.Common.Web.Api
{
    [Authorize(Policy = BioPolicies.Sections)]
    public abstract class
        SectionController<TEntity, TData, TRepository, TResponse, TRequest> : ContentEntityController<
            TEntity, TRepository,
            TResponse
            , TRequest>
        where TEntity : Section<TData>, IEntity
        where TData : ITypedData, new()
        where TResponse : class, IContentResponseRestModel<TEntity>
        where TRequest : SectionRestModel<TEntity>, IContentRequestRestModel<TEntity>
        where TRepository : IContentEntityRepository<TEntity>
    {
        private readonly StorageItemsRepository _storageItemsRepository;

        protected SectionController(BaseControllerContext<TEntity, Guid, TRepository> context,
            ContentBlocksRepository blocksRepository, StorageItemsRepository storageItemsRepository) : base(context,
            blocksRepository)
        {
            _storageItemsRepository = storageItemsRepository;
        }

        public override async Task<ActionResult<StorageItem>> UploadAsync([FromQuery] string name)
        {
            var uploaded = await Storage.SaveFileAsync(await GetBodyAsStreamAsync(), name,
                Path.Combine("sections", GetUploadPath()));
            var item = StorageItem.FromCore(uploaded);
            await _storageItemsRepository.AddAsync(item);
            return item;
        }

        protected abstract string GetUploadPath();

        [Authorize(Policy = BioPolicies.SectionsAdd)]
        public override Task<ActionResult<TResponse>> NewAsync()
        {
            return base.NewAsync();
        }

        [Authorize(Policy = BioPolicies.SectionsAdd)]
        public override Task<ActionResult<TResponse>> AddAsync(TRequest item)
        {
            return base.AddAsync(item);
        }

        [Authorize(Policy = BioPolicies.SectionsEdit)]
        public override Task<ActionResult<TResponse>> UpdateAsync(Guid id, TRequest item)
        {
            return base.UpdateAsync(id, item);
        }

        [Authorize(Policy = BioPolicies.SectionsDelete)]
        public override Task<ActionResult<TResponse>> DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }

        [Authorize(Policy = BioPolicies.SectionsPublish)]
        public override Task<ActionResult<TResponse>> PublishAsync(Guid id)
        {
            return base.PublishAsync(id);
        }

        [Authorize(Policy = BioPolicies.SectionsPublish)]
        public override Task<ActionResult<TResponse>> HideAsync(Guid id)
        {
            return base.HideAsync(id);
        }
    }

    public abstract class
        SectionController<TEntity, TEntityPk, TRepository, TResponse> : ResponseRestController<TEntity, TEntityPk,
            TRepository, TResponse>
        where TEntity : Section, IEntity<TEntityPk>
        where TResponse : IResponseRestModel<TEntity>
        where TRepository : IRepository<TEntity, TEntityPk>
    {
        protected SectionController(BaseControllerContext<TEntity, TEntityPk, TRepository> context) : base(context)
        {
        }
    }
}
