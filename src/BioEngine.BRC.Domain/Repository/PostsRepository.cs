using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public class PostsRepository : SectionEntityRepository<Post, int>
    {
        public PostsRepository(BioRepositoryContext<Post, int> repositoryContext, SitesRepository sitesRepository,
            SectionsRepository sectionsRepository) :
            base(repositoryContext, sitesRepository, sectionsRepository)
        {
        }
    }
}