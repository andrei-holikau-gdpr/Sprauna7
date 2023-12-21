using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateIdentitySchema_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 1,
                column: "TrackNumber",
                value: "04.09.2023 1:18:36");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 2,
                column: "TrackNumber",
                value: "04.09.2023 1:18:36");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "PurchaseId",
                keyValue: 3,
                column: "TrackNumber",
                value: "04.09.2023 1:18:36");

            migrationBuilder.UpdateData(
                table: "Receivers",
                keyColumn: "ReceiverId",
                keyValue: 1,
                column: "PassportIssueDate",
                value: new DateTime(2023, 9, 4, 4, 18, 36, 505, DateTimeKind.Local).AddTicks(5185));

            migrationBuilder.UpdateData(
                table: "Receivers",
                keyColumn: "ReceiverId",
                keyValue: 2,
                column: "PassportIssueDate",
                value: new DateTime(2023, 9, 4, 4, 18, 36, 505, DateTimeKind.Local).AddTicks(5198));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
