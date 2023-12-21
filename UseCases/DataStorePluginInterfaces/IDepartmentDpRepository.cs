using CoreBusiness;
using System.Collections.Generic;
using DepartmentDp = CoreBusiness.DepartmentDeliveryParcel;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IDepartmentDpRepository
    {
        void AddDepartment(DepartmentDp department);
        void DeleteDepartment(int departmentId);
        DepartmentDp GetDepartmentById(int departmentId);

        IEnumerable<DepartmentDp> GetDepartmentDpsByRegion(int regionId);
        IEnumerable<DepartmentDp> GetDepartments();
        void UpdateDepartment(DepartmentDp departmentDp);
    }
}