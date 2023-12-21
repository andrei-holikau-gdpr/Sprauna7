using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using Department = CoreBusiness.DepartmentDeliveryParcel;


namespace Plugins.DataStore.InMemorySp
{
    public class DepartmentDpInMemoryRepository : IDepartmentDpRepository
    {
        private List<DepartmentDeliveryParcel> departments;
        public DepartmentDpInMemoryRepository()
        {
            departments = new List<Department>()
            {
                new Department{ DepartmentDeliveryParcelId = 1,
                    Address = "Витебск, 3-я улица Бядули, 28",
                    AddressForMap = "Европочта Витебск, 3-я улица Бядули, 28", 
                    Description = "Режим работы 10:00 - 21:00",
                    RegionId = 1
                },
                new Department{ DepartmentDeliveryParcelId = 2,
                    Address = "Минск, Сморговский тракт, 7",
                    AddressForMap = "Европочта Минск, Сморговский тракт, 7", 
                    Description = "Режим работы 10:00 - 21:00",
                    RegionId = 2
                }
            };
        }

        public void AddDepartment(Department department)
        {
            if (departments.Any(x => x.Address.Equals(department.Address, StringComparison.OrdinalIgnoreCase))) return;

            if (departments != null && departments.Count > 0)
            {
                var maxId = departments.Max(x => x.DepartmentDeliveryParcelId);
                department.DepartmentDeliveryParcelId = maxId + 1;
            }
            else
            {
                department.DepartmentDeliveryParcelId = 1;
            }

            departments?.Add(department);
        }

        public void UpdateDepartment(Department department)
        {
            Department? itemToUpdate = GetDepartmentById(department.DepartmentDeliveryParcelId);
            if (itemToUpdate != null)
            {
                itemToUpdate.Address = department.Address;
                itemToUpdate.Description = department.Description;
            }
        }


        public IEnumerable<Department> GetDepartments()
        {
            return departments;
        }

        public Department? GetDepartmentById(int departmentId)
        {
            return departments?.FirstOrDefault(x => x.DepartmentDeliveryParcelId == departmentId);
        }

        public IEnumerable<Department>? GetDepartmentDpsByRegion(int regionId)
        {
            return departments?.Where(x => x.RegionId == regionId).ToList();
        }

        public void DeleteDepartment(int departmentId)
        {
            var item = GetDepartmentById(departmentId);
            if (item != null)
            {
                departments?.Remove(item);
            }
        }

    }
}
