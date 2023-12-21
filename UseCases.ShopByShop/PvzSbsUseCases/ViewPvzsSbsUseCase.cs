using CoreBusiness.ShopByShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.ShopByShop.InterfacesRepositories;
using UseCases.ShopByShop.UseCaseInterfaces;

namespace UseCases.ShopByShop.PvzSbsUseCases
{
    public class ViewPvzsSbsUseCase : IViewPvzsSbsUseCase
    {
        private readonly IPvzRepository pvzRepository;

        public ViewPvzsSbsUseCase(IPvzRepository pvzRepository)
        {
            this.pvzRepository = pvzRepository;
        }

        public async Task<IEnumerable<PvzItem>?> ExecuteAsync()
        {
            return await pvzRepository.GetPvzsAsync();
        }
    }
}
