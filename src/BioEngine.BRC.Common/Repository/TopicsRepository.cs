using System;
using BioEngine.BRC.Common.Entities;
using Sitko.Core.Repository.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Repository
{
    public class TopicsRepository : SectionRepository<Topic>
    {
        public TopicsRepository(EFRepositoryContext<Topic, Guid, BioContext> repositoryContext) : base(
            repositoryContext)
        {
        }
    }
}
