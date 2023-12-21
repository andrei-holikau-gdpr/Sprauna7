using Gap.CoreBusiness;

namespace Gap.UseCases.UseCaseInterfaces
{
    public interface IViewCountriesUseCase
    {
        IEnumerable<Country> Execute();
    }
}