using BioEngine.Core.Pages.Db;
using BioEngine.Core.Pages.Entities;
using BioEngine.Core.Site;
using BioEngine.Core.Site.Model;
using BioEngine.Core.Web;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    public class PagesController : SiteController<Page, PagesRepository>
    {
        public PagesController(BaseControllerContext<Page, PagesRepository> context) :
            base(context)
        {
        }
        
        protected override IActionResult PageNotFound()
        {
            return View("~/Views/Errors/Error.cshtml", new ErrorsViewModel(GetPageContext(), 404));
        }
    }
}
