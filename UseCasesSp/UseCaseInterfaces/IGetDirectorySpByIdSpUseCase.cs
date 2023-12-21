using CoreBusiness;

namespace UseCasesSp.UseCaseInterfaces
{
    public interface IGetDirectorySpByIdUseCase
    {
        DirectorySp? Execute(int id);
    }
}