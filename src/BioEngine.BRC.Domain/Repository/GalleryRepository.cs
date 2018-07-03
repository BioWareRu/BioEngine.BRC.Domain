using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public class GalleryRepository : SectionEntityRepository<Gallery, int>
    {
        public GalleryRepository(BioRepositoryContext<Gallery, int> repositoryContext, SitesRepository sitesRepository, SectionsRepository sectionsRepository)
            : base(repositoryContext, sitesRepository, sectionsRepository)
        {
        }
    }
}