using System.Threading.Tasks;
using BioEngine.BRC.Common.Properties;
using BioEngine.BRC.Common.Web.Api.Models;

namespace BioEngine.BRC.Common.Web.Api.Entities
{
    public class Site : RestModel<BRC.Common.Entities.Site>, IRequestRestModel<BRC.Common.Entities.Site>,
        IResponseRestModel<BRC.Common.Entities.Site>
    {
        public string Url { get; set; }
        public string Title { get; set; }

        public async Task<BRC.Common.Entities.Site> GetEntityAsync(BRC.Common.Entities.Site entity)
        {
            entity = await FillEntityAsync(entity);
            entity.Url = Url;
            entity.Title = Title;
            return entity;
        }

        public async Task SetEntityAsync(BRC.Common.Entities.Site entity)
        {
            await ParseEntityAsync(entity);
            Url = entity.Url;
            Title = entity.Title;
        }

        public Site(PropertiesProvider propertiesProvider) : base(propertiesProvider)
        {
        }
    }
}
