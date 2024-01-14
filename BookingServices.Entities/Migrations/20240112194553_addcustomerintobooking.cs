using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingServices.Entities.Migrations
{
    /// <inheritdoc />
    public partial class addcustomerintobooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_CreatedBy",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CreatedBy",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0ac4a5b1-1b4e-457d-8198-8b7885115714"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3d2dabca-da93-4aba-af5d-37016e2f68b1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6b285584-7296-4206-abea-979d8d96f9c5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa2d65ea-c810-413e-b9a1-011c722f9ca9"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Bookings",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "CustomerId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("47813f84-eb93-4cbb-9a0d-c16f09ac7450"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Staff", "rrAgYtacwlxd9AzPPjAdFS8v+HUYd21D+d6L4Q7eRuRTV0ClrNYaFUSER/FfpQ8F", 3, "staff" },
                    { new Guid("71362a6a-ad93-4090-b500-50e03729fed5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Manager", "XJWoctD69RFI+AhPeD+nJifKfcUt53iUemF2oHYC22c3TemXIGSvlronubSdOfjU", 2, "manager" },
                    { new Guid("7d32e708-1489-4530-966b-228fcc7a34dc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Admin", "QbxUjxRczolN1yDhqL5vVwgBO1KP/hU7fIzbXWUjPi9rNpaZ8O/WkZsj92t640yE", 1, "admin" },
                    { new Guid("c317cfa8-98ba-4abc-aeb1-a0a155bbf4fe"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Customer", "xExlUQhywyfccBSqryM3s8Xyz0wkkHtUQUFC/09HpNlw+JIFuYpPHWjWVqQWufuy", 4, "customer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("47813f84-eb93-4cbb-9a0d-c16f09ac7450"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("71362a6a-ad93-4090-b500-50e03729fed5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7d32e708-1489-4530-966b-228fcc7a34dc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c317cfa8-98ba-4abc-aeb1-a0a155bbf4fe"));

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Bookings");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_CreatedBy",
                table: "Bookings",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
