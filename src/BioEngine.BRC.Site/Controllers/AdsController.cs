using System;
using System.Threading.Tasks;
using BioEngine.Extra.Ads.Entities;
using BioEngine.Extra.Ads.Site;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    [Route("ads")]
    public class AdsController : AdsSiteController
    {
        public AdsController(AdsRepository adsRepository) : base(adsRepository)
        {
        }

        [HttpGet("go/{adId}.html")]
        public override Task<ActionResult> RedirectAsync(Guid adId)
        {
            return base.RedirectAsync(adId);
        }
    }
}
