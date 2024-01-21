
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
    public class GoogleConfigurations
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
    public class AWSS3Configurations
    {
        public string AwsAccessKey { get; set; }
        public string AwsSecretAccessKey { get; set; }
        public string AwsSessionToken { get; set; }
        public string BucketName { get; set; }
        public string Region { get; set; }
        public string Url { get; set; }
    }
    public class EmailConfigurations
    {
        public string From { get; set; }
        public string FromName { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
