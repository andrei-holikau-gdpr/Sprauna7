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
    public class GetPackagesByStatusUseCase : IGetPackagesByStatusUseCase
    {
        #region const 

        #endregion
        #region private fields

        private readonly IPackageRepository packageRepository;

        #endregion

        #region override methods

        public GetPackagesByStatusUseCase(IPackageRepository packageRepository)
        {
            this.packageRepository = packageRepository;
        }

        #endregion
        #region private methods

        public IEnumerable<Package> Execute(StatusesPackage statusesPackage)
        {
            return packageRepository.GetPackageByStatus(statusesPackage);
        }

        #endregion
    }
}
