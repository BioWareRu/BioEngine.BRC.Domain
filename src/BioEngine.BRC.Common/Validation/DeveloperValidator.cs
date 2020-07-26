using BioEngine.BRC.Common.Entities;
using FluentValidation;
using JetBrains.Annotations;

namespace BioEngine.BRC.Common.Validation
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