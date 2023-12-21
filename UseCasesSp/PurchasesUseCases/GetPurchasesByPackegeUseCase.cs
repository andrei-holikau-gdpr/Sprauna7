using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;
using UseCasesSp.UseCaseInterfaces;

namespace UseCases.PurchasesUseCases
{
    public class GetPurchasesByPackegeIdUseCase : IGetPurchasesByPackegeIdUseCase
    {
        private readonly IPurchaseRepository purchaseRepository;

        public GetPurchasesByPackegeIdUseCase(IPurchaseRepository purchaseRepository)
        {
            this.purchaseRepository = purchaseRepository;
        }

        public IEnumerable<Purchase> Execute()
        {
            return purchaseRepository.GetPurchases();
        }

        public IEnumerable<Purchase> Execute(int PackegeId)
        {
            return purchaseRepository.GetPurchasesByPackegeId(PackegeId);
        }
    }
}
