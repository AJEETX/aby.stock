using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AbyStockManager.Web.Migrations
{
    /// <inheritdoc />
    public partial class _service_type_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceCategoryName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Amount = table.Column<double>(type: "decimal(18,2)", nullable: false),
                    ServiceDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ServiceCategoryId = table.Column<int>(type: "INTEGER", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceReport_ServiceCategory_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategory",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "ServiceCategory",
                columns: new[] { "Id", "CreateDate", "ServiceCategoryName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(5679), "WHEEL-ALIGNMENT" },
                    { 2, new DateTime(2024, 3, 1, 16, 47, 4, 303, DateTimeKind.Local).AddTicks(5685), "OTHERS" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReport_ServiceCategoryId",
                table: "ServiceReport",
                column: "ServiceCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceReport");

            migrationBuilder.DropTable(
                name: "ServiceCategory");

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
    }
}
