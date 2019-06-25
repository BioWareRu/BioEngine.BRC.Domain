using System.Threading.Tasks;
using BioEngine.BRC.Domain.Entities;
using BioEngine.BRC.Domain.Repository;
using BioEngine.Core.Site;
using BioEngine.Core.Web;
using BioEngine.Posts.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.Controllers
{
    public class TopicsController : SectionController<Topic, TopicsRepository>
    {
        public TopicsController(BaseControllerContext<Topic, TopicsRepository> context) : base(context)
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
    }
}