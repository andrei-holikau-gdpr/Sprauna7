using CoreBusiness.ShopByShop.Models;
using UseCases.ShopByShop.InterfacesRepositories;
using UseCases.ShopByShop.UseCaseInterfaces;

namespace UseCases.ShopByShop.RecipientSbsUseCases
{
    public class DeleteRecipientSbsUseCase : IDeleteRecipientSbsUseCase
    {
        private readonly IRecipientRepository recipientRepository;

        public DeleteRecipientSbsUseCase(IRecipientRepository recipientRepository)
        {
            this.recipientRepository = recipientRepository;
        }

        public async Task<bool> ExecuteAsync(int id)
        {
            return await recipientRepository.DeleteRecipientAsync(id);
        }
    }
}
