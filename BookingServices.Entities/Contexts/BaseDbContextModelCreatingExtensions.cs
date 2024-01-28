using BookingServices.Core;
using BookingServices.Entities.Entities;
using BookingServices.Entities.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookingServices.Entities.Contexts;

public static class BaseDbContextModelCreatingExtensions
{
    public static void ConfigureBaseService(this ModelBuilder builder)
    {
        builder.Entity<Users>()
            .HasIndex(u => u.CustomerId)
            .HasFilter("[Role] = 4") // Assuming ERole.Customer is mapped to 1
            .IsUnique();

        foreach (var entityType in builder.Model.GetEntityTypes())
        {

            if (typeof(IHaveDeleted).IsAssignableFrom(entityType.ClrType))
            {
                builder.Entity(entityType.ClrType).HasQueryFilter(GetDeletedFilter(entityType.ClrType));
            }
        }
        SeedData(builder);
    }

    private static LambdaExpression? GetDeletedFilter(Type clrType)
    {
        // EF.Property<bool>(e, "IsDeleted") == false
        var entity = Expression.Parameter(clrType, "e");
        var property = Expression.Property(entity, "IsDeleted");
        var propertyType = property.Type;
        var falseValue = Expression.Constant(false, propertyType);
        var equalExpression = Expression.Equal(property, falseValue);
        return Expression.Lambda(equalExpression, entity);
    }
    private static void SeedData(ModelBuilder builder)
    {

        if (true)
        {
            #region insert data
            builder.Entity<Users>().HasData(
                new Users
                {
                    Id = Guid.Parse("be809c8a-b2d4-4654-b5ef-7bb99f3af3b5"),
                    Username = "admin",
                    Password = Utils.HashPassword("admin"),
                    Name = "Admin",
                    Role = Enum.ERole.Admin
                },
                new Users
                {
                    Id = Guid.Parse("397ba1f1-c2ff-4bdf-8d59-4a6c37ca30c6"),
                    Username = "manager",
                    Password = Utils.HashPassword("manager"),
                    Name = "Manager",
                    Role = Enum.ERole.Manager
                },
                new Users
                {
                    Id = Guid.Parse("8da5e99c-7eb2-4a48-9b6f-6b9c58837294"),
                    Username = "staff",
                    Password = Utils.HashPassword("staff"),
                    Name = "Staff",
                    Role = Enum.ERole.Staff,
                },
                new Users
                {
                    Id = Guid.Parse("2b8f3715-3af2-453d-b235-d60d8e344eac"),
                    Username = "customer",
                    Password = Utils.HashPassword("customer"),
                    Name = "Customer",
                    Role = Enum.ERole.Customer
                }
            );
            #endregion
        }

    }
}
