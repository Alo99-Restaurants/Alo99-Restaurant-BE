using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingServices.Entities.Migrations;

/// <inheritdoc />
public partial class addPriceIntoBookingMenu : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<double>(
            name: "Price",
            table: "BookingMenu",
            type: "double",
            nullable: false,
            defaultValue: 0.0);

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: new Guid("2b8f3715-3af2-453d-b235-d60d8e344eac"),
            column: "Password",
            value: "xzQap6jlKG+32pWkSwwy2oBIfpV2oQJLM7ll7nYD4H1DTiFDQB5dBBzGv/5mfLTC");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: new Guid("397ba1f1-c2ff-4bdf-8d59-4a6c37ca30c6"),
            column: "Password",
            value: "iU1l3719Q977p1K7jAxMHyx8YuuNIwvCfFR6OwyIuSY+5LujlIwVfRiND2BIMgLy");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: new Guid("8da5e99c-7eb2-4a48-9b6f-6b9c58837294"),
            column: "Password",
            value: "M2XFyB36mhndb8GbgkcrienJOhAgLsblZIzU34wQpBHhhMXKo09oKNP7fdTyBFXM");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: new Guid("be809c8a-b2d4-4654-b5ef-7bb99f3af3b5"),
            column: "Password",
            value: "IHdQAn/c1GHo1qxOnByVPRlMGMPLNnYjlFz838FbTNsCE7UVoORKOmNby3rTTTu/");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Price",
            table: "BookingMenu");

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
    }
}
