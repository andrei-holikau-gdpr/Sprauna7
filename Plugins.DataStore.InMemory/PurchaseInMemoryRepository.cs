using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using static CoreBusiness.ComponentEnums;

namespace Plugins.DataStore.InMemory
{
    public class PurchaseInMemoryRepository : IPurchaseRepository
    {
        private List<Purchase> purchases;
        public PurchaseInMemoryRepository()
        {
            purchases = new List<Purchase>()
            {
                new Purchase{
                    PurchaseId = 1,
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",
                    Surname = "Иванов",
                    Name = "Иван",
                    Shop = "https://allegro.pl/",
                    CombineParcels = CombineParcels.SendWithUnit,
                    AgreeWithTools = true,
                    Description = "Покупка 1",
                    TrackNumber = DateTime.UtcNow.ToString(),

                    // Relations

                    DepartmentDeliveryParcelId= 1,
                    ReceiverId= 1,
                    },
                new Purchase{
                    PurchaseId = 2,
                    Surname = "Новиков",
                    Name = "Иван",
                    Shop = "https://allegro.pl/",

                    CombineParcels = CombineParcels.SendWithoutUnit,
                    AgreeWithTools = true,
                    Description = "Покупка 2",
                    TrackNumber = DateTime.UtcNow.ToString(),

                    // Relations

                    DepartmentDeliveryParcelId = 1,
                    ReceiverId= 1,
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2"
                    //CurrentUserId = "36f6f18a-e9e2-4b08-968c-b6de21c60df4"
                },
                new Purchase{
                    PurchaseId = 3,
                    Surname = "Сидоров",
                    Name = "Иван",
                    Shop = "https://allegro.pl/",
                    CombineParcels = CombineParcels.SendWithoutUnit,
                    AgreeWithTools = true,
                    Description = "Покупка 2",
                    TrackNumber = DateTime.UtcNow.ToString(),
                    
                    // Relations

                    DepartmentDeliveryParcelId = 2,
                    ReceiverId = 2,
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2"
                },
                new Purchase{
                    PurchaseId = 4,
                    Surname = "Сидоров",
                    Name = "Иван",
                    Shop = "https://allegro.pl/",
                    CombineParcels = CombineParcels.SendWithoutUnit,
                    AgreeWithTools = true,
                    Description = "Покупка 2",
                    TrackNumber = DateTime.UtcNow.ToString(),
                    
                    // Relations

                    DepartmentDeliveryParcelId = 2,
                    ReceiverId = 2,
                    CurrentUserId = "4"
                },
            };
        }

        public int AddPurchase(Purchase purchase)
        {
            purchase.TrackNumber = purchase.TrackNumber;

            if (purchases.Any(
                x => x.Name.Equals(purchase.Name, 
                    StringComparison.OrdinalIgnoreCase))) 
                return 0;

            if (purchases != null && purchases.Count > 0)
            {
                var maxId = purchases.Max(x => x.PurchaseId);
                purchase.PurchaseId = maxId + 1;
            }
            else
            {
                purchase.PurchaseId = 1;
            }

            purchases?.Add(purchase);

            return purchase.PurchaseId;
        }
        public void UpdatePurchase(Purchase purchase)
        {
            var itemToUpdate = GetPurchaseById(purchase.PurchaseId);
            if (itemToUpdate != null)
            {
                itemToUpdate.SbsTrackId = purchase.SbsTrackId;

                itemToUpdate.CurrentUserId = purchase.CurrentUserId;
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
            }
        }

        public IEnumerable<Purchase> GetPurchases() 
            => purchases;


#pragma warning disable CS8766
        // ToDo: warning CS8766
        public IEnumerable<Purchase>? GetPurchasesByUser( string currentUserId )
        {
            if (string.IsNullOrWhiteSpace(currentUserId)){
                return null;
            } else
            {
                return purchases.Where<Purchase>(x => x.CurrentUserId == currentUserId);                
            }
        }

        public Purchase? GetPurchaseById(int purchaseId)
        {
            if (purchaseId <= 0)
            {
                return null;
            }
            else
            {
                var purchase = purchases.FirstOrDefault(x => x.PurchaseId == purchaseId);
                //purchase.ProductSps = pro
                return purchase;
            }
        }
#pragma warning restore CS8766

        public void DeletePurchase(int purchaseId, string currentUserId)
        {
            var item = GetPurchaseById(purchaseId);
            if (item != null && item.CurrentUserId == currentUserId)
            {
                purchases?.Remove(item);
            } else
            {
                return;
            }
        }

        public IEnumerable<Purchase> GetPurchasesByPackegeId(int PackegeId)
        {
            throw new NotImplementedException();
        }
    }
}
