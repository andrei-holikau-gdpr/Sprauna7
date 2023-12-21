using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetReceiverByIdUseCase
    {
        Receiver Execute(int receiverId);
    }
}