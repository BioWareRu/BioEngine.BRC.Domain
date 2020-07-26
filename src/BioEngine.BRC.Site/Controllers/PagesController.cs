using System;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Web;
using BioEngine.BRC.Common.Web.Site;
using BioEngine.BRC.Common.Web.Site.Model;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    public class PagesController : SiteController<Page, Guid, PagesRepository>
    {
        public PagesController(BaseControllerContext<Page, Guid, PagesRepository> context) :
            base(context)
        {
        }

        protected override IActionResult PageNotFound()
        {
            return View("~/Views/Errors/Error.cshtml", new ErrorsViewModel(GetPageContext(), 404));
        }
    }
}
