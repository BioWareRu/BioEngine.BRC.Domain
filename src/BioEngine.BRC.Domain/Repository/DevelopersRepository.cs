using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public class DevelopersRepository : SiteEntityRepository<Developer, int>
    {
        internal DevelopersRepository(BioRepositoryContext<Developer, int> repositoryContext) : base(repositoryContext)
        {
        }
    }
}