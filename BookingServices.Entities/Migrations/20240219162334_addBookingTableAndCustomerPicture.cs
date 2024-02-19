using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingServices.Entities.Migrations
{
    /// <inheritdoc />
    public partial class addBookingTableAndCustomerPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tables_TableId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_TableId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Customers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BookingTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TableId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BookingId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingTable_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingTable_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b8f3715-3af2-453d-b235-d60d8e344eac"),
                column: "Password",
                value: "cnv7O/zt5kv5OIrzLSTYvi3uN9xvvws5RFMKxTzDxa9v2eI9xvykm5dGHzXUScXD");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("397ba1f1-c2ff-4bdf-8d59-4a6c37ca30c6"),
                column: "Password",
                value: "/SUXXFo7T1bHCR6N3WD5o450aNaPDtO588QXbtln5Bd4kzLTelA4NSMGV4WGI9FS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8da5e99c-7eb2-4a48-9b6f-6b9c58837294"),
                column: "Password",
                value: "mNICYl+DmV+VvDAfTcmn9dsnFRGUmVYJfxsfXx7WQYjRvZNbSXp7juXi3nLrAJ/C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("be809c8a-b2d4-4654-b5ef-7bb99f3af3b5"),
                column: "Password",
                value: "jqpguqCU721YqSUnbrVEOcnFMS2wdUTLVI0swwM1v18XiBZtN7OjqKnh412PfdUu");

            migrationBuilder.CreateIndex(
                name: "IX_BookingTable_BookingId",
                table: "BookingTable",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingTable_TableId",
                table: "BookingTable",
                column: "TableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingTable");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "TableId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TableId",
                table: "Bookings",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tables_TableId",
                table: "Bookings",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
