using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Properties;
using Microsoft.AspNetCore.Routing;

namespace BioEngine.BRC.Common.Web.Site.Model
{
    public class PageViewModelContext
    {
        public PageViewModelContext(LinkGenerator linkGenerator, PropertiesProvider propertiesProvider,
            Entities.Site site, Section? section = null)
        {
            LinkGenerator = linkGenerator;
            PropertiesProvider = propertiesProvider;
            Site = site;
            Section = section;
        }

        public LinkGenerator LinkGenerator { get; }
        public PropertiesProvider PropertiesProvider { get; }
        public Entities.Site Site { get; }
        public Section? Section { get; }
    }
}
