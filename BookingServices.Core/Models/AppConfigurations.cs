namespace BookingServices.Core.Models;

public class AppConfigurations
{
    public class JwtConfigurations
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
