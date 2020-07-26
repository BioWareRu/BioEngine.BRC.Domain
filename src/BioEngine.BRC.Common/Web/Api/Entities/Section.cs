using BioEngine.BRC.Common.Properties;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Web.Api.Models;
using Microsoft.AspNetCore.Routing;

namespace BioEngine.BRC.Common.Web.Api.Entities
{
    public class Section : ResponseSectionRestModel<BRC.Common.Entities.Section>
    {
        public Section(LinkGenerator linkGenerator, SitesRepository sitesRepository,
            PropertiesProvider propertiesProvider) : base(linkGenerator,
            sitesRepository, propertiesProvider)
        {
        }
    }
}
