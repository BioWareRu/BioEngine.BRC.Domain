using System.Threading.Tasks;
using BioEngine.BRC.Common.Properties;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Web.Api.Models;
using Microsoft.AspNetCore.Routing;

namespace BioEngine.BRC.Common.Ads.Api.Entities
{
    public class Ad : ContentEntityRestModel<BRC.Common.Entities.Ad>, IContentRequestRestModel<BRC.Common.Entities.Ad>,
        IContentResponseRestModel<BRC.Common.Entities.Ad>
    {
        public async Task<BRC.Common.Entities.Ad> GetEntityAsync(BRC.Common.Entities.Ad entity)
        {
            entity = await FillEntityAsync(entity);
            return entity;
        }

        public async Task SetEntityAsync(BRC.Common.Entities.Ad entity)
        {
            await ParseEntityAsync(entity);
        }

        public Ad(LinkGenerator linkGenerator, SitesRepository sitesRepository, PropertiesProvider propertiesProvider) :
            base(linkGenerator, sitesRepository, propertiesProvider)
        {
        }
    }
}
