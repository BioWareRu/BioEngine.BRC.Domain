using System;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Users;
using Microsoft.AspNetCore.Authorization;

namespace BioEngine.BRC.Common.Web.Api.Controllers
{
    [Authorize(Policy = BioPolicies.Admin)]
    public class SitesController : ResponseRequestRestController<Common.Entities.Site, Guid, SitesRepository, Entities.Site>
    {
        public SitesController(BaseControllerContext<Common.Entities.Site, Guid, SitesRepository> context) : base(context)
        {
        }
    }
}
