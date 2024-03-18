using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingServices.Entities.Migrations
{
    /// <inheritdoc />
    public partial class fixSpellingStorages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stogares");

            migrationBuilder.CreateTable(
                name: "Storages",
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
                    table.PrimaryKey("PK_Storages", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b8f3715-3af2-453d-b235-d60d8e344eac"),
                column: "Password",
                value: "XHB/8qgcvtnQCtAO53xZ94bM6nGiz9U3E901JGpRhtEaulfUNDumQZZecpxVBqqi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("397ba1f1-c2ff-4bdf-8d59-4a6c37ca30c6"),
                column: "Password",
                value: "DxW/kB/tEjmS7xSHrxjyi7T/nVqgVWnSUett288trhElI3XFNJVy0rjbs2YhRiXs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8da5e99c-7eb2-4a48-9b6f-6b9c58837294"),
                column: "Password",
                value: "/c5s+kXuFOY5OGDFiM5tcrqlIxfz7b2aAwmNL5cSV6lnVp8hEhQQuXuZdTdQxD8i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("be809c8a-b2d4-4654-b5ef-7bb99f3af3b5"),
                column: "Password",
                value: "r89WVs//hsevAi9hubXScLsiITI3yF3wbe23bW5fxhCIlIhAGubzmkfUtNjOGfe6");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.CreateTable(
                name: "Stogares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stogares", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b8f3715-3af2-453d-b235-d60d8e344eac"),
                column: "Password",
                value: "JYvU1To0JmaESemD65aClP8cntdldbNFasyRuCFHu7ubqCBvFZK+6QXwVCqUuuS9");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("397ba1f1-c2ff-4bdf-8d59-4a6c37ca30c6"),
                column: "Password",
                value: "QK/eyYyzwlxUwN2MkpEWpznTW7b4AFISFG4/MUSjG0dgoS7YbB7ChyuGXl9hRvCi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8da5e99c-7eb2-4a48-9b6f-6b9c58837294"),
                column: "Password",
                value: "pPuh1k63zloxRHqindRmctUjxBytxLR89qMQhzaJpJzLnCI60sZmQPjePzjcWw4p");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("be809c8a-b2d4-4654-b5ef-7bb99f3af3b5"),
                column: "Password",
                value: "GJo6rq8rzcxhOb/XofbXyyB7aTsWPZiAR5CViyBc2sk9YOMjwFuTCKqFkHxtgBIn");
        }
    }
}
