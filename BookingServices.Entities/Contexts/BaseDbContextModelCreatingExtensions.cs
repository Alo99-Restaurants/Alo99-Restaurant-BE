using BookingServices.Core;
using BookingServices.Entities.Entities;
using Microsoft.EntityFrameworkCore;
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

    }
}
