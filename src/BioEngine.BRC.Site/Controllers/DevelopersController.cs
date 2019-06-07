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
    [Route("/developers")]
    public class DevelopersController : SectionController<Developer, DevelopersRepository>
    {
        public DevelopersController(
            BaseControllerContext<Developer, DevelopersRepository> context,
            ContentItemsRepository contentItemsRepository) : base(context, contentItemsRepository)
        {
        }

        [HttpGet("/developers/{url}/about.html", Name = BrcDomainRoutes.DeveloperPublic)]
        public override Task<IActionResult> ShowAsync(string url)
        {
            return base.ShowAsync(url);
        }

        [HttpGet("/developers/{url}/posts.html", Name = BrcDomainRoutes.DeveloperPosts)]
        public Task<IActionResult> PostsAsync(string url)
        {
            return base.PostsAsync(new[] {"post"}, url);
        }

        [HttpGet("/developers/{url}/posts/page/{page:int}.html", Name = BrcDomainRoutes.DeveloperPostsPage)]
        public Task<IActionResult> PostsPageAsync(string url, int page)
        {
            return base.PostsPageAsync(new[] {"post"}, url, page);
        }
    }
}
