using StackExchange.Redis;

namespace BookingServices.Core.Redis;
public class RedisService
{
    private readonly ConnectionMultiplexer _connection;

    public RedisService(string connectionString,Action<ConfigurationOptions> options)
    {
        _connection = ConnectionMultiplexer.Connect(connectionString, options);
    }
    
    public IDatabase GetDatabase()
    {
        return _connection.GetDatabase();
    }
}
