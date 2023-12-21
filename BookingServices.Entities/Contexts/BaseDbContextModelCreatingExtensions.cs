using BookingServices.Core;
using BookingServices.Entities.Entities;
using BookingServices.Entities.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System.Linq.Expressions;
using System.Reflection.Emit;

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
        #region insert data
        builder.Entity<Users>().HasData(
            new Users
            {
                Id = Guid.NewGuid(),
                Username = "admin",
                Password = Utils.HashPassword("admin"),
                Name = "Admin",
                Role = Enum.ERole.Admin
            },
            new Users
            {
                Id = Guid.NewGuid(),
                Username = "manager",
                Password = Utils.HashPassword("manager"),
                Name = "Manager",
                Role = Enum.ERole.Manager
            },
            new Users
            {
                Id = Guid.NewGuid(),
                Username = "staff",
                Password = Utils.HashPassword("staff"),
                Name = "Staff",
                Role = Enum.ERole.Staff,
            },
            new Users
            {
                Id = Guid.NewGuid(),
                Username = "customer",
                Password = Utils.HashPassword("customer"),
                Name = "Customer",                
                Role = Enum.ERole.Customer
            }
        );
        #endregion

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
}
