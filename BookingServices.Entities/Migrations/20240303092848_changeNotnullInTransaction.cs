using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingServices.Entities.Migrations
{
    /// <inheritdoc />
    public partial class changeNotnullInTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SecureHashType",
                table: "Transaction",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PayDate",
                table: "Transaction",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                table: "Transaction",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "BankTranNo",
                table: "Transaction",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "SecureHashType",
                keyValue: null,
                column: "SecureHashType",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SecureHashType",
                table: "Transaction",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "PayDate",
                keyValue: null,
                column: "PayDate",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PayDate",
                table: "Transaction",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "CardType",
                keyValue: null,
                column: "CardType",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                table: "Transaction",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "BankTranNo",
                keyValue: null,
                column: "BankTranNo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "BankTranNo",
                table: "Transaction",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
    }
}
