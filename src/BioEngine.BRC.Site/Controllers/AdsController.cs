using System;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Ads.Site;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Web;
using BioEngine.BRC.Common.Web.Site.Model;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    [Route("ads")]
    public class AdsController : AdsSiteController
    {
        public AdsController(BaseControllerContext context, AdsRepository adsRepository) : base(context, adsRepository)
        {
        }

        [HttpGet("go/{adId}.html")]
        public override Task<IActionResult> RedirectAsync(Guid adId)
        {
            return base.RedirectAsync(adId);
        }

        protected override IActionResult PageNotFound()
        {
            return View("~/Views/Errors/Error.cshtml", new ErrorsViewModel(GetPageContext(), 404));
        }
    }
}
