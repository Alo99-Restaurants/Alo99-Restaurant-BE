using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingServices.Entities.Migrations
{
    /// <inheritdoc />
    public partial class addmanytomanyforbookingandtable : Migration
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
                name: "BookingsTables",
                columns: table => new
                {
                    BookingsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TablesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingsTables", x => new { x.BookingsId, x.TablesId });
                    table.ForeignKey(
                        name: "FK_BookingsTables_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingsTables_Tables_TablesId",
                        column: x => x.TablesId,
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

            migrationBuilder.CreateIndex(
                name: "IX_BookingsTables_TablesId",
                table: "BookingsTables",
                column: "TablesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingsTables");

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
