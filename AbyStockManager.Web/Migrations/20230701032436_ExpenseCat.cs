using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbyStockManager.Web.Migrations
{
    /// <inheritdoc />
    public partial class ExpenseCat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpenseCategoryId",
                table: "ExpenseReport",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExpenseCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategory", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 13, 24, 36, 710, DateTimeKind.Local).AddTicks(5));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 13, 24, 36, 710, DateTimeKind.Local).AddTicks(7));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 13, 24, 36, 710, DateTimeKind.Local).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 13, 24, 36, 710, DateTimeKind.Local).AddTicks(9));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 13, 24, 36, 710, DateTimeKind.Local).AddTicks(11));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 13, 24, 36, 710, DateTimeKind.Local).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Image" },
                values: new object[] { new DateTime(2023, 7, 1, 13, 24, 36, 710, DateTimeKind.Local).AddTicks(1016), null });

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 13, 24, 36, 710, DateTimeKind.Local).AddTicks(64));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 13, 24, 36, 710, DateTimeKind.Local).AddTicks(67));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 13, 24, 36, 709, DateTimeKind.Local).AddTicks(9744));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 13, 24, 36, 709, DateTimeKind.Local).AddTicks(9792));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 13, 24, 36, 709, DateTimeKind.Local).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 13, 24, 36, 709, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 13, 24, 36, 709, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 13, 24, 36, 710, DateTimeKind.Local).AddTicks(721));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 13, 24, 36, 710, DateTimeKind.Local).AddTicks(791));

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseReport_ExpenseCategoryId",
                table: "ExpenseReport",
                column: "ExpenseCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseReport_ExpenseCategory_ExpenseCategoryId",
                table: "ExpenseReport",
                column: "ExpenseCategoryId",
                principalTable: "ExpenseCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseReport_ExpenseCategory_ExpenseCategoryId",
                table: "ExpenseReport");

            migrationBuilder.DropTable(
                name: "ExpenseCategory");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseReport_ExpenseCategoryId",
                table: "ExpenseReport");

            migrationBuilder.DropColumn(
                name: "ExpenseCategoryId",
                table: "ExpenseReport");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Image" },
                values: new object[] { new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(6930), "logo.png" });

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(6151));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(6154));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(5657));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(5712));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(5971));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(5981));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(5985));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(6744));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 1, 7, 28, 31, 246, DateTimeKind.Local).AddTicks(6843));
        }
    }
}
