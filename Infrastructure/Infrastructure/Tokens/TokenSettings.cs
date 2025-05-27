namespace Infrastructure.Tokens
{
    public class TokenSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int TokenExpirationInMinutes { get; set; }
        public string SecretKey { get; set; }

    }
}
