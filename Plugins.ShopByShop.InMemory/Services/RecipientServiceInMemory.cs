using CoreBusiness.ShopByShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.ShopByShop.InterfacesRepositories;

namespace Plugins.ShopByShop.InMemory.Services
{
    public class RecipientServiceInMemory : IRecipientRepository
    {
        #region Private Fields
        private RecipientsJson recipientksJsonFake;
        private List<RecipientItem> recipientsFake;
        #endregion
        // ---
        #region Public Methods
        public RecipientServiceInMemory()
        {
            recipientsFake = new List<RecipientItem>()
            {
                new RecipientItem{
                    Id = 1,
                    Email = "Email 1",
                    Phone = "Phone 1",
                    FirstName = "",
                    MiddleName ="MiddleName",
                    LastName = "LastName",
                    Birthdate = DateTime.Now
                },

            };

            recipientksJsonFake = new RecipientsJson
            {
                Success = true,
                Data = new RecipientJsonData
                {
                    Recipients = new Recipients()
                    {
                        CurrentPage = 1,
                        Data = recipientsFake
                    }
                },
                Message = ""
            };
        }

#pragma warning disable CS1998
        public async Task<int?> CreateRecipientAsync(RecipientItem recipientItem)
        {
            if (recipientsFake.Any(x => x.Id.Equals(recipientItem.Id)))
                return -1;

            if (recipientsFake != null && recipientsFake.Count > 0)
            {
                var maxId = recipientsFake.Max(x => x.Id);
                recipientItem.Id = maxId + 1;
            }
            else
            {
                recipientItem.Id = 1;
            }

            recipientsFake?.Add(recipientItem);

            return recipientItem.Id;
        }

        public async Task<bool> DeleteRecipientAsync(int id)
        {
            var item = await GetRecipientByIdAsync(id);
            if (item == null)
            {
                return false;
            }
            else
            {
                recipientsFake?.Remove(item);
                return true;
            }
        }

        public async Task<IEnumerable<RecipientItem>?> GetRecipientsAsync()
        {
            return recipientksJsonFake?.Data?.Recipients?.Data;
        }

        public async Task<RecipientItem> GetInfoRecipientAsync(int id)
        {
            return await GetRecipientByIdAsync(id);
        }

        public async Task<bool> UpdateRecipientAsync(RecipientItem newRecipient)
        {
            var recipientToUpdate = await GetRecipientByIdAsync((int)newRecipient?.Id);
            if (recipientToUpdate == null)
            {
                return false;
            }            
            else
            {
                recipientToUpdate.Id = newRecipient.Id;
                recipientToUpdate.Email = newRecipient.Email;
                recipientToUpdate.Phone = newRecipient.Phone;
                recipientToUpdate.FirstName = newRecipient.FirstName;

                return true;
            }
        }

        public async Task<bool> RecovereRecipientAsync(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
        // ---
        #region Private Methods
        private async Task<RecipientItem> GetRecipientByIdAsync(int id)
        {
            return recipientsFake?.FirstOrDefault(x => x.Id == id);
        }
        #endregion

#pragma warning restore CS1998
    }
}
