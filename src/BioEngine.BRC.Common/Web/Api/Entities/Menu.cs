using System.Collections.Generic;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Properties;
using BioEngine.BRC.Common.Web.Api.Models;

namespace BioEngine.BRC.Common.Web.Api.Entities
{
    public class Menu : SiteEntityRestModel<BRC.Common.Entities.Menu>, IRequestRestModel<BRC.Common.Entities.Menu>,
        IResponseRestModel<BRC.Common.Entities.Menu>
    {
        public List<MenuItem> Items { get; set; } = new List<MenuItem>();

        public async Task<BRC.Common.Entities.Menu> GetEntityAsync(BRC.Common.Entities.Menu entity)
        {
            entity = await FillEntityAsync(entity);
            entity.Items = Items;
            return entity;
        }

        public async Task SetEntityAsync(BRC.Common.Entities.Menu entity)
        {
            await ParseEntityAsync(entity);
            Items = entity.Items;
        }

        public Menu(PropertiesProvider propertiesProvider) : base(propertiesProvider)
        {
        }
    }
}
