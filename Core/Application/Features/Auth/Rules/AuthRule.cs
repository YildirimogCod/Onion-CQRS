using Application.Bases;
using Application.Features.Auth.Exceptions;
using Domain.Entities;

namespace Application.Features.Auth.Rules
{
    public class AuthRule : BaseRule
    {
        public Task UserShouldNotBeExis(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }

        public Task EmailOrPasswordShoulNotBeInvalid(User? user, bool checkPassword)
        {
            if (user is null || !checkPassword)
            {
                throw new EmailOrPasswordShoulNotBeInvalidException();
            }

            return Task.CompletedTask;
        }

        public Task EmailAdressSouldBeValid(User? user)
        {
            if (user is null || string.IsNullOrEmpty(user.Email))
            {
                throw new EmailAddressShouldBeValidException();
            }

           return Task.CompletedTask;
        }
    }
}
