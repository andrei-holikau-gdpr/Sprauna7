using CoreBusiness.ShopByShop.Models;

namespace UseCases.ShopByShop.UseCaseInterfaces
{
    public interface IEditTrackSbsUseCase
    {
        Task<bool> ExecuteAsync(TrackItem trackItem);
    }
}