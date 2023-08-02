using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbyStockManager.Web.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceRemarks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Transaction",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4603));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4792));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4793));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4360));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(4536));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 8, 3, 0, 32, 17, 346, DateTimeKind.Local).AddTicks(5824));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Transaction");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9923));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9928));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9930));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9931));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9933));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9935));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9936));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 822, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 822, DateTimeKind.Local).AddTicks(16));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 822, DateTimeKind.Local).AddTicks(19));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9411));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9653));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 821, DateTimeKind.Local).AddTicks(9657));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 4, 19, 26, 3, 822, DateTimeKind.Local).AddTicks(1313));
        }
    }
}
