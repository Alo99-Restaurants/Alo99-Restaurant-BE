
public class AppConfigurations
{
    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }
    public class JwtConfigurations
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationMinutes { get; set; }
    }
    public class RedisConfigurations
    {
        public string ConnectionString { get; set; }
    }
}
