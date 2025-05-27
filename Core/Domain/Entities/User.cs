using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User:IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
