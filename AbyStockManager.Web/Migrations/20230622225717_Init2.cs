using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbyStockManager.Web.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 57, 17, 332, DateTimeKind.Local).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 57, 17, 332, DateTimeKind.Local).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 57, 17, 332, DateTimeKind.Local).AddTicks(5663));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 57, 17, 332, DateTimeKind.Local).AddTicks(5664));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 57, 17, 332, DateTimeKind.Local).AddTicks(5666));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 57, 17, 332, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 57, 17, 332, DateTimeKind.Local).AddTicks(6774));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 57, 17, 332, DateTimeKind.Local).AddTicks(5742));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 57, 17, 332, DateTimeKind.Local).AddTicks(5744));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 57, 17, 332, DateTimeKind.Local).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 57, 17, 332, DateTimeKind.Local).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 57, 17, 332, DateTimeKind.Local).AddTicks(5591));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 57, 17, 332, DateTimeKind.Local).AddTicks(5597));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 57, 17, 332, DateTimeKind.Local).AddTicks(5601));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 57, 17, 332, DateTimeKind.Local).AddTicks(6678));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 51, 49, 850, DateTimeKind.Local).AddTicks(8538));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 51, 49, 850, DateTimeKind.Local).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 51, 49, 850, DateTimeKind.Local).AddTicks(8542));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 51, 49, 850, DateTimeKind.Local).AddTicks(8543));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 51, 49, 850, DateTimeKind.Local).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 51, 49, 850, DateTimeKind.Local).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 51, 49, 850, DateTimeKind.Local).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 51, 49, 850, DateTimeKind.Local).AddTicks(8613));

            migrationBuilder.UpdateData(
                table: "Tax",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 51, 49, 850, DateTimeKind.Local).AddTicks(8616));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 51, 49, 850, DateTimeKind.Local).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "TransactionType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 51, 49, 850, DateTimeKind.Local).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 51, 49, 850, DateTimeKind.Local).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 51, 49, 850, DateTimeKind.Local).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasure",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 51, 49, 850, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 6, 23, 8, 51, 49, 850, DateTimeKind.Local).AddTicks(9628));
        }
    }
}
