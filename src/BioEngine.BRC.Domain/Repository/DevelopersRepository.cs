using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public class DevelopersRepository : SectionRepository<Developer>
    {
        public DevelopersRepository(BioRepositoryContext<Developer> repositoryContext) : base(repositoryContext)
        {
        }
    }
}
