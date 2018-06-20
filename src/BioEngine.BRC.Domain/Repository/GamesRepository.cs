using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public sealed class GamesRepository : SiteEntityRepository<Game, int>
    {
        internal GamesRepository(BioRepositoryContext<Game, int> repositoryContext) : base(repositoryContext)
        {
        }
    }
}