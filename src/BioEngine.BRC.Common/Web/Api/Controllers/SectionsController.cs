using System;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Users;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace BioEngine.BRC.Common.Web.Api.Controllers
{
    [Authorize(Policy = BioPolicies.Sections)]
    public class SectionsController : SectionController<Section, Guid, SectionsRepository, Entities.Section>
    {
        public SectionsController([NotNull] BaseControllerContext<Section, Guid, SectionsRepository> context) : base(context)
        {
        }
    }
}
