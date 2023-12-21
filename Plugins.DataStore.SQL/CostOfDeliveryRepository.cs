using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class CostOfDeliveryRepository : ICostOfDeliveryRepository
    {
        private readonly SpraunaContext db;

        public CostOfDeliveryRepository(SpraunaContext db)
        {
            this.db = db;
        }
        public IEnumerable<CostOfDelivery> GetCostOfDeliveries()
        {
            return db.CostOfDeliveries.ToList(); ;
        }
    }
}
