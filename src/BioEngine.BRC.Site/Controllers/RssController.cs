using System.Collections.Generic;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Web;
using BioEngine.BRC.Common.Web.Site.Controllers;
using BioEngine.BRC.Common.Web.Site.Rss;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    public class RssController : BaseRssController
    {
        public RssController(BaseControllerContext context, IEnumerable<IRssItemsProvider> itemsProviders = null) :
            base(context, itemsProviders)
        {
        }

        [ResponseCache(CacheProfileName = "SiteMapCacheProfile")]
        public override Task<IActionResult> IndexAsync()
        {
            return base.IndexAsync();
        }
    }
}
