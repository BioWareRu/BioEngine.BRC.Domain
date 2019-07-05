using System;
using System.Threading.Tasks;
using BioEngine.Core.Site.Model;
using BioEngine.Core.Web;
using BioEngine.Extra.Ads.Entities;
using BioEngine.Extra.Ads.Site;
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
