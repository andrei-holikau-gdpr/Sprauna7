using CoreBusiness.ShopByShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UseCases.ShopByShop.InterfacesRepositories;
using UseCases.ShopByShop.UseCaseInterfaces;

namespace UseCases.ShopByShop
{
    public class ViewRecipientsSbsUseCase : IViewRecipientsSbsUseCase
    {
        private readonly IRecipientRepository recipientRepository;

        public ViewRecipientsSbsUseCase(IRecipientRepository recipientRepository)
        {
            this.recipientRepository = recipientRepository;
        }

        public async Task<IEnumerable<RecipientItem>?> ExecuteAsync()
        {
            return await recipientRepository.GetRecipientsAsync();
        }
    }
}
