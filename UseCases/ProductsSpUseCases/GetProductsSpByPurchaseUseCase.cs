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
    public class GetProductsSpByPurchaseUseCase : IGetProductsSpByPurchaseUseCase
    {
        private readonly IProductSpRepository productSpRepository;

        public GetProductsSpByPurchaseUseCase(IProductSpRepository productSpRepository)
        {
            this.productSpRepository = productSpRepository;
        }

        public IEnumerable<ProductSp> Execute(int purchaseId)
        {
            return productSpRepository.GetProductSpByPurchase(purchaseId);
        }
    }
}
