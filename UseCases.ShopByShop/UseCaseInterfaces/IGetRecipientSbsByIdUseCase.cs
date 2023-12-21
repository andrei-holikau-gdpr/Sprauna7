using CoreBusiness.ShopByShop.Models;

namespace UseCases.ShopByShop.UseCaseInterfaces
{
    public interface IGetRecipientSbsByIdUseCase
    {
        Task<RecipientItem> ExecuteAsync(int Id);
    }
}