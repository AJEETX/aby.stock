using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbyStockManager.Web.Migrations
{
    /// <inheritdoc />
    public partial class _service_print_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "ServiceReport",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ServiceReport",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gstin",
                table: "ServiceReport",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "ServiceReport",
                type: "TEXT",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "ServiceReport");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ServiceReport");

            migrationBuilder.DropColumn(
                name: "Gstin",
                table: "ServiceReport");

            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "ServiceReport");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3272));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3275));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3278));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3284));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3591));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3600));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3603));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3606));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3608));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3611));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3613));

            migrationBuilder.UpdateData(
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(5679));

            migrationBuilder.UpdateData(
                table: "ServiceCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(5685));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(5551));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(2828));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3128));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3145));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(5283));
        }
    }
}
