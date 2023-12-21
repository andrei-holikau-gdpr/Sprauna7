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
    public class EditPackageUseCase : IEditPackageUseCase
    {

        #region const 

        #endregion
        #region private fields

        private readonly IPackageRepository packageRepository;

        #endregion

        #region override methods

        public EditPackageUseCase(IPackageRepository packageRepository)
        {
            this.packageRepository = packageRepository;
        }

        #endregion
        #region private methods

        public void Execute(Package package)
        {
            packageRepository.UpdatePackage(package);
        }

        #endregion
    }
}
