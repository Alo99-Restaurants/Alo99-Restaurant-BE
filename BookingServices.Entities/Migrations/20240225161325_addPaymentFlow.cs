using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingServices.Entities.Migrations;

/// <inheritdoc />
public partial class addPaymentFlow : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Transaction",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                Amount = table.Column<double>(type: "double", nullable: false),
                BankCode = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                BankTranNo = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                CardType = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                PayDate = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                OrderInfo = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TransactionNo = table.Column<long>(type: "bigint", nullable: false),
                ResponseCode = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TransactionStatus = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                TxnRef = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                SecureHashType = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                SecureHash = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                ModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Transaction", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Payments",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                TransactionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                BookingId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                Amount = table.Column<double>(type: "double", nullable: false),
                IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                CreatedBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                ModifiedBy = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Payments", x => x.Id);
                table.ForeignKey(
                    name: "FK_Payments_Bookings_BookingId",
                    column: x => x.BookingId,
                    principalTable: "Bookings",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Payments_Transaction_TransactionId",
                    column: x => x.TransactionId,
                    principalTable: "Transaction",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            })
            .Annotation("MySql:CharSet", "utf8mb4");

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

        migrationBuilder.CreateIndex(
            name: "IX_Payments_BookingId",
            table: "Payments",
            column: "BookingId");

        migrationBuilder.CreateIndex(
            name: "IX_Payments_TransactionId",
            table: "Payments",
            column: "TransactionId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Payments");

        migrationBuilder.DropTable(
            name: "Transaction");

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
}
