using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> GetPurchases();
        IEnumerable<Purchase> GetPurchasesByUser(string currentUserId);
        int AddPurchase(Purchase purchase);
        void UpdatePurchase(Purchase purchase);
        Purchase GetPurchaseById(int purchaseId);
        void DeletePurchase(int purchaseId, string currentUserId);
    }
}
