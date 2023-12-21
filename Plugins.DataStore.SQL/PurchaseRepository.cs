using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly SpraunaContext db;

        public PurchaseRepository(SpraunaContext db)
        {
            this.db = db;
        }

        public int AddPurchase(Purchase purchase)
        {
            db.Purchases.Add(purchase);
            db.SaveChanges();

            return purchase.PurchaseId;
        }

        public void DeletePurchase(int purchaseId, string currentUserId)
        {
            var item = db.Purchases.Find(purchaseId);

            if (item == null || item.CurrentUserId != currentUserId)
            {
                // ToDo: AddLog Попытка удалить несуществующую или чужую посылку 
                return;
            }
            else
            {
                db.Purchases.Remove(item);
                db.SaveChanges();
            }
        }

#pragma warning disable CS8766
        // ToDo: CS8766
        public Purchase? GetPurchaseById(int purchaseId)
            => db.Purchases?.Find(purchaseId);
#pragma warning restore CS8766

        public IEnumerable<Purchase> GetPurchases()
        {
            return db.Purchases.ToList();
        }

        public IEnumerable<Purchase> GetPurchasesByPackegeId(int PackageId)
        {
            return db.Purchases
                .Where<Purchase>(x => x.PackageId == PackageId)
                .Include(p => p.Receiver)
                .ToList();
        }

        public IEnumerable<Purchase> GetPurchasesByUser(string currentUserId)
        {
            return db.Purchases
                .Where<Purchase>(x => x.CurrentUserId == currentUserId)
                .Include(p => p.Receiver)
                .ToList();
        }

        public void UpdatePurchase(Purchase purchase)
        {
            var itemToUpdate = db.Purchases.Find(purchase.PurchaseId);

            if (itemToUpdate != null)
            {
                itemToUpdate.Surname = purchase.Surname;
                itemToUpdate.Name = purchase.Name;
                itemToUpdate.Shop = purchase.Shop;
                itemToUpdate.CombineParcels = purchase.CombineParcels;
                itemToUpdate.AgreeWithTools = purchase.AgreeWithTools;

                itemToUpdate.Lock = purchase.Lock;

                itemToUpdate.Description = purchase.Description;
                itemToUpdate.TrackNumber = purchase.TrackNumber;

                itemToUpdate.DepartmentDeliveryParcelId = purchase.DepartmentDeliveryParcelId;
                itemToUpdate.ReceiverId = purchase.ReceiverId;

                db.SaveChanges();
            }
        }
    }
}