using System;
using BioEngine.BRC.Common.Entities.Abstractions;
using BioEngine.BRC.Common.Validation;
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

        protected override void RegisterValidators()
        {
            base.RegisterValidators();
            // Validators.Add(new ContentItemValidator<TEntity>(Set<TEntity>())); TODO: FIX ORDER
        }
    }
}
