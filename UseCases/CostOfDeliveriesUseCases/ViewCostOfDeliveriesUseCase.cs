using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.CostOfDeliveriesUseCases
{
    public class ViewCostOfDeliveriesUseCase : IViewCostOfDeliveriesUseCase
    {
        private readonly ICostOfDeliveryRepository costOfDeliveryRepository;

        public ViewCostOfDeliveriesUseCase(ICostOfDeliveryRepository costOfDeliveryRepository)
        {
            this.costOfDeliveryRepository = costOfDeliveryRepository;
        }
        public IEnumerable<CostOfDelivery> Execute()
        {
            return costOfDeliveryRepository.GetCostOfDeliveries();
        }
    }
}
