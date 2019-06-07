using System.Threading.Tasks;
using BioEngine.BRC.Domain;
using BioEngine.BRC.Domain.Entities;
using BioEngine.BRC.Domain.Repository;
using BioEngine.Core.Repository;
using BioEngine.Core.Site;
using BioEngine.Core.Web;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    [Route("/games")]
    public class GamesController : SectionController<Game, GamesRepository>
    {
        public GamesController(BaseControllerContext<Game, GamesRepository> context,
            ContentItemsRepository contentItemsRepository) : base(context, contentItemsRepository)
        {
        }

        [HttpGet("/games/{url}/about.html", Name = BrcDomainRoutes.GamePublic)]
        public override Task<IActionResult> ShowAsync(string url)
        {
            return base.ShowAsync(url);
        }

        [HttpGet("/games/{url}/posts.html", Name = BrcDomainRoutes.GamePosts)]
        public Task<IActionResult> PostsAsync(string url)
        {
            return base.PostsAsync(new[] {"post"}, url);
        }

        [HttpGet("/games/{url}/posts/page/{page:int}.html", Name = BrcDomainRoutes.GamePostsPage)]
        public Task<IActionResult> PostsPageAsync(string url, int page)
        {
            return base.PostsPageAsync(new[] {"post"}, url, page);
        }
    }
}
