using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.PurchasesUseCases
{
    public class ViewPurchasesUseCase : IViewPurchasesUseCase
    {
        private readonly IPurchaseRepository purchaseRepository;

        public ViewPurchasesUseCase(IPurchaseRepository purchaseRepository)
        {
            this.purchaseRepository = purchaseRepository;
        }

        public IEnumerable<Purchase> Execute()
        {
            return purchaseRepository.GetPurchases();
        }

        public IEnumerable<Purchase> Execute(string currentUserId)
        {
            return purchaseRepository.GetPurchasesByUser(currentUserId);
        }
    }
}
