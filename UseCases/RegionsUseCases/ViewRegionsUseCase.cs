using CoreBusiness;
using Plugins.DataStore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.UseCaseInterfaces;

namespace UseCases.RegionsUseCases
{
    public class ViewRegionsUseCase : IViewRegionsUseCase
    {
        private readonly IRegionRepository regionRepository;

        public ViewRegionsUseCase(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        public IEnumerable<Region> Execute()
        {
            return regionRepository.GetRegions();
        }
    }
}
