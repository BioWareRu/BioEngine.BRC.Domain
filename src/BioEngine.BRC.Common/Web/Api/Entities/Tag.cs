using System.Threading.Tasks;
using BioEngine.BRC.Common.Properties;
using BioEngine.BRC.Common.Web.Api.Models;

namespace BioEngine.BRC.Common.Web.Api.Entities
{
    public class Tag : RestModel<BRC.Common.Entities.Tag>, IRequestRestModel<BRC.Common.Entities.Tag>,
        IResponseRestModel<BRC.Common.Entities.Tag>
    {
        public string Title { get; set; }
        
        public async Task<BRC.Common.Entities.Tag> GetEntityAsync(BRC.Common.Entities.Tag entity)
        {
            entity = await FillEntityAsync(entity);
            entity.Title = Title;
            return entity;
        }

        public async Task SetEntityAsync(BRC.Common.Entities.Tag entity)
        {
            await ParseEntityAsync(entity);
            Title = entity.Title;
        }

        public Tag(PropertiesProvider propertiesProvider) : base(propertiesProvider)
        {
        }
    }
}
