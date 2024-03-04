using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingServices.Entities.Migrations
{
    /// <inheritdoc />
    public partial class addEmailConfirmed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Customers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b8f3715-3af2-453d-b235-d60d8e344eac"),
                column: "Password",
                value: "O1VebAN82VF3kZwxYz2HGTe1dNEvH6DROpWml4MI6elClJlkJbyy2XIvxgqUuIr8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("397ba1f1-c2ff-4bdf-8d59-4a6c37ca30c6"),
                column: "Password",
                value: "IYq2prSsu9hyL4nPvRR0DX7ud/QrYXrDij1Tfq9IHU7bdXf30Vx/d6S1SqSY35uI");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8da5e99c-7eb2-4a48-9b6f-6b9c58837294"),
                column: "Password",
                value: "oY+PfglnK2K10Ng0/xdgomy2pAGG5uL7tf4IoJh5BaDMPiNE7p8gJSdNG4lG8Wda");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("be809c8a-b2d4-4654-b5ef-7bb99f3af3b5"),
                column: "Password",
                value: "VutLU2yP2zs4rkLriTHIAJGfMGDmZrsS1Ze45df0d8+gDDjCCga/+l2w0Q1HxP0y");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b8f3715-3af2-453d-b235-d60d8e344eac"),
                column: "Password",
                value: "WysOd9Cc30YUW+FSpReFVYArJaz/dg7qkvgJ4bP793ohWTtWWMBchZwYHTuJIN9D");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("397ba1f1-c2ff-4bdf-8d59-4a6c37ca30c6"),
                column: "Password",
                value: "yG72BeE/74tFdzd6M15Aq6NRRAkq8EnaVmT6BJaAq72KE6+mEMzGtQe1Y7U1K+yZ");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8da5e99c-7eb2-4a48-9b6f-6b9c58837294"),
                column: "Password",
                value: "liR22NtSXnZjJd1dc7FAypJR9qii/9QH61uNnaV8GajWhNABhY9y2HZCec6geVaA");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("be809c8a-b2d4-4654-b5ef-7bb99f3af3b5"),
                column: "Password",
                value: "4yNf3MGXlz80XRbqHklmU9dBMRxYAxG8eSwNILqmllw9y8OZQ99ALO9Xu913KCh4");
        }
    }
}
