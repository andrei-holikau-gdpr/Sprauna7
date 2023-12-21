using CoreBusiness.ShopByShop.Models;

namespace UseCases.ShopByShop.UseCaseInterfaces
{
    public interface IViewRecipientsSbsUseCase
    {
        Task<IEnumerable<RecipientItem>?> ExecuteAsync();
    }
}