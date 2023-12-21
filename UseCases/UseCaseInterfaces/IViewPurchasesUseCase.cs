using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewPurchasesUseCase
    {
        IEnumerable<Purchase> Execute();

        IEnumerable<Purchase> Execute(string currentUserId);
    }
}