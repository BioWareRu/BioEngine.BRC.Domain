using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BioEngine.BRC.Common.Web.Api.Interfaces;
using BioEngine.BRC.Common.Web.Api.Models;
using BioEngine.BRC.Common.Web.Api.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sitko.Core.Repository;

namespace BioEngine.BRC.Common.Web.Api
{
    public abstract class ResponseRestController<TEntity, TEntityPk, TRepository, TResponse> : ApiController
        where TResponse : IResponseRestModel<TEntity>
        where TEntity : class, IEntity<TEntityPk>
        where TRepository : IRepository<TEntity, TEntityPk>
    {
        protected TRepository Repository { get; }

        protected ResponseRestController(BaseControllerContext<TEntity, TEntityPk, TRepository> context) : base(context)
        {
            Repository = context.Repository;
        }

        protected virtual async Task<TResponse> MapRestModelAsync(TEntity domainModel)
        {
            var restModel = HttpContext.RequestServices.GetRequiredService<TResponse>();
            await restModel.SetEntityAsync(domainModel);
            return restModel;
        }

        [HttpGet]
        public virtual async Task<ActionResult<ListResponse<TResponse>>> GetAsync([FromQuery] int limit = 20,
            [FromQuery] int offset = 0, [FromQuery] string? order = null, [FromQuery] string? filter = null)
        {
            var result = await Repository.GetAllAsync(q => ConfigureQuery(q, limit, offset, order, filter));
            return await ListAsync(result);
        }

        protected virtual Task<TEntity?> DoGetByIdAsync(TEntityPk id)
        {
            return Repository.GetByIdAsync(id);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TResponse>> GetAsync(TEntityPk id)
        {
            var entity = await DoGetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Model(await MapRestModelAsync(entity));
        }

        [HttpGet("new")]
        public virtual async Task<ActionResult<TResponse>> NewAsync()
        {
            return Model(await MapRestModelAsync(await Repository.NewAsync()));
        }


        [HttpGet("count")]
        public virtual async Task<ActionResult<int>> CountAsync([FromQuery] int limit = 20,
            [FromQuery] int offset = 0, [FromQuery] string? order = null, [FromQuery] string? filter = null)
        {
            var result = await Repository.CountAsync(query => ConfigureQuery(query, limit, offset, order, filter));
            return Ok(result);
        }

        protected IRepositoryQuery<TEntity> ConfigureQuery(IRepositoryQuery<TEntity> query, int limit, int offset,
            string? order,
            string? filter)
        {
            if (!string.IsNullOrEmpty(filter) &&
                filter != "null")
            {
                var mod4 = filter.Length % 4;
                if (mod4 > 0)
                {
                    filter += new string('=', 4 - mod4);
                }

                var data = Convert.FromBase64String(filter);
                var decodedString = HttpUtility.UrlDecode(Encoding.UTF8.GetString(data));
                if (!string.IsNullOrEmpty(decodedString))
                {
                    query = query.WhereByString(decodedString);
                }
            }

            if (!string.IsNullOrEmpty(order))
            {
                query = query.OrderByString(order);
            }

            if (limit > 0)
            {
                query = query.Take(limit);
            }

            if (offset > 0)
            {
                query = query.Skip(offset);
            }

            return query;
        }

        protected async Task<ActionResult<ListResponse<TResponse>>> ListAsync(
            (IEnumerable<TEntity> items, int itemsCount) result)
        {
            var restModels = new List<TResponse>();
            foreach (var item in result.items)
            {
                restModels.Add(await MapRestModelAsync(item));
            }

            return Ok(new ListResponse<TResponse>(restModels, result.itemsCount));
        }

        protected ActionResult<TResponse> Model(
            TResponse model)
        {
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        protected new ActionResult<TResponse> NotFound()
        {
            return Errors(StatusCodes.Status404NotFound, new[] {new RestErrorResponse("Not Found")});
        }

        protected ActionResult<TResponse> Errors(int code,
            IEnumerable<IErrorInterface> errors)
        {
            return new ObjectResult(new RestResponse(code, errors)) {StatusCode = code};
        }
    }
}
