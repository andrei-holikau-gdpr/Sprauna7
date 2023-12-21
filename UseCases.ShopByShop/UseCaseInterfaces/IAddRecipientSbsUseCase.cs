using CoreBusiness.ShopByShop.Models;

namespace UseCases.ShopByShop.UseCaseInterfaces
{
    public interface IAddRecipientSbsUseCase
    {
        Task<int?> ExecuteAsync(RecipientItem recipientItem);
    }
}