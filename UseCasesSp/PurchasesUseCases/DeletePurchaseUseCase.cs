using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.PurchasesUseCases
{
    public class DeletePurchaseUseCase : IDeletePurchaseUseCase
    {
        private readonly IPurchaseRepository purchaseRepository;

        public DeletePurchaseUseCase(IPurchaseRepository purchaseRepository)
        {
            this.purchaseRepository = purchaseRepository;
        }
        public void Delete(int purchaseId, string currentUserId)
        {
            purchaseRepository.DeletePurchase(purchaseId, currentUserId);
        }
    }
}
