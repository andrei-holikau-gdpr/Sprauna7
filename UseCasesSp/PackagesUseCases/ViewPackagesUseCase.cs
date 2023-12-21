using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.PackagesUseCases
{
    public class ViewPackagesUseCase : IViewPackagesUseCase
    {
        private readonly IPackageRepository packageRepository;

        public ViewPackagesUseCase(IPackageRepository packageRepository)
        {
            this.packageRepository = packageRepository;
        }
        public IEnumerable<Package> Execute()
        {
            return packageRepository.GetPackages();
        }
    }
}
