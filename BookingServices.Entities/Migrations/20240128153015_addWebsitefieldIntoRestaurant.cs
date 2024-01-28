using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingServices.Entities.Migrations
{
    /// <inheritdoc />
    public partial class addWebsitefieldIntoRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Restaurants",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b8f3715-3af2-453d-b235-d60d8e344eac"),
                column: "Password",
                value: "93+cyVZQSIaQuwNhJ9RBnqxdfrY2lpPG2fGp8wYROfBQF578N2jh4p0/n2/aPK3G");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("397ba1f1-c2ff-4bdf-8d59-4a6c37ca30c6"),
                column: "Password",
                value: "ZZ080k5iLYx2yp1AI4sOx1IgOr5jAo1YYjWBHGa0Ep3o5kGt+Q1InlqMeSA5C567");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8da5e99c-7eb2-4a48-9b6f-6b9c58837294"),
                column: "Password",
                value: "j9ufpj11GerQu5yFdHg/pFj7LLmJfBwZfRv7AzL+TpT2cERVMeEa96uSefItN3JS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("be809c8a-b2d4-4654-b5ef-7bb99f3af3b5"),
                column: "Password",
                value: "NimJ063a38DLwwRDBLmXkT9t0hMe+0tNHwteOgAR26ahI1x7fB3ZfEkgdIAZxtY4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Website",
                table: "Restaurants");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b8f3715-3af2-453d-b235-d60d8e344eac"),
                column: "Password",
                value: "jw+V3fpbisV4KTfx5ZsxDeYAgmDYI6ru8yD23KuRhtYARnFZX84iKy0eGDTNzkzC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("397ba1f1-c2ff-4bdf-8d59-4a6c37ca30c6"),
                column: "Password",
                value: "TsMMMynSJrzQaC4ePvO85fNbFUo1f39gD8yEGqBqKpwZJq9VDzE/3pUEgO0dyh8Z");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8da5e99c-7eb2-4a48-9b6f-6b9c58837294"),
                column: "Password",
                value: "gsUebl6Sjm6Plq3yllcPjeO+Q6QeRWuDIanHt2dVSeA8nCE5CxL33Ae/8PP8urZk");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("be809c8a-b2d4-4654-b5ef-7bb99f3af3b5"),
                column: "Password",
                value: "qgPoFgrCzVRz5tsjd5gQa8oHbph1gQdCKzL/LsDIVZeUfuYniRhM4N3SoS5Aidoo");
        }
    }
}
