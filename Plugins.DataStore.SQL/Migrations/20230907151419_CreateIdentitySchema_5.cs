using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateIdentitySchema_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Created",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Expiration",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 1,
                column: "TrackNumber",
                value: "07.09.2023 15:14:19");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 2,
                column: "TrackNumber",
                value: "07.09.2023 15:14:19");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 3,
                column: "TrackNumber",
                value: "07.09.2023 15:14:19");

            migrationBuilder.UpdateData(
                table: "Receivers",
                keyColumn: "ReceiverId",
                keyValue: 1,
                column: "PassportIssueDate",
                value: new DateTime(2023, 9, 7, 18, 14, 19, 258, DateTimeKind.Local).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "Receivers",
                keyColumn: "ReceiverId",
                keyValue: 2,
                column: "PassportIssueDate",
                value: new DateTime(2023, 9, 7, 18, 14, 19, 258, DateTimeKind.Local).AddTicks(5238));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Expiration",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Invoices");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 1,
                column: "TrackNumber",
                value: "07.09.2023 14:09:41");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 2,
                column: "TrackNumber",
                value: "07.09.2023 14:09:41");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 3,
                column: "TrackNumber",
                value: "07.09.2023 14:09:41");

            migrationBuilder.UpdateData(
                table: "Receivers",
                keyColumn: "ReceiverId",
                keyValue: 1,
                column: "PassportIssueDate",
                value: new DateTime(2023, 9, 7, 17, 9, 41, 8, DateTimeKind.Local).AddTicks(8343));

            migrationBuilder.UpdateData(
                table: "Receivers",
                keyColumn: "ReceiverId",
                keyValue: 2,
                column: "PassportIssueDate",
                value: new DateTime(2023, 9, 7, 17, 9, 41, 8, DateTimeKind.Local).AddTicks(8358));
        }
    }
}
