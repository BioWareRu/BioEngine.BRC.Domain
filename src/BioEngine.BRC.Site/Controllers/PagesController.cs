using System.Threading.Tasks;
using BioEngine.Core.Site;
using BioEngine.Core.Web;
using BioEngine.Pages.Db;
using BioEngine.Pages.Entities;
using BioEngine.Pages.Routing;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    public class PagesController : SiteController<Page, PagesRepository>
    {
        public PagesController(BaseControllerContext<Page, PagesRepository> context) :
            base(context)
        {
        }

        [HttpGet(BioEnginePagesRoutes.Page)]
        public override Task<IActionResult> ShowAsync(string url)
        {
            return base.ShowAsync(url);
        }
    }
}
