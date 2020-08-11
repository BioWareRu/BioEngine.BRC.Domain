using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Entities.Abstractions;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Repository.Abstractions;
using BioEngine.BRC.Common.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Sitko.Core.Repository;

namespace BioEngine.BRC.Common.Web.Api
{
    public abstract class
        ContentEntityController<TEntity, TRepository, TResponse, TRequest> : RequestRestController<
            TEntity, Guid, TRepository, TResponse, TRequest>
        where TEntity : class, IContentEntity, IBioEntity
        where TResponse : class, IContentResponseRestModel<TEntity>
        where TRequest : class, IContentRequestRestModel<TEntity>
        where TRepository : IContentEntityRepository<TEntity>, IRepository<TEntity, Guid>
    {
        private readonly ContentBlocksRepository _blocksRepository;

        protected ContentEntityController(
            BaseControllerContext<TEntity, Guid, TRepository> context,
            ContentBlocksRepository blocksRepository) : base(context)
        {
            _blocksRepository = blocksRepository;
        }

        protected override Task<AddOrUpdateOperationResult<TEntity, Guid>> DoAddAsync(TEntity entity)
        {
            return Repository.AddWithBlocksAsync(entity);
        }

        protected override Task<AddOrUpdateOperationResult<TEntity, Guid>> DoUpdateAsync(TEntity entity)
        {
            return Repository.UpdateWithBlocksAsync(entity);
        }

        protected override Task<TEntity?> DoGetByIdAsync(Guid id)
        {
            return Repository.GetByIdWithBlocksAsync(id);
        }

        private ContentBlock? CreateBlock(string type)
        {
            return BRCDomainRegistrar.Instance().CreateBlock(type);
        }

        protected override async Task<TEntity> MapDomainModelAsync(TRequest restModel,
            TEntity domainModel = null)
        {
            domainModel = await base.MapDomainModelAsync(restModel, domainModel);

            domainModel.Blocks = new List<ContentBlock>();
            var dbBlocks = await _blocksRepository.GetByIdsAsync(restModel.Blocks.Select(b => b.Id).ToArray());
            foreach (var contentBlock in restModel.Blocks)
            {
                var block = dbBlocks.FirstOrDefault(b => b.Id == contentBlock.Id && b.ContentId == domainModel.Id);
                if (block == null)
                {
                    block = CreateBlock(contentBlock.Type);
                }

                if (block != null)
                {
                    block.Id = contentBlock.Id;
                    block.ContentId = domainModel.Id;
                    block.Position = contentBlock.Position;
                    block.SetData(contentBlock.Data);
                    block.DateUpdated = DateTimeOffset.UtcNow;
                    domainModel.Blocks.Add(block);
                }
            }

            return domainModel;
        }

        [HttpPost("publish/{id}")]
        public virtual async Task<ActionResult<TResponse>> PublishAsync(Guid id)
        {
            var entity = await Repository.GetByIdWithBlocksAsync(id);
            if (entity != null)
            {
                if (entity.IsPublished)
                {
                    return BadRequest();
                }

                await Repository.PublishAsync(entity);
                await AfterSaveAsync(entity);
                return Model(await MapRestModelAsync(entity));
            }

            return NotFound();
        }

        [HttpPost("hide/{id}")]
        public virtual async Task<ActionResult<TResponse>> HideAsync(Guid id)
        {
            var entity = await Repository.GetByIdAsync(id);
            if (entity != null)
            {
                if (!entity.IsPublished)
                {
                    return BadRequest();
                }

                await Repository.UnPublishAsync(entity);
                await AfterSaveAsync(entity);
                return Model(await MapRestModelAsync(entity));
            }

            return NotFound();
        }
    }
}
