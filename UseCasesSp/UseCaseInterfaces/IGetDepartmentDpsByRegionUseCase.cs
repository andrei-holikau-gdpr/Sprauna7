using CoreBusiness;
using System.Collections.Generic;
using DepartmentDp = CoreBusiness.DepartmentDeliveryParcel;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetDepartmentDpsByRegionUseCase
    {
        IEnumerable<DepartmentDp> Execute(int regionId);
    }
}