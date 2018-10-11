using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Validation;
using FluentValidation;
using JetBrains.Annotations;

namespace BioEngine.BRC.Domain.Validation
{
    [UsedImplicitly]
    public class DeveloperValidator : SectionValidator<Developer, int>
    {
        public DeveloperValidator()
        {
            RuleFor(d => d.Title).NotEmpty();
        }
    }
}