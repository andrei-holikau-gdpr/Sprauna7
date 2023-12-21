using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using static CoreBusiness.ComponentEnums;
using Department = CoreBusiness.DepartmentDeliveryParcel;

namespace Plugins.DataStore.SQL
{
    public class SpraunaContext : DbContext
    {
        public SpraunaContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Department> DepartmentDeliveryParcels { get; set; }
        public virtual DbSet<ProductSp> ProductSps { get; set; }
        public virtual DbSet<Receiver> Receivers { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<CostOfDelivery> CostOfDeliveries { get; set; }
        public virtual DbSet<FileSp> FileSps { get; set; }
        public virtual DbSet<DirectorySp> DirectorySps { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receiver>()
                .HasMany(r => r.Purchases)
                .WithOne(p => p.Receiver)
                .HasForeignKey(p => p.ReceiverId);

            modelBuilder.Entity<DepartmentDeliveryParcel>()
                .HasMany(d => d.Purchases)
                .WithOne(p => p.DepartmentDeliveryParcel)
                .HasForeignKey(p => p.DepartmentDeliveryParcelId);

            modelBuilder.Entity<Region>()
                .HasMany(r => r.DepartmentDeliveryParcels)
                .WithOne(d => d.Region)
                .HasForeignKey(p => p.RegionId);

            modelBuilder.Entity<Purchase>()
                .HasMany(pu => pu.ProductSps)
                .WithOne(pr => pr.Purchase)
                .HasForeignKey(pr => pr.PurchaseNewId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.ProductSps)
                .WithOne(pr => pr.Category)
                .HasForeignKey(pr => pr.CategoryId);

            modelBuilder.Entity<Package>()
                .HasOne(a => a.Invoice)
                .WithOne(b => b.Package)
                .HasForeignKey<Invoice>(b => b.PackageId);

            //seeding some data

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Одежда", Description = "Описание 1" },
                new Category { CategoryId = 2, Name = "Обувь", Description = "Описание 2" },
                new Category { CategoryId = 3, Name = "Куртка", Description = "Описание 3" }
                );

            modelBuilder.Entity<Region>().HasData(
                new Region { RegionId = 1, Name = "Минск" },
                new Region { RegionId = 2, Name = "Могилев" },
                new Region { RegionId = 3, Name = "Витебск" },
                new Region { RegionId = 4, Name = "Гродно" },
                new Region { RegionId = 5, Name = "Гомель" },
                new Region { RegionId = 6, Name = "Брест" },
                new Region { RegionId = 7, Name = "Минская область" },
                new Region { RegionId = 8, Name = "Могилевская область" },
                new Region { RegionId = 9, Name = "Витебская область" },
                new Region { RegionId = 10, Name = "Гродненская область" },
                new Region { RegionId = 11, Name = "Гомельская область" },
                new Region { RegionId = 12, Name = "Брестская область" }
                );

            
            modelBuilder.Entity<DepartmentDeliveryParcel>().HasData(
                new Department
                {
                    DepartmentDeliveryParcelId = 1,
                    Address = "г.Минск, ул.Ленинская 1",
                    Description = "Режим работы 10:00 - 21:00",
                    RegionId = 1
                },
                new Department
                {
                    DepartmentDeliveryParcelId = 2,
                    Address = "г.Могилев, ул.Ленинская 2",
                    Description = "Режим работы 10:00 - 21:00",
                    RegionId = 2
                }
                );
            

            modelBuilder.Entity<Receiver>().HasData(
                new Receiver
                {
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",
                    ReceiverId = 1,
                    Nationality = "Беларусь",
                    PassportSeries = "МР",
                    PassportID = "1234567",
                    PassportIssueDate = DateTime.Now,
                    PassportIssuedBy = "Кем выдан 1",
                    SecondName = "Иванов",
                    FirstName = "Иван",
                    Surname = "Иванович",
                    Country = "Беларусь",
                    Region = "Минская область",
                    City = "Минск",
                    Street = "ул.Ленинская",
                    House = 1,
                    HouseBuildingNumber = "а",
                    Flat = 1,
                    Index = "123123",
                    Phone = "+375441112233",
                    PassportScan = "Скан паспорта 1"
                },
                new Receiver
                {
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",
                    ReceiverId = 2,
                    Nationality = "Беларусь",
                    PassportSeries = "МР",
                    PassportID = "1234567",
                    PassportIssueDate = DateTime.Now,
                    PassportIssuedBy = "Кем выдан 2",
                    SecondName = "Петров",
                    FirstName = "Петр",
                    Surname = "Петрович",
                    Country = "Беларусь",
                    Region = "Могилевская область",
                    City = "Могилев",
                    Street = "ул.Центральная",
                    House = 2,
                    HouseBuildingNumber = "с",
                    Flat = 2,
                    Index = "212000",
                    Phone = "+375291122234",
                    PassportScan = "Скан паспорта 2"
                }
                );

            //  Закомментированные строки вызывают ошибки
            //  при импортировании данных в БД
            // 
            // Update - Database - Context SpraunaContext


            modelBuilder.Entity<Package>().HasData(
                new Package
                {
                    PackageId = 1,
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",
                    Description = "",
                    NumberPackage = "NumberPackage",
                    IsCollectivePackage = false,
                    PriceBYN = 1,
                    PricePLN = 1,
                    Status = StatusesPackage.Paid,
                    TrackNumber = "TrackNumber",
                    Weight= 1
                    
                });

            modelBuilder.Entity<Purchase>().HasData(
                new Purchase
                {
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",
                    PurchaseId = 1,
                    Surname = "Иванов",
                    Name = "Иван",
                    Shop = "https://allegro.pl/",
                    CombineParcels = CombineParcels.SendWithUnit,
                    AgreeWithTools = true,
                    Description = "Покупка 1",
                    TrackNumber = DateTime.UtcNow.ToString(),

                    // Relations
                    PackageId = 1,
                    DepartmentDeliveryParcelId = 1,
                    ReceiverId = 1
                },
                new Purchase
                {
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",

                    PurchaseId = 2,
                    Surname = "Новиков",
                    Name = "Иван",
                    Shop = "https://allegro.pl/",

                    CombineParcels = CombineParcels.SendWithoutUnit,
                    AgreeWithTools = true,
                    Description = "Покупка 2",
                    TrackNumber = DateTime.UtcNow.ToString(),

                    // Relations
                    PackageId = 1,
                    DepartmentDeliveryParcelId = 1,
                    ReceiverId = 1
                },
                new Purchase
                {
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",

                    PurchaseId = 3,
                    Surname = "Сидоров",
                    Name = "Иван",
                    Shop = "https://allegro.pl/",
                    CombineParcels = CombineParcels.SendWithoutUnit,
                    AgreeWithTools = true,
                    Description = "Покупка 2",
                    TrackNumber = DateTime.UtcNow.ToString(),


                    // Relations
                    PackageId = 1,
                    DepartmentDeliveryParcelId = 2,
                    ReceiverId = 2
                }
                );

            modelBuilder.Entity<ProductSp>().HasData(
                new ProductSp
                {
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",
                    UrlToProduct = "https://sprauna.by/",
                    ProductSpId = 1,
                    ProductTypeAndBrand = "Штаны 1 ",
                    Description = "Описание 1",
                    PurchaseNewId = 1,
                    Quantity = 10,
                    Price = 10.99,
                    UrlToImage = @"https://img.freepik.com/free-photo/white-t-shirts-with-copy-space-on-gray-background_53876-104920.jpg?w=1380&t=st=1684705904~exp=1684706504~hmac=fbc3236dbb2840c42a5fb2125297e813c71c158310db8002a147e015a161ff92",
                    CategoryId = 1,
                    TrackNumber = "3"
                },
                new ProductSp
                {
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",
                    UrlToProduct = "https://sprauna.by/",
                    ProductSpId = 2,
                    ProductTypeAndBrand = "Майка 2 ",
                    Description = "Описание 2",
                    PurchaseNewId = 1,
                    Quantity = 30,
                    Price = 4.99,
                    UrlToImage = @"https://img.freepik.com/free-photo/white-t-shirts-with-copy-space-on-gray-background_53876-104920.jpg?w=1380&t=st=1684705904~exp=1684706504~hmac=fbc3236dbb2840c42a5fb2125297e813c71c158310db8002a147e015a161ff92",
                    CategoryId = 1,
                    TrackNumber = "2"
                },
                new ProductSp
                {
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",
                    UrlToProduct = "https://sprauna.by/",
                    ProductSpId = 3,
                    ProductTypeAndBrand = "Кеды 3",
                    Description = "Описание 3",
                    PurchaseNewId = 2,
                    Quantity = 20,
                    Price = 20.99,
                    UrlToImage = @"https://img.freepik.com/free-photo/white-t-shirts-with-copy-space-on-gray-background_53876-104920.jpg?w=1380&t=st=1684705904~exp=1684706504~hmac=fbc3236dbb2840c42a5fb2125297e813c71c158310db8002a147e015a161ff92",
                    CategoryId = 1,
                    TrackNumber = "1"
                }
            );
            

            modelBuilder.Entity<CostOfDelivery>().HasData(
                new CostOfDelivery { CostOfDeliveryId = 1, WeightKg = 0.5, CostPln = 44 },
                new CostOfDelivery { CostOfDeliveryId = 2, WeightKg = 1, CostPln = 63 },
                new CostOfDelivery { CostOfDeliveryId = 3, WeightKg = 2, CostPln = 76 },
                new CostOfDelivery { CostOfDeliveryId = 4, WeightKg = 3, CostPln = 84 },
                new CostOfDelivery { CostOfDeliveryId = 5, WeightKg = 4, CostPln = 114 },
                new CostOfDelivery { CostOfDeliveryId = 6, WeightKg = 5, CostPln = 136 },
                new CostOfDelivery { CostOfDeliveryId = 7, WeightKg = 6, CostPln = 158 },
                new CostOfDelivery { CostOfDeliveryId = 8, WeightKg = 7, CostPln = 181 },
                new CostOfDelivery { CostOfDeliveryId = 9, WeightKg = 8, CostPln = 203 },
                new CostOfDelivery { CostOfDeliveryId = 10, WeightKg = 9, CostPln = 226 },
                new CostOfDelivery { CostOfDeliveryId = 11, WeightKg = 10, CostPln = 248 },
                new CostOfDelivery { CostOfDeliveryId = 12, WeightKg = 11, CostPln = 270 },
                new CostOfDelivery { CostOfDeliveryId = 13, WeightKg = 12, CostPln = 293 },
                new CostOfDelivery { CostOfDeliveryId = 14, WeightKg = 13, CostPln = 315 },
                new CostOfDelivery { CostOfDeliveryId = 15, WeightKg = 14, CostPln = 338 },
                new CostOfDelivery { CostOfDeliveryId = 16, WeightKg = 15, CostPln = 360 },
                new CostOfDelivery { CostOfDeliveryId = 17, WeightKg = 16, CostPln = 382 },
                new CostOfDelivery { CostOfDeliveryId = 18, WeightKg = 17, CostPln = 405 },
                new CostOfDelivery { CostOfDeliveryId = 19, WeightKg = 18, CostPln = 427 },
                new CostOfDelivery { CostOfDeliveryId = 20, WeightKg = 19, CostPln = 450 },
                new CostOfDelivery { CostOfDeliveryId = 21, WeightKg = 20, CostPln = 472 },
                new CostOfDelivery { CostOfDeliveryId = 22, WeightKg = 21, CostPln = 494 },
                new CostOfDelivery { CostOfDeliveryId = 23, WeightKg = 22, CostPln = 517 },
                new CostOfDelivery { CostOfDeliveryId = 24, WeightKg = 23, CostPln = 539 },
                new CostOfDelivery { CostOfDeliveryId = 25, WeightKg = 24, CostPln = 562 },
                new CostOfDelivery { CostOfDeliveryId = 26, WeightKg = 25, CostPln = 584 },
                new CostOfDelivery { CostOfDeliveryId = 27, WeightKg = 26, CostPln = 606 },
                new CostOfDelivery { CostOfDeliveryId = 28, WeightKg = 27, CostPln = 629 },
                new CostOfDelivery { CostOfDeliveryId = 29, WeightKg = 28, CostPln = 651 },
                new CostOfDelivery { CostOfDeliveryId = 30, WeightKg = 29, CostPln = 674 },
                new CostOfDelivery { CostOfDeliveryId = 31, WeightKg = 30, CostPln = 696 }
            );
        }
    }
}
