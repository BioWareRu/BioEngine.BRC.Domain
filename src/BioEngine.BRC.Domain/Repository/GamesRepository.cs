using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public sealed class GamesRepository : SectionRepository<Game>
    {
        public GamesRepository(BioRepositoryContext<Game> repositoryContext,
            IMainSiteSelectionPolicy mainSiteSelectionPolicy) : base(repositoryContext, mainSiteSelectionPolicy)
        {
        }
    }
}
