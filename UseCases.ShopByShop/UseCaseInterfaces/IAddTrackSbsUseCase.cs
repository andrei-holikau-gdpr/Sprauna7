using CoreBusiness.ShopByShop.Models;

namespace UseCases.ShopByShop.UseCaseInterfaces
{
    public interface IAddTrackSbsUseCase
    {
        Task<int?> ExecuteAsync(TrackItem trackItem);
    }
}