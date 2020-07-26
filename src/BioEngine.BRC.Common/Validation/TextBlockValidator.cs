using BioEngine.BRC.Common.Entities.Blocks;
using FluentValidation;
using JetBrains.Annotations;

namespace BioEngine.BRC.Common.Validation
{
    [UsedImplicitly]
    public class TextBlockValidator : AbstractValidator<TextBlock>
    {
        public TextBlockValidator()
        {
            RuleFor(p => p.Data.Text).MinimumLength(250).WithMessage("Текст поста не должен быть меньше 250 символов.");
        }
    }
}
