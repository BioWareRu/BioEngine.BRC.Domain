using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Properties;
using Microsoft.AspNetCore.Routing;
using Sitko.Core.Storage;

namespace BioEngine.BRC.Common.Web.Site.Model
{
    public class PageViewModelContext
    {
        public PageViewModelContext(LinkGenerator linkGenerator, PropertiesProvider propertiesProvider,
            Entities.Site site, IStorage<BRCStorageConfig> storage, Section? section = null)
        {
            LinkGenerator = linkGenerator;
            PropertiesProvider = propertiesProvider;
            Site = site;
            Storage = storage;
            Section = section;
        }

        public LinkGenerator LinkGenerator { get; }
        public PropertiesProvider PropertiesProvider { get; }
        public Entities.Site Site { get; }
        public IStorage<BRCStorageConfig> Storage { get; }
        public Section? Section { get; }
    }
}
