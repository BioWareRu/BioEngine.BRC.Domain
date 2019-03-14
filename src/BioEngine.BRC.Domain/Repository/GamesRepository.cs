using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public sealed class GamesRepository : SiteEntityRepository<Game>
    {
        public GamesRepository(BioRepositoryContext<Game> repositoryContext) : base(repositoryContext)
        {
        }
    }
}
