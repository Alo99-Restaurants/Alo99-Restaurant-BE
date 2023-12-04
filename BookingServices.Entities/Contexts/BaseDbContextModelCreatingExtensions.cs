using BookingServices.Core;
using BookingServices.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingServices.Entities.Contexts
{
    public static class BaseDbContextModelCreatingExtensions
    {
        public static void ConfigureBaseService(this ModelBuilder builder)
        {
            builder.Entity<Users>().HasData(
                new Users
                {
                    Id = Guid.NewGuid(),
                    Username = "admin",
                    Password = Utils.HashPassword("admin"),
                    Name = "Admin",
                    IsCustomer = false,
                    Role = Enum.ERole.Admin
                },
                new Users
                {
                    Id = Guid.NewGuid(),
                    Username = "manager",
                    Password = Utils.HashPassword("manager"),
                    Name = "Manager",
                    IsCustomer = false,
                    Role = Enum.ERole.Manager
                },
                new Users
                {
                    Id = Guid.NewGuid(),
                    Username = "staff",
                    Password = Utils.HashPassword("staff"),
                    Name = "Staff",
                    IsCustomer = false,
                    Role = Enum.ERole.Staff
                },
                new Users
                {
                    Id = Guid.NewGuid(),
                    Username = "customer",
                    Password = Utils.HashPassword("customer"),
                    Name = "Customer",
                    IsCustomer = true,
                    Role = Enum.ERole.Customer
                }
            );
                
        }
    }

}
