using CoreBusiness.ShopByShop.Models;
using UseCases.ShopByShop.InterfacesRepositories;
using UseCases.ShopByShop.UseCaseInterfaces;

namespace UseCases.ShopByShop.RecipientSbsUseCases
{
    public class AddRecipientSbsUseCase : IAddRecipientSbsUseCase
    {
        private readonly IRecipientRepository recipientRepository;

        public AddRecipientSbsUseCase(IRecipientRepository recipientRepository)
        {
            this.recipientRepository = recipientRepository;
        }

        public async Task<int?> ExecuteAsync(RecipientItem recipientItem)
        {
            return await recipientRepository.CreateRecipientAsync(recipientItem);
        }
    }
}
