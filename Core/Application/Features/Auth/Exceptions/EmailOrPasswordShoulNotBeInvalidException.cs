using Application.Bases;

namespace Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShoulNotBeInvalidException:BaseException
    {
        public EmailOrPasswordShoulNotBeInvalidException() : base("Invalid email or password.")
        {

        }
    }
}
