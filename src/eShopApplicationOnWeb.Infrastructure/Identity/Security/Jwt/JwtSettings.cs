namespace eShopApplicationOnWeb.Infrastructure.Identity.Security.Jwt
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public int ExpiresInSeconds { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
