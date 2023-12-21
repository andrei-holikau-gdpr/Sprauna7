using CoreBusiness.ShopByShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.ShopByShop.InterfacesRepositories;
using UseCases.ShopByShop.UseCaseInterfaces;

namespace UseCases.ShopByShop
{
    public class ViewTracksSbsUseCase : IViewTracksSbsUseCase
    {
        private readonly ITrackRepository trackRepository;

        public ViewTracksSbsUseCase(ITrackRepository trackRepository)
        {
            this.trackRepository = trackRepository;
        }

        public async Task<IEnumerable<TrackItem>?> ExecuteAsync()
        {
            return await trackRepository.GetTracksAsync();
        }
    }
}
