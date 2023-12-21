using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetProductsSpByPurchaseUseCase
    {
        IEnumerable<ProductSp> Execute(int purchaseId);
    }
}