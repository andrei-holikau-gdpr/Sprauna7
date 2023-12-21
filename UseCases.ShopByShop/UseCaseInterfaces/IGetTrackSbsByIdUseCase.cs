using CoreBusiness.ShopByShop.Models;

namespace UseCases.ShopByShop.UseCaseInterfaces
{
    public interface IGetTrackSbsByIdUseCase
    {
        Task<TrackItem> ExecuteAsync(int Id);
    }
}