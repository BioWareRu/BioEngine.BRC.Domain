using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Validation;
using FluentValidation;

namespace BioEngine.BRC.Domain.Validation
{
    public class DeveloperValidator : SectionValidator<Developer, int>
    {
        public DeveloperValidator() : base()
        {
            RuleFor(d => d.Title).NotEmpty();
        }
    }
}