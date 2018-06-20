using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public class FilesRepository : SectionEntityRepository<File, int>
    {

        internal FilesRepository(BioRepositoryContext<File, int> repositoryContext) : base(repositoryContext)
        {
        }
    }
}