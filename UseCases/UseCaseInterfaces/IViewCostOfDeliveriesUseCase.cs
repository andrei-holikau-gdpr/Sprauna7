using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewCostOfDeliveriesUseCase
    {
        IEnumerable<CostOfDelivery> Execute();
    }
}