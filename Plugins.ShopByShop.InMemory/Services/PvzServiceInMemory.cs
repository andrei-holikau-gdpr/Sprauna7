using CoreBusiness.ShopByShop.Models;
using UseCases.ShopByShop.InterfacesRepositories;

namespace Plugins.ShopByShop.InMemory
{
    public class PvzServiceInMemory : IPvzRepository
    {
        private List<PvzItem> pvzsFake;

        #region Public Methods

        public PvzServiceInMemory()
        {
            pvzsFake = new List<PvzItem>()
            {
                new PvzItem{ gipermall_id = 1, value = "Минск", hide = 0 },
                new PvzItem{ gipermall_id = 2, value = "Могилев", hide = 0 },
                new PvzItem{ gipermall_id = 3, value = "Витебск", hide = 0 },
            };
        }

        #pragma warning disable CS1998

        public async Task<IEnumerable<PvzItem>?> GetPvzsAsync()
        {
            return pvzsFake;
        }

        #pragma warning restore CS1998

        #endregion
    }
}