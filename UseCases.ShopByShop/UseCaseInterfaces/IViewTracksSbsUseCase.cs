using CoreBusiness.ShopByShop.Models;

namespace UseCases.ShopByShop.UseCaseInterfaces
{
    public interface IViewTracksSbsUseCase
    {
        Task<IEnumerable<TrackItem>?> ExecuteAsync();
    }
}