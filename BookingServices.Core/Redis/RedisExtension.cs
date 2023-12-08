using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Core.Redis;

public static class RedisExtension
{
    public static T GetKeySetNotExist<T>(this IDatabase db, string key, Func<T> generateNewData)
    {
        // Get data from Redis
        T data = db.StringGet(key).ToString().ToObject<T>();

        if (EqualityComparer<T>.Default.Equals(data, default(T)))
        {
            // Data doesn't exist in Redis, run the action to set the data
            T newData = generateNewData();
            db.StringSet(key, newData.ToString());

            // Return the newly set data
            return newData;
        }
        else
        {
            // Data exists in Redis, return it
            return data;
        }
    }
    public static T ToObject<T>(this string value)
    {
        // Add your own conversion logic here, e.g., using JsonConvert from Newtonsoft.Json
        return (T)Convert.ChangeType(value, typeof(T));
    }
}
