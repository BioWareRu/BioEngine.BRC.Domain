using BioEngine.BRC.Domain.Entities;
using FluentValidation;
using JetBrains.Annotations;

namespace BioEngine.BRC.Domain.Validation
{
    [UsedImplicitly]
    public class DeveloperValidator : AbstractValidator<Developer>
    {
        public DeveloperValidator()
        {
            RuleFor(d => d.Title).NotEmpty();
        }
    }
}