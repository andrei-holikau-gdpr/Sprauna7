using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class PackageRepository : IPackageRepository
    {
        private readonly SpraunaContext db;

        public PackageRepository(SpraunaContext db)
        {
            this.db = db;
        }
        public void AddPackage(Package package)
        {
            db.Packages.Add(package);
            db.SaveChanges();
        }

        public void DeletePackage(int packageId)
        {
            var package = db.Packages?.Find(packageId);

            if (package == null) {
                return;
            }

            db.Packages?.Remove(package);
            db.SaveChanges();
        }

#pragma warning disable CS8766
        // ToDo: CS8766
        public Package? GetPackageById(int packageyId)
        {
            return db.Packages?.Find(packageyId);
        }
#pragma warning restore CS8766

        public IEnumerable<Package> GetPackageByStatus(StatusesPackage statusesPackage)
        {
            return db.Packages.Where(x => x.Status == statusesPackage).ToList();
        }

        public IEnumerable<Package> GetPackages()
        {
            return db.Packages.ToList();
        }

        public void UpdatePackage(Package package)
        {
            var itemToUpdate = db.Packages.Find(package.PackageId);

            if (itemToUpdate != null)
            {
                // ToDo: Заполнить все поля.
                //throw new InvalidOperationException();
                itemToUpdate.PackageId = package.PackageId;
                itemToUpdate.CurrentUserId = package.CurrentUserId;
                itemToUpdate.Status = package.Status;
                itemToUpdate.NumberPackage = package.NumberPackage;
                itemToUpdate.TrackNumber = package.TrackNumber;
                itemToUpdate.Weight = package.Weight;
                itemToUpdate.PricePLN = package.PricePLN;
                itemToUpdate.PriceBYN = package.PriceBYN;
                itemToUpdate.IsCollectivePackage = package.IsCollectivePackage;
                
                itemToUpdate.InvoiceId = package.InvoiceId;

                if (package.InvoiceId > 0)
                {
                    var newInvoice = db.Invoices.Find(package.InvoiceId);
                    if (package.Invoice == null)
                    {
                        package.Invoice = new Invoice();
                        if (package.Invoice.InvoiceId == 0)
                        {
                            package.Invoice.PackageId = package.PackageId;
                            package.Invoice.CurrentUserId = package.CurrentUserId;

                            // ToDo: Удалить заглушку
                            package.Invoice.AccountNo = "123";

                            bool validationResult = CheckRequiredFields(package.Invoice);
                            if (validationResult)
                            {
                                db.Invoices.Add(package.Invoice);
                                db.SaveChanges();
                            }
                            else
                            {
                                throw new Exception("Invoice is bad for save DB.");
                            }
                        }
                    }
                }
            }
            // itemToUpdate.Invoice = package.Invoice;
            itemToUpdate.Purchases = package.Purchases;

            itemToUpdate.Description = package.Description;

            db.SaveChanges();
        }

        public bool CheckRequiredFields(Invoice invoice)
        {
            if (string.IsNullOrWhiteSpace(invoice.InvoiceNo))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(invoice.AccountNo))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(invoice.Url))
            {
                return false;
            }

            return true;
        }
    
    }
}