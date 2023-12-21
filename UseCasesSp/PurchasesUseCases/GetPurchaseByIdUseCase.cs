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
    public class GetPurchaseByIdUseCase : IGetPurchaseByIdUseCase
    {

        private readonly IPurchaseRepository purchaseRepository;

        public GetPurchaseByIdUseCase(IPurchaseRepository purchaseRepository)
        {
            this.purchaseRepository = purchaseRepository;
        }

        public Purchase Execute(int purchaseId)
        {
            return purchaseRepository.GetPurchaseById(purchaseId);
        }

    }
}
