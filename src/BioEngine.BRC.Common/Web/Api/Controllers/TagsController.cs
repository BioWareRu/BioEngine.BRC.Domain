using System;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Repository;

namespace BioEngine.BRC.Common.Web.Api.Controllers
{
    public class TagsController : ResponseRequestRestController<Tag, Guid, TagsRepository, Entities.Tag>
    {
        public TagsController(BaseControllerContext<Tag, Guid, TagsRepository> context) : base(context)
        {
        }
    }
}
