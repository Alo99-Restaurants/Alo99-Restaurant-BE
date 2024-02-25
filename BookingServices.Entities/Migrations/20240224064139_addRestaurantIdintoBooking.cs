using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingServices.Entities.Migrations
{
    /// <inheritdoc />
    public partial class addRestaurantIdintoBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "Bookings",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b8f3715-3af2-453d-b235-d60d8e344eac"),
                column: "Password",
                value: "dXVxGWOipuMHL7aLth39mbWvFtL5fAwtk3Vrbucyfw6tiQptxDukJI46Fii7Vs9Y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("397ba1f1-c2ff-4bdf-8d59-4a6c37ca30c6"),
                column: "Password",
                value: "WIt4fYVwkkzAbO8wN6P+6w+1Oy/R4coVTmrktSOMGmIeqpQtsNpE7a0supM5zBmx");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8da5e99c-7eb2-4a48-9b6f-6b9c58837294"),
                column: "Password",
                value: "EaBT0YPQtfV0JxlnIFSzQpvXtwOSDIoHmgDBLlpMqidfSdtnDNcDHmLQNt+IBoKU");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("be809c8a-b2d4-4654-b5ef-7bb99f3af3b5"),
                column: "Password",
                value: "t2j2t1IVr9IKC1vQsgndbKHGP5E13z3u65iMQowwS/ni7HPGQP332CXjf+FFY/TQ");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RestaurantId",
                table: "Bookings",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Restaurants_RestaurantId",
                table: "Bookings",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Restaurants_RestaurantId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RestaurantId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b8f3715-3af2-453d-b235-d60d8e344eac"),
                column: "Password",
                value: "k91V/Hc4yzWbtZcjR4z0rIJROS6HkB6mD/NyJFdKGakn9dVPWBRDN2M1VY2XaxII");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("397ba1f1-c2ff-4bdf-8d59-4a6c37ca30c6"),
                column: "Password",
                value: "eq9wNhJMBQmBF9sWPbgTGuiKWEZF5H/8ZVP/9QkaZI3OtPpsyMksI3qW1Wblcf50");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8da5e99c-7eb2-4a48-9b6f-6b9c58837294"),
                column: "Password",
                value: "/P8KRQJeUwPjmD6WpnxRKH1GWqdGkWisnzuoRofmHIqrYl5XEtnCHwctr1mqN53I");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("be809c8a-b2d4-4654-b5ef-7bb99f3af3b5"),
                column: "Password",
                value: "jhfREuJ1Cm/cc/IiOeS8VnNbHli/tmrIMBV5SORtEOaE2j+QbonyhTBILpCzTxys");
        }
    }
}
