using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewDepartmentDpsUseCase
    {
        IEnumerable<DepartmentDeliveryParcel> Execute();
    }
}