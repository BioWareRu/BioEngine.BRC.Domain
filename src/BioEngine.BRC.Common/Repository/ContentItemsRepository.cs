using System;
using BioEngine.BRC.Common.Entities.Abstractions;
using Sitko.Core.Repository.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Repository
{
    public class ContentItemsRepository : SectionEntityRepository<IContentItem>
    {
        public ContentItemsRepository(EFRepositoryContext<IContentItem, Guid, BioContext> repositoryContext,
            SectionsRepository sectionsRepository) : base(repositoryContext, sectionsRepository)
        {
        }
    }
}
