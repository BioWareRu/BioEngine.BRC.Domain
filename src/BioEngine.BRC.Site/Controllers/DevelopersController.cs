using System.Threading.Tasks;
using BioEngine.BRC.Domain.Entities;
using BioEngine.BRC.Domain.Repository;
using BioEngine.Core.Repository;
using BioEngine.Core.Site;
using BioEngine.Core.Web;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    public class DevelopersController : SectionController<Developer, DevelopersRepository>
    {
        public DevelopersController(
            BaseControllerContext<Developer, DevelopersRepository> context,
            ContentItemsRepository contentItemsRepository) : base(context, contentItemsRepository)
        {
        }

        public Task<IActionResult> PostsAsync(string url)
        {
            return base.PostsAsync(new[] {"post"}, url);
        }

        public Task<IActionResult> PostsPageAsync(string url, int page)
        {
            return base.PostsPageAsync(new[] {"post"}, url, page);
        }
    }
}
