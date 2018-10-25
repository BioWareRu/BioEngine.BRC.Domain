using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;
using BioEngine.Core.Users;

namespace BioEngine.BRC.Domain.Repository
{
    public class PostsRepository : ContentItemRepository<Post, int>
    {
        public PostsRepository(BioRepositoryContext<Post, int> repositoryContext, SectionsRepository sectionsRepository,
            IUserDataProvider userDataProvider = null) : base(repositoryContext, sectionsRepository, userDataProvider)
        {
        }
    }
}