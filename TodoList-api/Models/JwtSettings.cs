namespace ApiFuncional.Models
{
    public class JwtSettings
    {
        public string? SecretKey { get; set; }
        public int ExpirationTime { get; set; }
        public string? Issuer { get; set; }
        public string? Listener { get; set; }
    }
}
