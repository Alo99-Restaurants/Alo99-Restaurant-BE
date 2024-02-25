using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingServices.Entities.Migrations;

/// <inheritdoc />
public partial class addmenuurl : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "MenuUrl",
            table: "RestaurantMenu",
            type: "longtext",
            nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: new Guid("2b8f3715-3af2-453d-b235-d60d8e344eac"),
            column: "Password",
            value: "2CJZFcC1YQpu/HvDH+J7hEekUneMqG2VvxxferQA26LDdO9RaDTab3KpMG3R566c");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: new Guid("397ba1f1-c2ff-4bdf-8d59-4a6c37ca30c6"),
            column: "Password",
            value: "O9UMNlWajPe+bTgXXg5SUup43IxoptsbDx0FuATSVy8KflkqtiIDB2WoFJStSb0j");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: new Guid("8da5e99c-7eb2-4a48-9b6f-6b9c58837294"),
            column: "Password",
            value: "gBE6DkzYgJdpvIfbUlIjjd9Ss/8AoiR65aS6YYr6ro9iL/agDbdG82IWKVJENLh2");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: new Guid("be809c8a-b2d4-4654-b5ef-7bb99f3af3b5"),
            column: "Password",
            value: "7b3D0P5Ja+DmOSs+kHRSG4dH/E+xNqEppd4AS/Pp6sBOu/kqPAkLYlUhLuqWwjiW");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "MenuUrl",
            table: "RestaurantMenu");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: new Guid("2b8f3715-3af2-453d-b235-d60d8e344eac"),
            column: "Password",
            value: "FiXs79cHZo16Klm19+Z7qFlH5x7SlPo9jxROKf6rzsYPCDPG1vbNCp2+gm/1sAf8");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: new Guid("397ba1f1-c2ff-4bdf-8d59-4a6c37ca30c6"),
            column: "Password",
            value: "OKHHYV7qNBBUDh0YArXHA/bdw5Fa9EL/aLAKDvEDUDhFxar8YoRP8U9OKbHMsE8Q");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: new Guid("8da5e99c-7eb2-4a48-9b6f-6b9c58837294"),
            column: "Password",
            value: "2QSjmkoY7F9ezCcRoKDRRp/W/CskfWqTuKnpIG50J3tDSvptQaN7nZAX8xEqBkKR");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: new Guid("be809c8a-b2d4-4654-b5ef-7bb99f3af3b5"),
            column: "Password",
            value: "ig9YboXAscbHhaw+446DRx9AYpWr4XouGaCtzHebKOcxMzMhliVSaTsF2rTxZha6");
    }
}
