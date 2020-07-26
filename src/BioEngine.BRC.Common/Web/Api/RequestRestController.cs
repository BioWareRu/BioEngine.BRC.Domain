using System;
using System.Linq;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities.Abstractions;
using BioEngine.BRC.Common.Web.Api.Models;
using BioEngine.BRC.Common.Web.Api.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sitko.Core.Repository;
using Sitko.Core.Storage;

namespace BioEngine.BRC.Common.Web.Api
{
    public abstract class
        RequestRestController<TEntity, TEntityPk, TRepository, TResponse, TRequest> : ResponseRestController<TEntity,
            TEntityPk
            , TRepository,
            TResponse>
        where TEntity : class, IBioEntity, IEntity<TEntityPk>
        where TResponse : class, IResponseRestModel<TEntity>
        where TRequest : class, IRequestRestModel<TEntity>
        where TRepository : IRepository<TEntity, TEntityPk>
    {
        protected RequestRestController(BaseControllerContext<TEntity, TEntityPk, TRepository> context) :
            base(context)
        {
        }

        protected virtual async Task<TEntity> MapDomainModelAsync(TRequest restModel,
            TEntity domainModel = null)
        {
            return await restModel.GetEntityAsync(domainModel);
        }

        protected virtual Task<AddOrUpdateOperationResult<TEntity, TEntityPk>> DoAddAsync(TEntity entity)
        {
            return Repository.AddAsync(entity);
        }

        protected virtual Task<AddOrUpdateOperationResult<TEntity, TEntityPk>> DoUpdateAsync(TEntity entity)
        {
            return Repository.UpdateAsync(entity);
        }

        protected virtual Task<bool> DoDeleteAsync(TEntityPk id)
        {
            return Repository.DeleteAsync(id);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TResponse>> AddAsync(TRequest item)
        {
            var entity = await MapDomainModelAsync(item, Activator.CreateInstance<TEntity>());

            var result = await DoAddAsync(entity);
            if (result.IsSuccess)
            {
                await AfterSaveAsync(result.Entity, result.Changes, item);
                if (item is RestModel<TEntity> restModel)
                {
                    await SavePropertiesAsync(restModel, entity);
                }

                return Created(await MapRestModelAsync(result.Entity));
            }

            return Errors(StatusCodes.Status422UnprocessableEntity,
                result.Errors.Select(e => new ValidationErrorResponse(e.PropertyName, e.ErrorMessage)));
        }

        protected virtual async Task SavePropertiesAsync(RestModel<TEntity> restModel, TEntity entity)
        {
            var properties = restModel.PropertiesGroups?.Select(s => s.GetPropertiesEntry()).ToList();
            if (properties != null)
            {
                foreach (var propertiesEntry in properties)
                {
                    foreach (var val in propertiesEntry.Properties)
                    {
                        await PropertiesProvider.SetAsync(val.Value, entity, val.SiteId);
                    }
                }
            }
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<TResponse>> UpdateAsync(TEntityPk id, TRequest item)
        {
            var entity = await Repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            entity = await MapDomainModelAsync(item, entity);

            var result = await DoUpdateAsync(entity);
            if (result.IsSuccess)
            {
                await AfterSaveAsync(result.Entity, result.Changes, item);
                if (item is RestModel<TEntity> restModel)
                {
                    await SavePropertiesAsync(restModel, entity);
                }

                return Updated(await MapRestModelAsync(result.Entity));
            }

            return Errors(StatusCodes.Status422UnprocessableEntity,
                result.Errors.Select(e => new ValidationErrorResponse(e.PropertyName, e.ErrorMessage)));
        }

        [HttpPost("upload")]
        public virtual Task<ActionResult<StorageItem>> UploadAsync([FromQuery] string name)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<TResponse>> DeleteAsync(TEntityPk id)
        {
            var entity = await DoGetByIdAsync(id);
            if (entity != null)
            {
                var result = await DoDeleteAsync(id);
                if (result)
                {
                    await AfterDeleteAsync(entity);
                    return Deleted();
                }
            }

            return BadRequest();
        }


        protected ActionResult<TResponse> Created(
            TResponse model)
        {
            return SaveResponse(StatusCodes.Status201Created, model);
        }

        protected ActionResult<TResponse> Updated(
            TResponse model)
        {
            return SaveResponse(StatusCodes.Status202Accepted, model);
        }

        protected ActionResult<TResponse> Deleted()
        {
            return SaveResponse(StatusCodes.Status204NoContent, null);
        }


        private ActionResult<TResponse> SaveResponse(int code,
            TResponse model)
        {
            return new ObjectResult(new SaveModelResponse<TResponse>(code, model)) {StatusCode = code};
        }

        protected virtual Task AfterSaveAsync(TEntity domainModel, PropertyChange[] changes = null,
            TRequest request = null)
        {
            return Task.CompletedTask;
        }

        protected virtual Task AfterDeleteAsync(TEntity domainModel)
        {
            return Task.CompletedTask;
        }
    }

    public abstract class
        ResponseRequestRestController<TEntity, TEntityPk, TRepository, TRequestResponse> :
            RequestRestController<TEntity, TEntityPk, TRepository, TRequestResponse, TRequestResponse>
        where TEntity : class, IBioEntity, IEntity<TEntityPk>
        where TRequestResponse : class, IResponseRestModel<TEntity>, IRequestRestModel<TEntity>
        where TRepository : IRepository<TEntity, TEntityPk>
    {
        protected ResponseRequestRestController(BaseControllerContext<TEntity, TEntityPk, TRepository> context) :
            base(context)
        {
        }
    }
}
