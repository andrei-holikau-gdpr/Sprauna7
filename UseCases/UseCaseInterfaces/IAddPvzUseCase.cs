using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IAddPvzUseCase
    {
        void Execute(DepartmentDeliveryParcel pvz);
    }
}