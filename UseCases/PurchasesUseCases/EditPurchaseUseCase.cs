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
    public class EditPurchaseUseCase : IEditPurchaseUseCase
    {

        #region const 

        #endregion
        #region private fields

        private readonly IPurchaseRepository purchaseRepository;

        #endregion

        #region override methods

        public EditPurchaseUseCase(IPurchaseRepository purchaseRepository)
        {
            this.purchaseRepository = purchaseRepository;
        }

        #endregion
        #region private methods

        public void Execute(Purchase purchase)
        {
            purchaseRepository.UpdatePurchase(purchase);
        }

        #endregion
    }
}
