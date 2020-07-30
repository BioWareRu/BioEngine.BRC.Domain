using System.IO;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Common.Web.Api
{
    [ApiController]
    [Authorize(Policy = BioPolicies.User)]
    [Route("v1/[controller]")]
    public abstract class ApiController : BaseController
    {
        protected ApiController(BaseControllerContext context) : base(context)
        {
        }

        protected async Task<Stream> GetBodyAsStreamAsync()
        {
            var memoryStream = new MemoryStream();
            await Request.Body.CopyToAsync(memoryStream);
            return memoryStream;
        }
    }
}
