using System.Threading.Tasks;
using BioEngine.BRC.Domain.Entities;
using BioEngine.BRC.Domain.Repository;
using BioEngine.Core.Posts.Entities;
using BioEngine.Core.Site;
using BioEngine.Core.Site.Model;
using BioEngine.Core.Web;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    public class GamesController : SectionController<Game, GamesRepository>
    {
        public GamesController(BaseControllerContext<Game, GamesRepository> context) : base(context)
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
