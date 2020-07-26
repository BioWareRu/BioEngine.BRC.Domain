using BioEngine.BRC.Common.Entities.Abstractions;
using FluentValidation;

namespace BioEngine.BRC.Common.Validation
{
    public class EntityValidator : AbstractValidator<IBioEntity>
    {
        public EntityValidator()
        {
            RuleFor(e => e.DateAdded).NotNull();
            RuleFor(e => e.DateUpdated).NotNull();
        }
    }
}
