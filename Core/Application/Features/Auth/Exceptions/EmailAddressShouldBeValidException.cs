using Application.Bases;

namespace Application.Features.Auth.Exceptions
{
    public class EmailAddressShouldBeValidException:BaseException
    {
        public EmailAddressShouldBeValidException() : base("Email address should be valid.")
        {
        }
     
    }
}
