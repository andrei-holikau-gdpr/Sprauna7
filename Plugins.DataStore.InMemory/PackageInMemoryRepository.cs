using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class PackageInMemoryRepository : IPackageRepository
    {
        private List<Package> packages;
        public PackageInMemoryRepository()
        {
            packages = new List<Package>()
            {
                new Package{ PackageId = 1,
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",
                    NumberPackage = "SBS-GP000011572PL", 
                    TrackNumber = "alegro-21ba3630-a85d-11ed-9935-ff5ce5769ce0", 
                    Status = StatusesPackage.CostCalculation, 
                    Weight = 22.1, PricePLN = 10.1, 
                    PriceBYN = 30.1, 
                    IsCollectivePackage = true,
                    InvoiceId = 3,
                    Description = "Описание 1" 
                },
                new Package{ PackageId = 2,
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",
                    NumberPackage = "SBS-SP000011572PL", 
                    TrackNumber = "alegro-31ba3630-a85d-11ed-9935-ff5ce5769ce0", 
                    Status = StatusesPackage.Expected, 
                    Weight = 32.1, PricePLN = 20.1, 
                    PriceBYN = 40.1, 
                    IsCollectivePackage = false,
                    InvoiceId = 2,
                    Description = "Описание 2" 
                },
                new Package{ PackageId = 3,
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",
                    NumberPackage = "SBS-TP000011572PL", 
                    TrackNumber = "alegro-41ba3630-a85d-11ed-9935-ff5ce5769ce0", 
                    Status = StatusesPackage.Problem, 
                    Weight = 42.1, PricePLN = 30.1, 
                    PriceBYN = 50.1, 
                    IsCollectivePackage = false,
                    InvoiceId = 1,
                    Description = "Описание 3" 
                }
            };
        }

        public void AddPackage(Package package)
        {
            if (packages.Any(x => x.NumberPackage.Equals(package.NumberPackage, StringComparison.OrdinalIgnoreCase))) return;

            if (packages != null && packages.Count > 0)
            {
                var maxId = packages.Max(x => x.PackageId);
                package.PackageId = maxId + 1;
            }
            else
            {
                package.PackageId = 1;
            }            

            packages?.Add(package);
        }

        public void UpdatePackage(Package package)
        {
            var itemToUpdate = GetPackageById(package.PackageId);
            if (itemToUpdate != null)
            {
                itemToUpdate.NumberPackage = package.NumberPackage;
                itemToUpdate.Description = package.Description;
            }
        }

        public IEnumerable<Package> GetPackages()
            => packages;

        public IEnumerable<Package>? GetPackagesByUser(string currentUserId)
        {
            if (!string.IsNullOrWhiteSpace(currentUserId))
            {
                return null;
            }
            else
            {
                return packages.Where<Package>(x => x.CurrentUserId == currentUserId);
            }
        }

#pragma warning disable CS8766
        // ToDo: warning CS8766
        public IEnumerable<Package>? GetPackageByStatus(StatusesPackage statusesPackage)
        {
            return packages?.Where(x => x.Status == statusesPackage).ToList();
        }


        public Package? GetPackageById(int packageyId)
        {
            return packages?.FirstOrDefault(x => x.PackageId == packageyId);
        }
#pragma warning restore CS8766


        public void DeletePackage(int packageId)
        {
            var item = GetPackageById(packageId);
            if(item != null)
                packages?.Remove(item);
        }
    }
}
