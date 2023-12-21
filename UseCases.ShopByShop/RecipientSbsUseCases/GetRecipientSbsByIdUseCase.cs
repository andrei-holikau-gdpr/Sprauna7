using CoreBusiness.ShopByShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.ShopByShop.InterfacesRepositories;
using UseCases.ShopByShop.UseCaseInterfaces;

namespace UseCases.ShopByShop.RecipientSbsUseCases
{
    public class GetRecipientSbsByIdUseCase : IGetRecipientSbsByIdUseCase
    {
        private readonly IRecipientRepository recipientRepository;

        public GetRecipientSbsByIdUseCase(IRecipientRepository recipientRepository)
        {
            this.recipientRepository = recipientRepository;
        }

        public async Task<RecipientItem> ExecuteAsync(int Id)
        {
            return await recipientRepository.GetInfoRecipientAsync(Id);
        }
    }
}
