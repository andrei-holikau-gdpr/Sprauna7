using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Plugins.DataStore.SQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateIdentitySchema_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CostOfDeliveries",
                columns: table => new
                {
                    CostOfDeliveryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightKg = table.Column<double>(type: "float", nullable: false),
                    CostPln = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostOfDeliveries", x => x.CostOfDeliveryId);
                });

            migrationBuilder.CreateTable(
                name: "DirectorySps",
                columns: table => new
                {
                    DirectorySpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorySps", x => x.DirectorySpId);
                });

            migrationBuilder.CreateTable(
                name: "PackageSp",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    NumberPackage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    PricePLN = table.Column<double>(type: "float", nullable: false),
                    PriceBYN = table.Column<double>(type: "float", nullable: false),
                    IsCollectivePackage = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageSp", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "Receivers",
                columns: table => new
                {
                    ReceiverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportSeries = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    PassportID = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    PassportIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportIssuedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    House = table.Column<int>(type: "int", nullable: false),
                    HouseBuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flat = table.Column<int>(type: "int", nullable: false),
                    Index = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportScan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Iin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hide = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportHumanDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportDateForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthdateForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SbsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivers", x => x.ReceiverId);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoice_PackageSp_PackageId",
                        column: x => x.PackageId,
                        principalTable: "PackageSp",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileSps",
                columns: table => new
                {
                    FileSpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileNameForFileStorage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileSps", x => x.FileSpId);
                    table.ForeignKey(
                        name: "FK_FileSps_Receivers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Receivers",
                        principalColumn: "ReceiverId");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentDeliveryParcels",
                columns: table => new
                {
                    DepartmentDeliveryParcelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressForMap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GipermallId = table.Column<int>(type: "int", nullable: false),
                    Hide = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentDeliveryParcels", x => x.DepartmentDeliveryParcelId);
                    table.ForeignKey(
                        name: "FK_DepartmentDeliveryParcels_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId");
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SbsTrackId = table.Column<int>(type: "int", nullable: true),
                    DeliveryType = table.Column<int>(type: "int", nullable: true),
                    Wait = table.Column<int>(type: "int", nullable: true),
                    CurrentUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Shop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CombineParcels = table.Column<int>(type: "int", nullable: false),
                    AgreeWithTools = table.Column<bool>(type: "bit", nullable: false),
                    TrackNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lock = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentDeliveryParcelId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_DepartmentDeliveryParcels_DepartmentDeliveryParcelId",
                        column: x => x.DepartmentDeliveryParcelId,
                        principalTable: "DepartmentDeliveryParcels",
                        principalColumn: "DepartmentDeliveryParcelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_PackageSp_PackageId",
                        column: x => x.PackageId,
                        principalTable: "PackageSp",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Receivers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Receivers",
                        principalColumn: "ReceiverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSps",
                columns: table => new
                {
                    ProductSpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeAndBrand = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UrlToProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    UrlToImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SbsId = table.Column<int>(type: "int", nullable: true),
                    TrackNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseNewId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSps", x => x.ProductSpId);
                    table.ForeignKey(
                        name: "FK_ProductSps_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_ProductSps_Purchases_PurchaseNewId",
                        column: x => x.PurchaseNewId,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Описание 1", "Одежда" },
                    { 2, "Описание 2", "Обувь" },
                    { 3, "Описание 3", "Куртка" }
                });

            migrationBuilder.InsertData(
                table: "CostOfDeliveries",
                columns: new[] { "CostOfDeliveryId", "CostPln", "WeightKg" },
                values: new object[,]
                {
                    { 1, 44.0, 0.5 },
                    { 2, 63.0, 1.0 },
                    { 3, 76.0, 2.0 },
                    { 4, 84.0, 3.0 },
                    { 5, 114.0, 4.0 },
                    { 6, 136.0, 5.0 },
                    { 7, 158.0, 6.0 },
                    { 8, 181.0, 7.0 },
                    { 9, 203.0, 8.0 },
                    { 10, 226.0, 9.0 },
                    { 11, 248.0, 10.0 },
                    { 12, 270.0, 11.0 },
                    { 13, 293.0, 12.0 },
                    { 14, 315.0, 13.0 },
                    { 15, 338.0, 14.0 },
                    { 16, 360.0, 15.0 },
                    { 17, 382.0, 16.0 },
                    { 18, 405.0, 17.0 },
                    { 19, 427.0, 18.0 },
                    { 20, 450.0, 19.0 },
                    { 21, 472.0, 20.0 },
                    { 22, 494.0, 21.0 },
                    { 23, 517.0, 22.0 },
                    { 24, 539.0, 23.0 },
                    { 25, 562.0, 24.0 },
                    { 26, 584.0, 25.0 },
                    { 27, 606.0, 26.0 },
                    { 28, 629.0, 27.0 },
                    { 29, 651.0, 28.0 },
                    { 30, 674.0, 29.0 },
                    { 31, 696.0, 30.0 }
                });

            migrationBuilder.InsertData(
                table: "PackageSp",
                columns: new[] { "PackageId", "CurrentUserId", "Description", "InvoiceId", "IsCollectivePackage", "NumberPackage", "PriceBYN", "PricePLN", "Status", "TrackNumber", "Weight" },
                values: new object[] { 1, "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2", "", 0, false, "NumberPackage", 1.0, 1.0, 7, "TrackNumber", 1.0 });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "ReceiverId", "Birthdate", "BirthdateForm", "City", "Country", "CreatedAt", "CurrentUserId", "Description", "Email", "FirstName", "Flat", "Fullname", "Hide", "House", "HouseBuildingNumber", "Iin", "Index", "IsDefault", "Nationality", "Passport", "PassportDateForm", "PassportHumanDate", "PassportID", "PassportIssueDate", "PassportIssuedBy", "PassportScan", "PassportSeries", "Phone", "Region", "SbsId", "SecondName", "Street", "Surname", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, null, "Минск", "Беларусь", null, "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2", "", null, "Иван", 1, null, 0, 1, "а", null, "123123", false, "Беларусь", null, null, null, "1234567", new DateTime(2023, 9, 2, 11, 14, 30, 185, DateTimeKind.Local).AddTicks(422), "Кем выдан 1", "Скан паспорта 1", "МР", "+375441112233", "Минская область", 0, "Иванов", "ул.Ленинская", "Иванович", null, null },
                    { 2, null, null, "Могилев", "Беларусь", null, "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2", "", null, "Петр", 2, null, 0, 2, "с", null, "212000", false, "Беларусь", null, null, null, "1234567", new DateTime(2023, 9, 2, 11, 14, 30, 185, DateTimeKind.Local).AddTicks(439), "Кем выдан 2", "Скан паспорта 2", "МР", "+375291122234", "Могилевская область", 0, "Петров", "ул.Центральная", "Петрович", null, null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "", "Минск" },
                    { 2, "", "Могилев" },
                    { 3, "", "Витебск" },
                    { 4, "", "Гродно" },
                    { 5, "", "Гомель" },
                    { 6, "", "Брест" },
                    { 7, "", "Минская область" },
                    { 8, "", "Могилевская область" },
                    { 9, "", "Витебская область" },
                    { 10, "", "Гродненская область" },
                    { 11, "", "Гомельская область" },
                    { 12, "", "Брестская область" }
                });

            migrationBuilder.InsertData(
                table: "DepartmentDeliveryParcels",
                columns: new[] { "DepartmentDeliveryParcelId", "Address", "AddressForMap", "Description", "GipermallId", "Hide", "RegionId" },
                values: new object[,]
                {
                    { 1, "г.Минск, ул.Ленинская 1", null, "Режим работы 10:00 - 21:00", 0, 0, 1 },
                    { 2, "г.Могилев, ул.Ленинская 2", null, "Режим работы 10:00 - 21:00", 0, 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "PurchaseId", "AgreeWithTools", "CombineParcels", "CurrentUserId", "DeliveryType", "DepartmentDeliveryParcelId", "Description", "Lock", "Name", "PackageId", "ReceiverId", "SbsTrackId", "Shop", "Surname", "TrackNumber", "Wait" },
                values: new object[,]
                {
                    { 1, true, 0, "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2", 2, 1, "Покупка 1", false, "Иван", 1, 1, null, "https://allegro.pl/", "Иванов", "02.09.2023 8:14:30", 0 },
                    { 2, true, 1, "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2", 2, 1, "Покупка 2", false, "Иван", 1, 1, null, "https://allegro.pl/", "Новиков", "02.09.2023 8:14:30", 0 },
                    { 3, true, 1, "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2", 2, 2, "Покупка 2", false, "Иван", 1, 2, null, "https://allegro.pl/", "Сидоров", "02.09.2023 8:14:30", 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductSps",
                columns: new[] { "ProductSpId", "CategoryId", "CurrentUserId", "Description", "Price", "ProductTypeAndBrand", "PurchaseNewId", "Quantity", "SbsId", "TrackNumber", "UrlToImage", "UrlToProduct" },
                values: new object[,]
                {
                    { 1, 1, "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2", "Описание 1", 10.99, "Штаны 1 ", 1, 10, null, null, "https://img.freepik.com/free-photo/white-t-shirts-with-copy-space-on-gray-background_53876-104920.jpg?w=1380&t=st=1684705904~exp=1684706504~hmac=fbc3236dbb2840c42a5fb2125297e813c71c158310db8002a147e015a161ff92", "https://sprauna.by/" },
                    { 2, 1, "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2", "Описание 2", 4.9900000000000002, "Майка 2 ", 1, 30, null, null, "https://img.freepik.com/free-photo/white-t-shirts-with-copy-space-on-gray-background_53876-104920.jpg?w=1380&t=st=1684705904~exp=1684706504~hmac=fbc3236dbb2840c42a5fb2125297e813c71c158310db8002a147e015a161ff92", "https://sprauna.by/" },
                    { 3, 1, "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2", "Описание 3", 20.989999999999998, "Кеды 3", 2, 20, null, null, "https://img.freepik.com/free-photo/white-t-shirts-with-copy-space-on-gray-background_53876-104920.jpg?w=1380&t=st=1684705904~exp=1684706504~hmac=fbc3236dbb2840c42a5fb2125297e813c71c158310db8002a147e015a161ff92", "https://sprauna.by/" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentDeliveryParcels_RegionId",
                table: "DepartmentDeliveryParcels",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_FileSps_ReceiverId",
                table: "FileSps",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_PackageId",
                table: "Invoice",
                column: "PackageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSps_CategoryId",
                table: "ProductSps",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSps_PurchaseNewId",
                table: "ProductSps",
                column: "PurchaseNewId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_DepartmentDeliveryParcelId",
                table: "Purchases",
                column: "DepartmentDeliveryParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PackageId",
                table: "Purchases",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ReceiverId",
                table: "Purchases",
                column: "ReceiverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostOfDeliveries");

            migrationBuilder.DropTable(
                name: "DirectorySps");

            migrationBuilder.DropTable(
                name: "FileSps");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "ProductSps");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "DepartmentDeliveryParcels");

            migrationBuilder.DropTable(
                name: "PackageSp");

            migrationBuilder.DropTable(
                name: "Receivers");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
