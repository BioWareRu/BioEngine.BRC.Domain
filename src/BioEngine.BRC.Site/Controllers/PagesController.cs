using BioEngine.Core.Site;
using BioEngine.Core.Web;
using BioEngine.Pages.Db;
using BioEngine.Pages.Entities;

namespace BioEngine.BRC.Site.Controllers
{
    public class PagesController : SiteController<Page, PagesRepository>
    {
        public PagesController(BaseControllerContext<Page, PagesRepository> context) :
            base(context)
        {
        }
    }
}
