using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateIdentitySchema_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_PackageSp_PackageId",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_PackageId",
                table: "Invoices",
                newName: "IX_Invoices_PackageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "InvoiceId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_PackageSp_PackageId",
                table: "Invoices",
                column: "PackageId",
                principalTable: "PackageSp",
                principalColumn: "PackageId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_PackageSp_PackageId",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_PackageId",
                table: "Invoice",
                newName: "IX_Invoice_PackageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "InvoiceId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_PackageSp_PackageId",
                table: "Invoice",
                column: "PackageId",
                principalTable: "PackageSp",
                principalColumn: "PackageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
