using System.Linq.Expressions;

namespace BookingServices.Core;

public static class CustomLinqExtensions
{
    public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> predicate)
    {
        if (condition)
        {
            return source.Where(predicate);
        }
        return source;
    }
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, Expression<Func<T, bool>> predicate)
    {
        if (condition)
        {
            return source.Where(predicate);
        }

        return source;
    }
    public static IQueryable<T> ActiveEntities<T>(this IQueryable<T> entities)
    {
        try
        {
            var entityType = typeof(T);

            if (entityType.GetProperty("IsDeleted") != null)
            {
                entities.Where(e => !(bool)entityType.GetProperty("IsDeleted").GetValue(e));
            }

        }
        catch
        {

        }
        return entities;

    }
}
