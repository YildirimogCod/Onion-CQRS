using FluentValidation;

namespace Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator:AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2)
                .WithName("Name Surname");
            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(8)
                .EmailAddress()
                .WithName("E-mail");
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .WithName("Password");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MinimumLength(8)
                .WithName("Confirm Password")
                .Equal(x => x.Password)
                .WithMessage("Password and Confirm Password must be the same.");

        }
    }
}
