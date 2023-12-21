using CoreBusiness.ShopByShop.Models;

namespace UseCases.ShopByShop.UseCaseInterfaces
{
    public interface IDeleteTrackSbsUseCase
    {
        Task<bool> ExecuteAsync(int id);
    }
}