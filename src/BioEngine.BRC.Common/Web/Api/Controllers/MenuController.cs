using System;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Users;
using Microsoft.AspNetCore.Authorization;

namespace BioEngine.BRC.Common.Web.Api.Controllers
{
    [Authorize(Policy = BioPolicies.Admin)]
    public class MenuController : ResponseRequestRestController<Menu, Guid, MenuRepository, Entities.Menu>
    {
        public MenuController(BaseControllerContext<Menu, Guid, MenuRepository> context) : base(context)
        {
        }
    }
}
