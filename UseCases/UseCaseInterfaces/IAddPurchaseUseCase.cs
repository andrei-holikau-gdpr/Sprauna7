using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IAddPurchaseUseCase
    {
        int Execute(Purchase purchase);
    }
}