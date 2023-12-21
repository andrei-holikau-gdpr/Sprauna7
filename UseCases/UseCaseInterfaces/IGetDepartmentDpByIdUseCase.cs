using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetDepartmentDpByIdUseCase
    {
        DepartmentDeliveryParcel Execute(int departmentId);
    }
}