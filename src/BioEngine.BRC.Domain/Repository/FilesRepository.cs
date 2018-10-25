using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;
using BioEngine.Core.Users;

namespace BioEngine.BRC.Domain.Repository
{
    public class FilesRepository : ContentItemRepository<File, int>
    {
        public FilesRepository(BioRepositoryContext<File, int> repositoryContext, SectionsRepository sectionsRepository,
            IUserDataProvider userDataProvider = null) :
            base(repositoryContext, sectionsRepository, userDataProvider)
        {
        }
    }
}