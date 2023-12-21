using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetPurchaseByIdUseCase
    {
        Purchase Execute(int purchaseId);
    }
}