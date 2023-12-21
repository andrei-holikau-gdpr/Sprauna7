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
    public class AddProductSpUseCase : IAddProductSpUseCase
    {
        private readonly IProductSpRepository productSpRepository;

        public AddProductSpUseCase(IProductSpRepository productSpRepository)
        {
            this.productSpRepository = productSpRepository;
        }
        public void Execute(ProductSp productSp)
        {
            productSpRepository.AddProductSp(productSp);
        }
    }
}
