using CoreBusiness.ShopByShop.Models;

namespace UseCases.ShopByShop.InterfacesRepositories
{
    public interface IPvzRepository
    {
        public Task<IEnumerable<PvzItem>?> GetPvzsAsync();
    }
}