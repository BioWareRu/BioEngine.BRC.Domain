using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Entities.Abstractions;
using BioEngine.BRC.Common.Routing;
using cloudscribe.Web.SiteMap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Sitko.Core.Repository;

namespace BioEngine.BRC.Common.Web.Site.Sitemaps
{
    public abstract class BaseSiteMapNodeService<TEntity, TEntityPk> : ISiteMapNodeService
        where TEntity : class, IContentEntity, IEntity<TEntityPk>
    {
        protected readonly IRepository<TEntity, TEntityPk> Repository;
        protected readonly LinkGenerator LinkGenerator;
        protected readonly Entities.Site Site;
        protected virtual double Priority { get; } = 0.8;
        protected virtual PageChangeFrequency Frequency { get; } = PageChangeFrequency.Weekly;

        protected BaseSiteMapNodeService(IHttpContextAccessor httpContextAccessor,
            IRepository<TEntity, TEntityPk> repository,
            LinkGenerator linkGenerator)
        {
            Site = httpContextAccessor.HttpContext.Features.Get<CurrentSiteFeature>().Site;
            Repository = repository;
            LinkGenerator = linkGenerator;
        }

        [SuppressMessage("ReSharper", "UseAsyncSuffix")]
        public async Task<IEnumerable<ISiteMapNode>> GetSiteMapNodes(
            CancellationToken cancellationToken = default)
        {
            var entities = await Repository.GetAllAsync(queryable => queryable.ForSite(Site).Where(c => c.IsPublished),
                cancellationToken);

            var result = new List<ISiteMapNode>();
            foreach (var entity in entities.items)
            {
                var nodes = await GetNodesAsync(entity);
                result.AddRange(nodes);
            }

            await AddNodesAsync(result, entities.items);
            return result;
        }

        protected virtual Task<List<ISiteMapNode>> GetNodesAsync(TEntity entity)
        {
            var result = new List<ISiteMapNode>();

            var url = LinkGenerator.GeneratePublicUrl(entity);
            if (url != null)
            {
                result.Add(
                    new SiteMapNode(url.ToString())
                    {
                        LastModified = entity.DateUpdated.DateTime, ChangeFrequency = Frequency, Priority = Priority
                    }
                );
            }

            return Task.FromResult(result);
        }

        protected virtual Task AddNodesAsync(List<ISiteMapNode> nodes, TEntity[] entities)
        {
            return Task.CompletedTask;
        }
    }
}
