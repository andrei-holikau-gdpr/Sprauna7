using CoreBusiness.ShopByShop.Models;

namespace UseCases.ShopByShop.InterfacesRepositories
{
    public interface ITrackRepository
    {
        /// <summary>
        /// Получение всех треков пользователя
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TrackItem>?> GetTracksAsync();

        /// <summary>
        /// Создание трека
        /// </summary>
        /// <returns> string "id" </returns>
        public Task<int?> CreateTrackAsync(TrackItem trackItem);

        /// <summary>
        /// Update track
        /// </summary>
        /// <returns></returns>
        public Task<bool> UpdateTrackAsync(TrackItem trackItem);

        /// <summary>
        /// Soft delete track
        /// </summary>
        /// <returns></returns>
        public Task<bool> DeleteTrackAsync(int Id);

        // Show info track
        public Task<TrackItem> ShowInfoTrackAsync(int Id);

        // Recover track
        public Task<bool> RecoverTrackAsync(int Id);


    }
}