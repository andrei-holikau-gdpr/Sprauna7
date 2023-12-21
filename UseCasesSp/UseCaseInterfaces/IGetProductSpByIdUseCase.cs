using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetProductSpByIdUseCase
    {
        ProductSp Execute(int productSpId);
    }
}