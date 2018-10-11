using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public class FilesRepository : SectionEntityRepository<File, int>
    {
        public FilesRepository(BioRepositoryContext<File, int> repositoryContext, SectionsRepository sectionsRepository) :
            base(repositoryContext, sectionsRepository)
        {
        }
    }
}