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
    public class EditTrackSbsUseCase : IEditTrackSbsUseCase
    {
        private readonly ITrackRepository trackRepository;

        public EditTrackSbsUseCase(ITrackRepository trackRepository)
        {
            this.trackRepository = trackRepository;
        }

        public async Task<bool> ExecuteAsync(TrackItem trackItem)
        {
            return await trackRepository.UpdateTrackAsync(trackItem);
        }
    }
}
