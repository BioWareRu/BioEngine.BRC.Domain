using System.Threading.Tasks;
using BioEngine.BRC.Common.Properties;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Web.Api.Models;
using Microsoft.AspNetCore.Routing;

namespace BioEngine.BRC.Common.Pages.Api.Entities
{
    public class Page : ContentEntityRestModel<BioEngine.BRC.Common.Entities.Page>,
        IContentRequestRestModel<BioEngine.BRC.Common.Entities.Page>,
        IContentResponseRestModel<BioEngine.BRC.Common.Entities.Page>
    {
        public async Task<BioEngine.BRC.Common.Entities.Page> GetEntityAsync(
            BioEngine.BRC.Common.Entities.Page entity)
        {
            entity = await FillEntityAsync(entity);
            return entity;
        }

        public async Task SetEntityAsync(BioEngine.BRC.Common.Entities.Page entity)
        {
            await ParseEntityAsync(entity);
        }

        public Page(LinkGenerator linkGenerator, SitesRepository sitesRepository, PropertiesProvider propertiesProvider)
            : base(linkGenerator, sitesRepository, propertiesProvider)
        {
        }
    }
}
