using Application.Bases;

namespace Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException:BaseException
    {
        public UserAlreadyExistException() : base("User already exists.")
        {
        }
    }
}
