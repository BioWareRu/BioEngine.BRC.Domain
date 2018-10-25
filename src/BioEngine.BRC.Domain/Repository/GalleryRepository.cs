using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;
using BioEngine.Core.Users;

namespace BioEngine.BRC.Domain.Repository
{
    public class GalleryRepository : ContentItemRepository<Gallery, int>
    {
        public GalleryRepository(BioRepositoryContext<Gallery, int> repositoryContext,
            SectionsRepository sectionsRepository, IUserDataProvider userDataProvider = null) : base(repositoryContext,
            sectionsRepository, userDataProvider)
        {
        }
    }
}