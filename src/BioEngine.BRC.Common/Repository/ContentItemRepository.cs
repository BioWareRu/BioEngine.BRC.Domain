using System;
using BioEngine.BRC.Common.Entities.Abstractions;
using Sitko.Core.Repository;
using Sitko.Core.Repository.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Repository
{
    public abstract class ContentItemRepository<TEntity> : SectionEntityRepository<TEntity>
        where TEntity : class, IContentItem, IEntity, ISiteEntity, ISectionEntity
    {
        protected ContentItemRepository(EFRepositoryContext<TEntity, Guid, BioContext> repositoryContext,
            SectionsRepository sectionsRepository) : base(repositoryContext, sectionsRepository)
        {
        }
    }
}
