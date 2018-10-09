using BioEngine.BRC.Domain.Entities;
using BioEngine.Core.Validation;
using FluentValidation;

namespace BioEngine.BRC.Domain.Validation
{
    public class PostValidator : ContentValidator<Post, int>
    {
        public PostValidator()
        {
            RuleFor(p => p.Data.Text).MinimumLength(250).WithMessage("Текст поста не должен быть меньше 250 символов.");
        }
    }
}