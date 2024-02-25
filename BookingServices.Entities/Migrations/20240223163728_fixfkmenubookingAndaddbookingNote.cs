using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingServices.Entities.Migrations
{
    /// <inheritdoc />
    public partial class fixfkmenubookingAndaddbookingNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingMenu_Bookings_MenuId",
                table: "BookingMenu");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Bookings",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_BookingMenu_BookingId",
                table: "BookingMenu",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingMenu_Bookings_BookingId",
                table: "BookingMenu",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingMenu_Bookings_BookingId",
                table: "BookingMenu");

            migrationBuilder.DropIndex(
                name: "IX_BookingMenu_BookingId",
                table: "BookingMenu");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b8f3715-3af2-453d-b235-d60d8e344eac"),
                column: "Password",
                value: "8xMHM73g+d9xjinagVqPaeUGTdX7Cd48qZE+GN8/ZzWO+8KLdtfI4UkIsZnOUElL");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("397ba1f1-c2ff-4bdf-8d59-4a6c37ca30c6"),
                column: "Password",
                value: "U6FGSLuT2+act3Cn7KRk55uEVmIXIkDMDJzvJSby7+2ZBVpQGMYpE2A7CSaainUB");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8da5e99c-7eb2-4a48-9b6f-6b9c58837294"),
                column: "Password",
                value: "t4coThMJbhmlNoY8F2Kr39sFpgpLQzcCTgw7dRiMYkPU4fKGXC/vd0OsaZFYr/mF");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("be809c8a-b2d4-4654-b5ef-7bb99f3af3b5"),
                column: "Password",
                value: "sc8yD6n0ZX7MJMflMjfzdiPBW3Rx1ysMHJ1hpd4zSRsb2ZKv1NDZWAlMqx7dt/BL");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingMenu_Bookings_MenuId",
                table: "BookingMenu",
                column: "MenuId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
