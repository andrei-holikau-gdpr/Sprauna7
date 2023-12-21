using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CostOfDeliveryInMemoryRepository : ICostOfDeliveryRepository
    {
        private List<CostOfDelivery> costOfDeliveries;
        public CostOfDeliveryInMemoryRepository()
        {
            costOfDeliveries = new List<CostOfDelivery>()
            {
                new CostOfDelivery{ CostOfDeliveryId = 1,   WeightKg = 0.5,   CostPln = 44},
                new CostOfDelivery{ CostOfDeliveryId = 2,   WeightKg = 1,     CostPln = 63},
                new CostOfDelivery{ CostOfDeliveryId = 3,   WeightKg = 2,     CostPln = 76},
                new CostOfDelivery{ CostOfDeliveryId = 4,   WeightKg = 3,     CostPln = 84},
                new CostOfDelivery{ CostOfDeliveryId = 5,   WeightKg = 4,     CostPln = 114},
                new CostOfDelivery{ CostOfDeliveryId = 6,   WeightKg = 5,     CostPln = 136},
                new CostOfDelivery{ CostOfDeliveryId = 7,   WeightKg = 6,     CostPln = 158},
                new CostOfDelivery{ CostOfDeliveryId = 8,   WeightKg = 7,     CostPln = 181},
                new CostOfDelivery{ CostOfDeliveryId = 9,   WeightKg = 8,     CostPln = 203},
                new CostOfDelivery{ CostOfDeliveryId = 10,  WeightKg = 9,     CostPln = 226},
                new CostOfDelivery{ CostOfDeliveryId = 10,  WeightKg = 10,    CostPln = 248},
                new CostOfDelivery{ CostOfDeliveryId = 11,  WeightKg = 11,    CostPln = 270},
                new CostOfDelivery{ CostOfDeliveryId = 12,  WeightKg = 12,    CostPln = 293},
                new CostOfDelivery{ CostOfDeliveryId = 13,  WeightKg = 13,    CostPln = 315},
                new CostOfDelivery{ CostOfDeliveryId = 14,  WeightKg = 14,    CostPln = 338},
                new CostOfDelivery{ CostOfDeliveryId = 15,  WeightKg = 15,    CostPln = 360},
                new CostOfDelivery{ CostOfDeliveryId = 16,  WeightKg = 16,    CostPln = 382},
                new CostOfDelivery{ CostOfDeliveryId = 17,  WeightKg = 17,    CostPln = 405},
                new CostOfDelivery{ CostOfDeliveryId = 18,  WeightKg = 18,    CostPln = 427},
                new CostOfDelivery{ CostOfDeliveryId = 19,  WeightKg = 19,    CostPln = 450},
                new CostOfDelivery{ CostOfDeliveryId = 20,  WeightKg = 20,    CostPln = 472},
                new CostOfDelivery{ CostOfDeliveryId = 21,  WeightKg = 21,    CostPln = 494},
                new CostOfDelivery{ CostOfDeliveryId = 22,  WeightKg = 22,    CostPln = 517},
                new CostOfDelivery{ CostOfDeliveryId = 23,  WeightKg = 23,    CostPln = 539},
                new CostOfDelivery{ CostOfDeliveryId = 24,  WeightKg = 24,    CostPln = 562},
                new CostOfDelivery{ CostOfDeliveryId = 25,  WeightKg = 25,    CostPln = 584},
                new CostOfDelivery{ CostOfDeliveryId = 26,  WeightKg = 26,    CostPln = 606},
                new CostOfDelivery{ CostOfDeliveryId = 27,  WeightKg = 27,    CostPln = 629},
                new CostOfDelivery{ CostOfDeliveryId = 28,  WeightKg = 28,    CostPln = 651},
                new CostOfDelivery{ CostOfDeliveryId = 29,  WeightKg = 29,    CostPln = 674},
                new CostOfDelivery{ CostOfDeliveryId = 30,  WeightKg = 30,    CostPln = 696}
            };
        }

        public IEnumerable<CostOfDelivery> GetCostOfDeliveries()
        {
            return costOfDeliveries;
        }
    }
}
