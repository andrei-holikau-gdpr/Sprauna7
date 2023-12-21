using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewInvoicesUseCase
    {
        IEnumerable<Invoice> Execute();
    }
}