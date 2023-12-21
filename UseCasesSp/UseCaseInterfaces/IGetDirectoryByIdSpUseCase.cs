using CoreBusiness;

namespace UseCasesSp.UseCaseInterfaces
{
    public interface IGetDirectoryByIdSpUseCase
    {
        DirectorySp? Execute(int id);
    }
}