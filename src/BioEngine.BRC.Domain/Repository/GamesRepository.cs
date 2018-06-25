using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public sealed class GamesRepository : SiteEntityRepository<Game, int>
    {
        public GamesRepository(BioRepositoryContext<Game, int> repositoryContext, SitesRepository sitesRepository) :
            base(repositoryContext, sitesRepository)
        {
        }
    }
}