using Gap.CoreBusiness;
using Gap.UseCases.DataStorePluginInterfaces;
using Gap.UseCases.UseCaseInterfaces;

namespace Gap.UseCases.CountriesUseCases;

public class ViewCountriesUseCase : IViewCountriesUseCase
{
    private readonly ICountryRepository countryRepository;

    public ViewCountriesUseCase(ICountryRepository countryRepository)
    {
        this.countryRepository = countryRepository;
    }
    public IEnumerable<Country> Execute()
    {
        return countryRepository.GetCountries();
    }
}