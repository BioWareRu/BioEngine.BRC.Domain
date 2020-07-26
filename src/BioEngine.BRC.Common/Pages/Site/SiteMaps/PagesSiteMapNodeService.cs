using System;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Web.Site.Sitemaps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Sitko.Core.Repository;

namespace BioEngine.BRC.Common.Pages.Site.SiteMaps
{
    public class PagesSiteMapNodeService : BaseSiteMapNodeService<Page, Guid>
    {
        public PagesSiteMapNodeService(IHttpContextAccessor httpContextAccessor,
            IRepository<Page, Guid> repository, LinkGenerator linkGenerator) :
            base(httpContextAccessor, repository, linkGenerator)
        {
        }
    }
}
