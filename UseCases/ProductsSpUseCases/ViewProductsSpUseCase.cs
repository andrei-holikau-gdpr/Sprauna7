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
    public class ViewProductsSpUseCase : IViewProductsSpUseCase
    {
        private readonly IProductSpRepository productSpRepository;

        public ViewProductsSpUseCase(IProductSpRepository productSpRepository)
        {
            this.productSpRepository = productSpRepository;
        }
        public IEnumerable<ProductSp> Execute()
        {
            return productSpRepository.GetProductsSp();
        }
    }
}
