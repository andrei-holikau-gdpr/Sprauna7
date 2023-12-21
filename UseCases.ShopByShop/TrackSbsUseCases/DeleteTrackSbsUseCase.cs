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
    public class DeleteTrackSbsUseCase : IDeleteTrackSbsUseCase
    {
        private readonly ITrackRepository trackRepository;

        public DeleteTrackSbsUseCase(ITrackRepository trackRepository)
        {
            this.trackRepository = trackRepository;
        }

        public async Task<bool> ExecuteAsync(int id)
        {
            return await trackRepository.DeleteTrackAsync(id);
        }
    }
}
