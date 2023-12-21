using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateIdentitySchema_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrackNumber",
                table: "ProductSps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ProductSps",
                keyColumn: "ProductSpId",
                keyValue: 1,
                column: "TrackNumber",
                value: "3");

            migrationBuilder.UpdateData(
                table: "ProductSps",
                keyColumn: "ProductSpId",
                keyValue: 2,
                column: "TrackNumber",
                value: "2");

            migrationBuilder.UpdateData(
                table: "ProductSps",
                keyColumn: "ProductSpId",
                keyValue: 3,
                column: "TrackNumber",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 1,
                column: "TrackNumber",
                value: "03.09.2023 23:29:43");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 2,
                column: "TrackNumber",
                value: "03.09.2023 23:29:43");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 3,
                column: "TrackNumber",
                value: "03.09.2023 23:29:43");

            migrationBuilder.UpdateData(
                table: "Receivers",
                keyColumn: "ReceiverId",
                keyValue: 1,
                column: "PassportIssueDate",
                value: new DateTime(2023, 9, 4, 2, 29, 43, 796, DateTimeKind.Local).AddTicks(5856));

            migrationBuilder.UpdateData(
                table: "Receivers",
                keyColumn: "ReceiverId",
                keyValue: 2,
                column: "PassportIssueDate",
                value: new DateTime(2023, 9, 4, 2, 29, 43, 796, DateTimeKind.Local).AddTicks(5872));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrackNumber",
                table: "ProductSps",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ProductSps",
                keyColumn: "ProductSpId",
                keyValue: 1,
                column: "TrackNumber",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductSps",
                keyColumn: "ProductSpId",
                keyValue: 2,
                column: "TrackNumber",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductSps",
                keyColumn: "ProductSpId",
                keyValue: 3,
                column: "TrackNumber",
                value: null);

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 1,
                column: "TrackNumber",
                value: "02.09.2023 8:14:30");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 2,
                column: "TrackNumber",
                value: "02.09.2023 8:14:30");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 3,
                column: "TrackNumber",
                value: "02.09.2023 8:14:30");

            migrationBuilder.UpdateData(
                table: "Receivers",
                keyColumn: "ReceiverId",
                keyValue: 1,
                column: "PassportIssueDate",
                value: new DateTime(2023, 9, 2, 11, 14, 30, 185, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "Receivers",
                keyColumn: "ReceiverId",
                keyValue: 2,
                column: "PassportIssueDate",
                value: new DateTime(2023, 9, 2, 11, 14, 30, 185, DateTimeKind.Local).AddTicks(439));
        }
    }
}
