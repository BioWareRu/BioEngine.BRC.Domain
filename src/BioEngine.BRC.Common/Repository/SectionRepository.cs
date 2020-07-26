using System;
using BioEngine.BRC.Common.Entities;
using Sitko.Core.Repository.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Repository
{
    public abstract class SectionRepository<TEntity> : ContentEntityRepository<TEntity> where TEntity : Section
    {
        protected SectionRepository(EFRepositoryContext<TEntity, Guid, BioContext> repositoryContext) : base(
            repositoryContext)
        {
        }
    }
}
