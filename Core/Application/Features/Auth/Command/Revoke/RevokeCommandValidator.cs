using FluentValidation;

namespace Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandValidator:AbstractValidator<RevokeCommandRequest>
    {
        public RevokeCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
