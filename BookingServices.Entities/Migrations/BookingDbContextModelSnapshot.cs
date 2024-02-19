﻿// <auto-generated />
using System;
using BookingServices.Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookingServices.Entities.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    partial class BookingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BookingServices.Entities.Entities.BookingMenu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Quantity")
                        .HasColumnType("double");

                    b.Property<string>("SpecialRequest")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("BookingMenu");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.Bookings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("BookingStatusId")
                        .HasColumnType("int");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<Guid>("TableId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TableId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.Customers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.MenuCategories", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IconUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MenuCategories");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.MenuImages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("MenuImages");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.Others.EntityHistories", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ActionBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EntityChangeData")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EntityId")
                        .HasColumnType("longtext");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RequestId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("EntityHistories");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.Others.Stogares", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Stogares");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.RestaurantFloors", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ExtensionData")
                        .HasColumnType("longtext");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LayoutUrl")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantFloors");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.RestaurantImages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantImages");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.RestaurantInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<TimeOnly>("CloseTime")
                        .HasColumnType("time(6)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("ExtensionData")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<TimeOnly>("OpenTime")
                        .HasColumnType("time(6)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Website")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("RestaurantInformation");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.RestaurantMenu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("MenuCategoryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("MenuUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("UnitType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuCategoryId");

                    b.ToTable("RestaurantMenu");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.Restaurants", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("CloseHours")
                        .HasColumnType("longtext");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Greetings")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OpenHours")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalFloors")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.Tables", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ExtensionData")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("RestaurantFloorId")
                        .HasColumnType("char(36)");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TableType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantFloorId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique()
                        .HasFilter("[Role] = 4");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("be809c8a-b2d4-4654-b5ef-7bb99f3af3b5"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Admin",
                            Password = "7b3D0P5Ja+DmOSs+kHRSG4dH/E+xNqEppd4AS/Pp6sBOu/kqPAkLYlUhLuqWwjiW",
                            Role = 1,
                            Username = "admin"
                        },
                        new
                        {
                            Id = new Guid("397ba1f1-c2ff-4bdf-8d59-4a6c37ca30c6"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Manager",
                            Password = "O9UMNlWajPe+bTgXXg5SUup43IxoptsbDx0FuATSVy8KflkqtiIDB2WoFJStSb0j",
                            Role = 2,
                            Username = "manager"
                        },
                        new
                        {
                            Id = new Guid("8da5e99c-7eb2-4a48-9b6f-6b9c58837294"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Staff",
                            Password = "gBE6DkzYgJdpvIfbUlIjjd9Ss/8AoiR65aS6YYr6ro9iL/agDbdG82IWKVJENLh2",
                            Role = 3,
                            Username = "staff"
                        },
                        new
                        {
                            Id = new Guid("2b8f3715-3af2-453d-b235-d60d8e344eac"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Customer",
                            Password = "2CJZFcC1YQpu/HvDH+J7hEekUneMqG2VvxxferQA26LDdO9RaDTab3KpMG3R566c",
                            Role = 4,
                            Username = "customer"
                        });
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.BookingMenu", b =>
                {
                    b.HasOne("BookingServices.Entities.Entities.Bookings", "Booking")
                        .WithMany("BookingMenu")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingServices.Entities.Entities.RestaurantMenu", "RestaurantMenu")
                        .WithMany("BookingMenu")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("RestaurantMenu");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.Bookings", b =>
                {
                    b.HasOne("BookingServices.Entities.Entities.Customers", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("BookingServices.Entities.Entities.Tables", "Table")
                        .WithMany("Bookings")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.MenuImages", b =>
                {
                    b.HasOne("BookingServices.Entities.Entities.RestaurantMenu", "RestaurantMenu")
                        .WithMany("MenuImages")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RestaurantMenu");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.RestaurantFloors", b =>
                {
                    b.HasOne("BookingServices.Entities.Entities.Restaurants", "Restaurant")
                        .WithMany("RestaurantFloors")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.RestaurantImages", b =>
                {
                    b.HasOne("BookingServices.Entities.Entities.Restaurants", "Restaurants")
                        .WithMany("RestaurantImages")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.RestaurantMenu", b =>
                {
                    b.HasOne("BookingServices.Entities.Entities.MenuCategories", "MenuCategory")
                        .WithMany("RestaurantMenu")
                        .HasForeignKey("MenuCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuCategory");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.Tables", b =>
                {
                    b.HasOne("BookingServices.Entities.Entities.RestaurantFloors", "RestaurantFloor")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantFloorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RestaurantFloor");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.Users", b =>
                {
                    b.HasOne("BookingServices.Entities.Entities.Customers", "Customer")
                        .WithOne("User")
                        .HasForeignKey("BookingServices.Entities.Entities.Users", "CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.Bookings", b =>
                {
                    b.Navigation("BookingMenu");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.Customers", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.MenuCategories", b =>
                {
                    b.Navigation("RestaurantMenu");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.RestaurantFloors", b =>
                {
                    b.Navigation("Tables");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.RestaurantMenu", b =>
                {
                    b.Navigation("BookingMenu");

                    b.Navigation("MenuImages");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.Restaurants", b =>
                {
                    b.Navigation("RestaurantFloors");

                    b.Navigation("RestaurantImages");
                });

            modelBuilder.Entity("BookingServices.Entities.Entities.Tables", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
