using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetPackageByIdUseCase
    {
        Package Execute(int packageId);
    }
}