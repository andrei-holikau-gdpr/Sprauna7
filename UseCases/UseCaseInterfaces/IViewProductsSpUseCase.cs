using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewProductsSpUseCase
    {
        IEnumerable<ProductSp> Execute();
    }
}