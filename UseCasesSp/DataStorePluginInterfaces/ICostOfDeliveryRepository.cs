using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ICostOfDeliveryRepository
    {
        IEnumerable<CostOfDelivery> GetCostOfDeliveries();
    }
}