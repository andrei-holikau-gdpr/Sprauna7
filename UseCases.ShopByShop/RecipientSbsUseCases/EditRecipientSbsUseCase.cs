using CoreBusiness.ShopByShop.Models;
using UseCases.ShopByShop.InterfacesRepositories;
using UseCases.ShopByShop.UseCaseInterfaces;

namespace UseCases.ShopByShop.RecipientSbsUseCases
{
    public class EditRecipientSbsUseCase : IEditRecipientSbsUseCase
    {
        private readonly IRecipientRepository recipientRepository;

        public EditRecipientSbsUseCase(IRecipientRepository recipientRepository)
        {
            this.recipientRepository = recipientRepository;
        }

        public async Task<bool> ExecuteAsync(RecipientItem recipientItem)
        {
            return await recipientRepository.UpdateRecipientAsync(recipientItem);
        }
    }
}
