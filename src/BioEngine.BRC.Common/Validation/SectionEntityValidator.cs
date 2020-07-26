using BioEngine.BRC.Common.Entities.Abstractions;
using FluentValidation;

namespace BioEngine.BRC.Common.Validation
{
    public sealed class SectionEntityValidator<T> : AbstractValidator<T>
        where T : ISiteEntity, ISectionEntity
    {
        public SectionEntityValidator()
        {
            RuleFor(e => e.SectionIds).NotEmpty();
        }
    }
}
