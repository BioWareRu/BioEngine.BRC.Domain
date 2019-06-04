using System.Threading.Tasks;
using BioEngine.BRC.Domain;
using BioEngine.BRC.Domain.Entities;
using BioEngine.BRC.Domain.Repository;
using BioEngine.Core.DB;
using BioEngine.Core.Repository;
using BioEngine.Core.Site;
using BioEngine.Core.Web;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    [Route("/developers")]
    public class DevelopersController : SectionController<Developer, DevelopersRepository>
    {
        public DevelopersController(
            BaseControllerContext<Developer, ContentEntityQueryContext<Developer>, DevelopersRepository> context,
            ContentItemsRepository contentItemsRepository) : base(context, contentItemsRepository)
        {
        }

        [HttpGet(BrcDomainRoutes.DeveloperPublic)]
        public override Task<IActionResult> ShowAsync(string url)
        {
            return base.ShowAsync(url);
        }

        [HttpGet(BrcDomainRoutes.DeveloperPosts)]
        public Task<IActionResult> PostsAsync(string url)
        {
            return base.PostsAsync(new[] {"post"}, url);
        }

        [HttpGet(BrcDomainRoutes.DeveloperPostsPage)]
        public Task<IActionResult> PostsPageAsync(string url, int page)
        {
            return base.PostsPageAsync(new[] {"post"}, url, page);
        }
    }
}
