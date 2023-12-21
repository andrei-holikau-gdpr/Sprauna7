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
    public class GetPackageByIdUseCase : IGetPackageByIdUseCase
    {
        #region private fields

        private readonly IPackageRepository packageRepository;

        #endregion

        #region override methods

        public GetPackageByIdUseCase(IPackageRepository packageRepository)
        {
            this.packageRepository = packageRepository;
        }

        #endregion
        #region private methods

        public Package Execute(int packageId)
        {
            return packageRepository.GetPackageById(packageId);
        }

        #endregion
    }
}
