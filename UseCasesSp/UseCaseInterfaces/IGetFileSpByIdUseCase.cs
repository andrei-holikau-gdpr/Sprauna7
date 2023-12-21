using CoreBusiness;

namespace UseCasesSp.UseCaseInterfaces
{
    public interface IGetFileSpByIdUseCase
    {
        FileSp? Execute(int id);
    }
}