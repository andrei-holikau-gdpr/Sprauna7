using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using Department = CoreBusiness.DepartmentDeliveryParcel;


namespace Plugins.DataStore.InMemory
{
    public class DepartmentDpInMemoryRepository : IDepartmentDpRepository
    {
        private List<DepartmentDeliveryParcel> departments;
        public DepartmentDpInMemoryRepository()
        {
            departments = new List<Department>()
            {
                new Department{ DepartmentDeliveryParcelId = 1,
                    Address = "Отделение №333 г. Брест, ул. Комсомольская, 8-1 (м-н \"Евроопт\")",
                    AddressForMap = "Отделение №333 г. Брест, ул. Комсомольская, 8-1 (м-н \"Евроопт\")", 
                    Description = "Режим работы 10:00 - 21:00",
                    RegionId = 1,
                    GipermallId = 10130010
                },
                new Department{ DepartmentDeliveryParcelId = 2,
                    Address = "Отделение №65 г. Брест, Варшавское шоссе, 11 (м-н «Евроопт»)",
                    AddressForMap = "Отделение №65 г. Брест, Варшавское шоссе, 11 (м-н «Евроопт»)", 
                    Description = "Режим работы 10:00 - 21:00",
                    RegionId = 2,
                    GipermallId = 10130030
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

#pragma warning disable CS8766
        // ToDo: warning CS8766
        public Department? GetDepartmentById(int departmentId)
        {
            return departments?.FirstOrDefault(x => x.DepartmentDeliveryParcelId == departmentId);
        }

        public IEnumerable<Department>? GetDepartmentDpsByRegion(int regionId)
        {
            return departments?.Where(x => x.RegionId == regionId).ToList();
        }
#pragma warning restore CS8766

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
