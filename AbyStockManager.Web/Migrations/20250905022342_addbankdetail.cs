using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbyStockManager.Web.Migrations
{
    /// <inheritdoc />
    public partial class addbankdetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankAccountNumber",
                table: "Store",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IFSC",
                table: "Store",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3186));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3187));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3189));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3190));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3192));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3578));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3580));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3582));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3583));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3585));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3586));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(5862));

            migrationBuilder.UpdateData(
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(5863));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BankAccountNumber", "CreateDate", "IFSC" },
                values: new object[] { null, new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(5757), null });

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3722));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3724));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(2671));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(2687));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 9, 5, 7, 53, 42, 597, DateTimeKind.Local).AddTicks(5528));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccountNumber",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "IFSC",
                table: "Store");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(414));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(416));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(419));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(611));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(615));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(618));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(620));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(623));

            migrationBuilder.UpdateData(
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(1886));

            migrationBuilder.UpdateData(
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(1827));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(703));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(127));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(313));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(319));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(323));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 3, 19, 19, 16, 889, DateTimeKind.Local).AddTicks(1723));
        }
    }
}
