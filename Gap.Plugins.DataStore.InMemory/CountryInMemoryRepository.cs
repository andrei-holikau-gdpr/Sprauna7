using Gap.CoreBusiness;
using Gap.UseCases.DataStorePluginInterfaces;

namespace Gap.Plugins.DataStore.InMemory
{
    public class CountryInMemoryRepository : ICountryRepository
    {
        private List<Country> countries;

        public CountryInMemoryRepository()
        {
            // Add some default countries

            countries = new List<Country>()
            {
                new() { Id = 1, Name = "Китай" },
                new() { Id = 2, Name = "ОАЭ" },
                new() { Id = 3, Name = "Германия" },
                new() { Id = 4, Name = "Республика Кипр" }
            };
        }

        public IEnumerable<Country> GetCountries()
        {
            return countries;
        }
    }
}