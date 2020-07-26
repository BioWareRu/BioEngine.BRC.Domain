using System.Threading.Tasks;
using BioEngine.BRC.Common.Properties;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Users;
using BioEngine.BRC.Common.Web.Api.Models;
using Microsoft.AspNetCore.Routing;

namespace BioEngine.BRC.Common.Posts.Api.Entities
{
    public class PostRequestItem : SectionEntityRestModel<BRC.Common.Entities.Post>,
        IContentRequestRestModel<BRC.Common.Entities.Post>
    {
        public async Task<BRC.Common.Entities.Post> GetEntityAsync(BRC.Common.Entities.Post entity)
        {
            return await FillEntityAsync(entity);
        }

        protected override async Task<BRC.Common.Entities.Post> FillEntityAsync(BRC.Common.Entities.Post entity)
        {
            entity = await base.FillEntityAsync(entity);
            return entity;
        }

        public PostRequestItem(LinkGenerator linkGenerator, SitesRepository sitesRepository,
            PropertiesProvider propertiesProvider) : base(linkGenerator,
            sitesRepository, propertiesProvider)
        {
        }
    }

    public class Post : PostRequestItem, IContentResponseRestModel<BRC.Common.Entities.Post>
    {
        public IUser Author { get; set; }
        public string AuthorId { get; set; }

        protected override async Task ParseEntityAsync(BRC.Common.Entities.Post entity)
        {
            await base.ParseEntityAsync(entity);
            AuthorId = entity.AuthorId;
            Author = entity.Author;
        }


        public async Task SetEntityAsync(BRC.Common.Entities.Post entity)
        {
            await ParseEntityAsync(entity);
        }

        public Post(LinkGenerator linkGenerator, SitesRepository sitesRepository, PropertiesProvider propertiesProvider)
            : base(linkGenerator, sitesRepository, propertiesProvider)
        {
        }
    }
}
