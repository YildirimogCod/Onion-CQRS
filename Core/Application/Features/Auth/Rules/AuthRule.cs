using Application.Bases;
using Application.Features.Auth.Exceptions;
using Domain.Entities;

namespace Application.Features.Auth.Rules
{
    public class AuthRule:BaseRule
    {
        public Task UserShouldNotBeExis(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }
    }
}
