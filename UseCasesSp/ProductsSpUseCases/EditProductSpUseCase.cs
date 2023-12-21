using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsSpUseCases
{
    public class EditProductSpUseCase : IEditProductSpUseCase
    {
        #region const 

        #endregion
        #region private fields

        private readonly IProductSpRepository productSpRepository;

        #endregion

        #region override methods

        public EditProductSpUseCase(IProductSpRepository productSpRepository)
        {
            this.productSpRepository = productSpRepository;
        }

        #endregion
        #region private methods

        public void Execute(ProductSp productSp)
        {
            productSpRepository.UpdateProductSp(productSp);
        }

        #endregion
    }
}
