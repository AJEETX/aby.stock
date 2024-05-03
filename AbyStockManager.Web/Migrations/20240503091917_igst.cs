using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbyStockManager.Web.Migrations
{
    /// <inheritdoc />
    public partial class igst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Igst",
                table: "Transaction",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Igst",
                table: "Transaction");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4617));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4805));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4265));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4541));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 6, 7, 24, 17, 907, DateTimeKind.Local).AddTicks(6132));
        }
    }
}
