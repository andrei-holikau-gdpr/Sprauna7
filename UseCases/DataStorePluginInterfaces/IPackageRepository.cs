using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IPackageRepository
    {
        IEnumerable<Package> GetPackages();
        void AddPackage(Package package);
        void UpdatePackage(Package package);
        Package GetPackageById(int packageyId);
        void DeletePackage(int packageId);

        IEnumerable<Package> GetPackageByStatus(StatusesPackage statusesPackage);
    }
}
