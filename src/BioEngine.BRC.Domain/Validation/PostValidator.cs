using BioEngine.BRC.Domain.Entities;
using FluentValidation;
using JetBrains.Annotations;

namespace BioEngine.BRC.Domain.Validation
{
    [UsedImplicitly]
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(p => p.Data.Text).MinimumLength(250).WithMessage("Текст поста не должен быть меньше 250 символов.");
        }
    }
}