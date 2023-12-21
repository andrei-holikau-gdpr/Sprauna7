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
    public class DeleteProductSpUseCase : IDeleteProductSpUseCase
    {
        private readonly IProductSpRepository productSpRepository;

        public DeleteProductSpUseCase(IProductSpRepository productSpRepository)
        {
            this.productSpRepository = productSpRepository;
        }
        public void Delete(int productSpId)
        {
            productSpRepository.DeleteProductSp(productSpId);
        }
    }
}
