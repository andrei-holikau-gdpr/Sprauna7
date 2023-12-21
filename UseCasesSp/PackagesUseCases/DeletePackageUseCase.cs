using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.PackagesUseCases
{
    public class DeletePackageUseCase : IDeletePackageUseCase
    {
        private readonly IPackageRepository packageRepository;

        public DeletePackageUseCase(IPackageRepository packageRepository)
        {
            this.packageRepository = packageRepository;
        }
        public void Delete(int packageId)
        {
            packageRepository.DeletePackage(packageId);
        }
    }
}
