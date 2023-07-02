using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbyStockManager.Web.Migrations
{
    /// <inheritdoc />
    public partial class SequenceNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumberSequence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumberSequenceId = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberSequenceName = table.Column<string>(type: "TEXT", nullable: false),
                    Module = table.Column<string>(type: "TEXT", nullable: false),
                    Prefix = table.Column<string>(type: "TEXT", nullable: false),
                    LastNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberSequence", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(3964));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(3967));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(4402));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(4406));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(4410));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(3349));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(3423));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(5463));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 21, 16, 28, 161, DateTimeKind.Local).AddTicks(5579));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumberSequence");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(2989));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(2994));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(3298));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(3303));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(3305));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(3307));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(3309));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(3311));

            migrationBuilder.UpdateData(
                table: "ExpenseCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(3313));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(4286));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(2560));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(2902));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(2909));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(2914));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(4099));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 2, 16, 47, 16, 462, DateTimeKind.Local).AddTicks(4194));
        }
    }
}
