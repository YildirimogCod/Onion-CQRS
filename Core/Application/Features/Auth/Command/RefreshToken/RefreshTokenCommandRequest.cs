using MediatR;

namespace Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandRequest:IRequest<RefreshTokenCommandResponse>
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}
