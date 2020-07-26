using System;
using System.Linq;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities;
using Sitko.Core.Repository.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Repository
{
    public class MenuRepository : SiteEntityRepository<Menu>
    {
        public MenuRepository(EFRepositoryContext<Menu, Guid, BioContext> repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Menu?> GetSiteMenuAsync(Site site)
        {
            return await GetAsync(q => Task.FromResult(q.Where(m => m.SiteIds.Contains(site.Id))));
        }
    }
}
