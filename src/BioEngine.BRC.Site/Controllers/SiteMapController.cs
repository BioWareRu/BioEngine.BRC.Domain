using System.Collections.Generic;
using System.Threading.Tasks;
using BioEngine.Core.Site.Controllers;
using cloudscribe.Web.SiteMap;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BioEngine.BRC.Site.Controllers
{
    public class SiteMapController : BaseSiteMapController
    {
        public SiteMapController(ILogger<cloudscribe.Web.SiteMap.Controllers.SiteMapController> logger,
            IEnumerable<ISiteMapNodeService> nodeProviders = null) : base(logger, nodeProviders)
        {
        }

        [HttpGet("/sitemap.xml")]
        [ResponseCache(CacheProfileName = "SiteMapCacheProfile")]
        public Task<IActionResult> IndexAsync()
        {
            return base.Index();
        }
    }
}
