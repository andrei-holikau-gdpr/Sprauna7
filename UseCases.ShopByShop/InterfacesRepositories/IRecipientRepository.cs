using CoreBusiness.ShopByShop.Models;

namespace UseCases.ShopByShop.InterfacesRepositories
{
    public interface IRecipientRepository
    {
        /// <summary>
        /// Получение всех получателей
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<RecipientItem>?> GetRecipientsAsync();

        /// <summary>
        /// Создание получателя
        /// </summary>
        /// <returns> string "id" </returns>
        public Task<int?> CreateRecipientAsync(RecipientItem recipientItem);

        /// <summary>
        /// Update recipient
        /// </summary>
        /// <returns></returns>
        public Task<bool> UpdateRecipientAsync(RecipientItem newRecipient);

        /// <summary>
        /// Soft delete recipient
        /// </summary>
        /// <returns></returns>
        public Task<bool> DeleteRecipientAsync(int id);

        // Show info recipient
        public Task<RecipientItem> GetInfoRecipientAsync(int id);

        // Recover recipient
        public Task<bool> RecovereRecipientAsync(int id);

    }
}