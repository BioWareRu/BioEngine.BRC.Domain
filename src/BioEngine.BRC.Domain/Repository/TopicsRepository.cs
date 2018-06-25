using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public class TopicsRepository:BioRepository<Topic,int>
    {
        public TopicsRepository(BioRepositoryContext<Topic, int> repositoryContext) : base(repositoryContext)
        {
        }
    }
}