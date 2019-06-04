using System.Threading.Tasks;
using BioEngine.Core.DB;
using BioEngine.Core.Pages.Db;
using BioEngine.Core.Pages.Entities;
using BioEngine.Core.Routing;
using BioEngine.Core.Site;
using BioEngine.Core.Web;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    public class PagesController : SiteController<Page, PagesRepository>
    {
        public PagesController(BaseControllerContext<Page, ContentEntityQueryContext<Page>, PagesRepository> context) :
            base(context)
        {
        }

        [HttpGet(BioEngineCoreRoutes.Page)]
        public override Task<IActionResult> ShowAsync(string url)
        {
            return base.ShowAsync(url);
        }
    }
}
