using BioEngine.BRC.Common.Entities.Abstractions;
using FluentValidation;
using JetBrains.Annotations;

namespace BioEngine.BRC.Common.Validation
{
    [UsedImplicitly]
    internal class SiteEntityValidator<T> : AbstractValidator<T> where T : ISiteEntity
    {
        public SiteEntityValidator()
        {
            RuleFor(e => e.SiteIds).NotEmpty();
        }
    }
}
