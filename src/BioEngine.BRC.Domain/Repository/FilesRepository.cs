using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public class FilesRepository : SectionEntityRepository<File, int>
    {
        public FilesRepository(BioRepositoryContext<File, int> repositoryContext, SitesRepository sitesRepository, SectionsRepository sectionsRepository) :
            base(repositoryContext, sitesRepository, sectionsRepository)
        {
        }
    }
}