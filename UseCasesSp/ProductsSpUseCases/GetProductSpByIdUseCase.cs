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
    public class GetProductSpByIdUseCase : IGetProductSpByIdUseCase
    {
        private readonly IProductSpRepository productSpRepository;

        public GetProductSpByIdUseCase(IProductSpRepository productSpRepository)
        {
            this.productSpRepository = productSpRepository;
        }

        public ProductSp Execute(int productSpId)
        {
            return productSpRepository.GetProductSpById(productSpId);
        }
    }
}
