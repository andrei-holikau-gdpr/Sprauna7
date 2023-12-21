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
    public class AddPurchaseUseCase : IAddPurchaseUseCase
    {
        private readonly IPurchaseRepository purchaseRepository;

        public AddPurchaseUseCase(IPurchaseRepository purchaseRepository)
        {
            this.purchaseRepository = purchaseRepository;
        }
        public int Execute(Purchase purchase)
        {
            return purchaseRepository.AddPurchase(purchase);
        }
    }
}
