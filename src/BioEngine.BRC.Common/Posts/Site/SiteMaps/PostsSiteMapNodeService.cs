using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Web.Site.Sitemaps;
using cloudscribe.Web.SiteMap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Sitko.Core.Repository;

namespace BioEngine.BRC.Common.Posts.Site.SiteMaps
{
    public class PostsSiteMapNodeService : BaseSiteMapNodeService<Post, Guid>
    {
        protected override double Priority { get; } = 0.9;

        public PostsSiteMapNodeService(IHttpContextAccessor httpContextAccessor,
            IRepository<Post, Guid> repository,
            LinkGenerator linkGenerator) :
            base(httpContextAccessor, repository, linkGenerator)
        {
        }

        protected override async Task AddNodesAsync(List<ISiteMapNode> nodes, Post[] entities)
        {
            await base.AddNodesAsync(nodes, entities);
            nodes.Add(new SiteMapNode("/")
            {
                Priority = 1,
                ChangeFrequency = PageChangeFrequency.Daily,
                LastModified = entities.Length > 0
                    ? entities.OrderByDescending(e => e.DateUpdated).First().DateUpdated.DateTime
                    : DateTime.Now
            });
        }
    }
}
