using System;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Web;
using BioEngine.BRC.Common.Web.Site;
using BioEngine.BRC.Common.Web.Site.Model;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    public class GamesController : SectionController<Game, GamesRepository>
    {
        public GamesController(BaseControllerContext<Game, Guid, GamesRepository> context) : base(context)
        {
        }

        public Task<IActionResult> PostsAsync(string url)
        {
            return ShowContentAsync<Post>(url);
        }

        public Task<IActionResult> PostsPageAsync(string url, int page)
        {
            return ShowContentAsync<Post>(url, page);
        }

        protected override IActionResult PageNotFound()
        {
            return View("~/Views/Errors/Error.cshtml", new ErrorsViewModel(GetPageContext(), 404));
        }
    }
}
