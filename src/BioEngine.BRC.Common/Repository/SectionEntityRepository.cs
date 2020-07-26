using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities.Abstractions;
using BioEngine.BRC.Common.Validation;
using FluentValidation.Results;
using Sitko.Core.Repository.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Repository
{
    public abstract class SectionEntityRepository<TEntity> : ContentEntityRepository<TEntity>
        where TEntity : class, ISectionEntity, IContentEntity
    {
        protected readonly SectionsRepository SectionsRepository;


        protected SectionEntityRepository(EFRepositoryContext<TEntity, Guid, BioContext> repositoryContext,
            SectionsRepository sectionsRepository) : base(repositoryContext)
        {
            SectionsRepository = sectionsRepository;
        }

        protected override void RegisterValidators()
        {
            base.RegisterValidators();
            Validators.Add(new SectionEntityValidator<TEntity>());
        }

        protected override async Task<bool> BeforeValidateAsync(TEntity item,
            (bool isValid, IList<ValidationFailure> errors) validationResult,
            bool isNew, CancellationToken cancellationToken = default)
        {
            var result = await base.BeforeValidateAsync(item, validationResult, isNew, cancellationToken);

            if (!result)
                return false;

            if (item.SectionIds != null && item.SectionIds.Any())
            {
                var sections = (await SectionsRepository.GetByIdsAsync(item.SectionIds, cancellationToken)).ToArray();

                if (sections.Any())
                {
                    item.SiteIds = sections.SelectMany(s => s.SiteIds).Distinct().ToArray();
                    if (item.SiteIds.Any())
                    {
                        return true;
                    }

                    validationResult.errors.Add(new ValidationFailure(nameof(ISiteEntity.SiteIds),
                        "Не найдены сайты"));
                }
                else
                {
                    validationResult.errors.Add(
                        new ValidationFailure(nameof(ISiteEntity.SiteIds), "Не найдены разделы"));
                }
            }
            else
            {
                validationResult.errors.Add(new ValidationFailure(nameof(ISectionEntity.SectionIds),
                    "Не указаны разделы"));
            }

            return false;
        }
    }
}
