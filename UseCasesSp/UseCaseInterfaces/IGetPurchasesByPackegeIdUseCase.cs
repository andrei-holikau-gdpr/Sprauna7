using CoreBusiness;

namespace UseCasesSp.UseCaseInterfaces
{
    public interface IGetPurchasesByPackegeIdUseCase
    {
        IEnumerable<Purchase> Execute();
        IEnumerable<Purchase> Execute(int PackegeId);
    }
}