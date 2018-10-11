using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public class PostsRepository : SectionEntityRepository<Post, int>
    {
        public PostsRepository(BioRepositoryContext<Post, int> repositoryContext, SectionsRepository sectionsRepository) : base(repositoryContext, sectionsRepository)
        {
        }
    }
}