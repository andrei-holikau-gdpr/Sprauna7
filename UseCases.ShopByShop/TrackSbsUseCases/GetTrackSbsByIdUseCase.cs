using CoreBusiness;
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
    public class GetTrackSbsByIdUseCase : IGetTrackSbsByIdUseCase
    {
        private readonly ITrackRepository trackRepository;

        public GetTrackSbsByIdUseCase(ITrackRepository trackRepository)
        {
            this.trackRepository = trackRepository;
        }

        public async Task<TrackItem> ExecuteAsync(int Id)
        {
            return await trackRepository.ShowInfoTrackAsync(Id);
        }
    }
}
