using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public class TopicsRepository : SiteEntityRepository<Topic>
    {
        public TopicsRepository(BioRepositoryContext<Topic> repositoryContext) : base(repositoryContext)
        {
        }
    }
}
