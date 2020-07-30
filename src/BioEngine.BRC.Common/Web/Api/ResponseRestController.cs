using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BioEngine.BRC.Common.Web.Api.Interfaces;
using BioEngine.BRC.Common.Web.Api.Models;
using BioEngine.BRC.Common.Web.Api.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Sitko.Core.Repository;
using Sitko.Core.Storage;
using StorageItem = BioEngine.BRC.Common.Entities.StorageItem;

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

        public override void OnActionExecuted(ActionExecutedContext ctx)
        {
            if (ctx.Result is ObjectResult objectResult)
            {
                objectResult.Formatters.Add(new NewtonsoftJsonOutputFormatter(
                    new JsonSerializerSettings
                    {
                        ContractResolver =
                            new DefaultContractResolver {NamingStrategy = new CamelCaseNamingStrategy()},
                        Converters = new List<JsonConverter> {new StorageItemConverter(Storage)}
                    },
                    ctx.HttpContext.RequestServices.GetRequiredService<ArrayPool<char>>(),
                    ctx.HttpContext.RequestServices.GetRequiredService<IOptions<MvcOptions>>().Value));
            }
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

    public class StorageItemConverter : JsonConverter<StorageItem>
    {
        private readonly IStorage<BRCStorageConfig> _storage;

        public StorageItemConverter(IStorage<BRCStorageConfig> storage)
        {
            _storage = storage;
        }

        public override void WriteJson(JsonWriter writer, StorageItem value, JsonSerializer serializer)
        {
            var apiItem = new ApiStorageItem(value, _storage.PublicUri(value));

            var valueToken = JToken.FromObject(apiItem, JsonSerializer.Create(new JsonSerializerSettings
            {
                ContractResolver =
                    new DefaultContractResolver {NamingStrategy = new CamelCaseNamingStrategy()},
            }));
            valueToken.WriteTo(writer);
        }

        public override StorageItem ReadJson(JsonReader reader, Type objectType, StorageItem existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            string s = (string)reader.Value;
            return JsonConvert.DeserializeObject<ApiStorageItem>(s);
        }
    }

    public class ApiStorageItem : StorageItem
    {
        public Uri PublicUri { get; set; }

        public ApiStorageItem(StorageItem item, Uri publicUri)
        {
            Id = item.Id;
            Path = item.Path;
            FileName = item.FileName;
            FilePath = item.FilePath;
            FileSize = item.FileSize;
            DateAdded = item.DateAdded;
            DateUpdated = item.DateUpdated;
            PublicUri = publicUri;
        }
    }
}
