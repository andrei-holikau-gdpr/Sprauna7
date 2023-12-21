using CoreBusiness.ShopByShop.Models;

namespace UseCases.ShopByShop.UseCaseInterfaces
{
    public interface IEditRecipientSbsUseCase
    {
        Task<bool> ExecuteAsync(RecipientItem recipientItem);
    }
}