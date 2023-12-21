using CoreBusiness.ShopByShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.ShopByShop.InterfacesRepositories;
using UseCases.ShopByShop.UseCaseInterfaces;

namespace UseCases.ShopByShop.TrackSbsUseCases
{
    public class AddTrackSbsUseCase : IAddTrackSbsUseCase
    {
        private readonly ITrackRepository trackRepository;

        public AddTrackSbsUseCase(ITrackRepository trackRepository)
        {
            this.trackRepository = trackRepository;
        }

        public async Task<int?> ExecuteAsync(TrackItem trackItem)
        {
            return await trackRepository.CreateTrackAsync(trackItem);
        }
    }
}
