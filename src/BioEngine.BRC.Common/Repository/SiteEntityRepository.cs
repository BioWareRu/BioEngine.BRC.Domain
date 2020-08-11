using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Entities.Abstractions;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Sitko.Core.Repository.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Repository
{
    public abstract class SiteEntityRepository<TEntity> : EFRepository<TEntity, Guid, BioContext>
        where TEntity : class, ISiteEntity, IBioEntity
    {
        protected SiteEntityRepository(EFRepositoryContext<TEntity, Guid, BioContext> repositoryContext)
            : base(repositoryContext)
        {
        }


        protected override async Task<bool> BeforeValidateAsync(TEntity item,
            (bool isValid, IList<ValidationFailure> errors) validationResult, bool isNew,
            CancellationToken cancellationToken = default)
        {
            if (item.SiteIds.Length == 0)
            {
                var sites = await Set<Site>().ToListAsync(cancellationToken);
                if (sites.Count == 1)
                {
                    item.SiteIds = new[] {sites.First().Id};
                }
            }

            return await base.BeforeValidateAsync(item, validationResult, isNew, cancellationToken);
        }
    }
}
