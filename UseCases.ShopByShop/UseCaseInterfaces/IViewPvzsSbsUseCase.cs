using CoreBusiness.ShopByShop.Models;

namespace UseCases.ShopByShop.UseCaseInterfaces
{
    public interface IViewPvzsSbsUseCase
    {
        Task<IEnumerable<PvzItem>?> ExecuteAsync();
    }
}