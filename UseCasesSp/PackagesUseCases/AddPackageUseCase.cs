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
    public class AddPackageUseCase : IAddPackageUseCase
    {
        private readonly IPackageRepository packageRepository;

        public AddPackageUseCase(IPackageRepository packageRepository)
        {
            this.packageRepository = packageRepository;
        }
        public void Execute(Package package)
        {
            packageRepository.AddPackage(package);
        }
    }
}
