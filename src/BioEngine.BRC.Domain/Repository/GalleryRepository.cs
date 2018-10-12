using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public class GalleryRepository : ContentItemRepository<Gallery, int>
    {
        public GalleryRepository(BioRepositoryContext<Gallery, int> repositoryContext, SectionsRepository sectionsRepository) : base(repositoryContext, sectionsRepository)
        {
        }
    }
}