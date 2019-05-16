using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public class TopicsRepository : SectionRepository<Topic>
    {
        public TopicsRepository(BioRepositoryContext<Topic> repositoryContext,
            IMainSiteSelectionPolicy mainSiteSelectionPolicy) : base(repositoryContext, mainSiteSelectionPolicy)
        {
        }
    }
}
