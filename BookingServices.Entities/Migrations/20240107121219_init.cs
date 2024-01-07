using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingServices.Entities.Migrations;

/// <inheritdoc />
public partial class init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Customers",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                Email = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Name = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Gender = table.Column<int>(type: "int", nullable: false),
                PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                ModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Customers", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "EntityHistories",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                RequestId = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                EntityName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                EntityId = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                EntityChangeData = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Action = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ActionBy = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ActionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EntityHistories", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "RestaurantInformation",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                RestaurantName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Website = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Email = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                OpenTime = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                CloseTime = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                ExtensionData = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                ModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RestaurantInformation", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Restaurants",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                Name = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Address = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Location = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Greetings = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                OpenHours = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CloseHours = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Capacity = table.Column<int>(type: "int", nullable: false),
                TotalFloors = table.Column<int>(type: "int", nullable: false),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                ModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Restaurants", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Stogares",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                Name = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Url = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CreatedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                ModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Stogares", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                Username = table.Column<string>(type: "varchar(255)", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Password = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Name = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CustomerId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                Role = table.Column<int>(type: "int", nullable: false),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                ModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
                table.ForeignKey(
                    name: "FK_Users_Customers_CustomerId",
                    column: x => x.CustomerId,
                    principalTable: "Customers",
                    principalColumn: "Id");
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "RestaurantFloors",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                RestaurantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                Name = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                FloorNumber = table.Column<int>(type: "int", nullable: false),
                Capacity = table.Column<int>(type: "int", nullable: false),
                LayoutUrl = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                ExtensionData = table.Column<string>(type: "longtext", nullable: true)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                ModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RestaurantFloors", x => x.Id);
                table.ForeignKey(
                    name: "FK_RestaurantFloors_Restaurants_RestaurantId",
                    column: x => x.RestaurantId,
                    principalTable: "Restaurants",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "RestaurantImages",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                Name = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Description = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Url = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                RestaurantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                CreatedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                ModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RestaurantImages", x => x.Id);
                table.ForeignKey(
                    name: "FK_RestaurantImages_Restaurants_RestaurantId",
                    column: x => x.RestaurantId,
                    principalTable: "Restaurants",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Tables",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                RestaurantFloorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                TableName = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TableType = table.Column<int>(type: "int", nullable: false),
                Capacity = table.Column<int>(type: "int", nullable: false),
                ExtensionData = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                ModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tables", x => x.Id);
                table.ForeignKey(
                    name: "FK_Tables_RestaurantFloors_RestaurantFloorId",
                    column: x => x.RestaurantFloorId,
                    principalTable: "RestaurantFloors",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Bookings",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                TableId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                BookingStatusId = table.Column<int>(type: "int", nullable: false),
                BookingDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                ModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Bookings", x => x.Id);
                table.ForeignKey(
                    name: "FK_Bookings_Tables_TableId",
                    column: x => x.TableId,
                    principalTable: "Tables",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Bookings_Users_CreatedBy",
                    column: x => x.CreatedBy,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "Id", "CreatedBy", "CreatedDate", "CustomerId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "Password", "Role", "Username" },
            values: new object[,]
            {
                { new Guid("0ac4a5b1-1b4e-457d-8198-8b7885115714"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Admin", "2hbDqy5ETiSMP3RWokGi3uXYDcjF88x+KGbOhpRkkBxYCikh0Qp+Qn/amWcxzVQG", 1, "admin" },
                { new Guid("3d2dabca-da93-4aba-af5d-37016e2f68b1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Manager", "Qn3UVkUllvtHBUXE/YY7EGdfEM3woLT+dAm4VK5nfe/QtNC7Ss12/da/2cbemeMk", 2, "manager" },
                { new Guid("6b285584-7296-4206-abea-979d8d96f9c5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Staff", "YMJE5Km2H9wuTHXneQis1Jl6/rV0PpurSBWVuCcvftctnFxeqFPc2cUOUOF+T1dB", 3, "staff" },
                { new Guid("aa2d65ea-c810-413e-b9a1-011c722f9ca9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Customer", "Nhw+PUuMhfY1dSr9VsdxopL6337BjpVe1kCQrhRBiHMPCuhUzTdC7GVsrtxzMvs1", 4, "customer" }
            });

        migrationBuilder.CreateIndex(
            name: "IX_Bookings_CreatedBy",
            table: "Bookings",
            column: "CreatedBy");

        migrationBuilder.CreateIndex(
            name: "IX_Bookings_TableId",
            table: "Bookings",
            column: "TableId");

        migrationBuilder.CreateIndex(
            name: "IX_RestaurantFloors_RestaurantId",
            table: "RestaurantFloors",
            column: "RestaurantId");

        migrationBuilder.CreateIndex(
            name: "IX_RestaurantImages_RestaurantId",
            table: "RestaurantImages",
            column: "RestaurantId");

        migrationBuilder.CreateIndex(
            name: "IX_Tables_RestaurantFloorId",
            table: "Tables",
            column: "RestaurantFloorId");

        migrationBuilder.CreateIndex(
            name: "IX_Users_CustomerId",
            table: "Users",
            column: "CustomerId",
            unique: true,
            filter: "[Role] = 4");

        migrationBuilder.CreateIndex(
            name: "IX_Users_Username",
            table: "Users",
            column: "Username",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Bookings");

        migrationBuilder.DropTable(
            name: "EntityHistories");

        migrationBuilder.DropTable(
            name: "RestaurantImages");

        migrationBuilder.DropTable(
            name: "RestaurantInformation");

        migrationBuilder.DropTable(
            name: "Stogares");

        migrationBuilder.DropTable(
            name: "Tables");

        migrationBuilder.DropTable(
            name: "Users");

        migrationBuilder.DropTable(
            name: "RestaurantFloors");

        migrationBuilder.DropTable(
            name: "Customers");

        migrationBuilder.DropTable(
            name: "Restaurants");
    }
}
