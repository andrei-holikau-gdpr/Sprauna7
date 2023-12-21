using CoreBusiness;

namespace UseCasesSp.UseCaseInterfaces
{
    public interface IGetDirectorySpByUserIdUseCase
    {
        DirectorySp? Execute(string id);
    }
}