using Gap.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.UseCases.DataStorePluginInterfaces
{
    public interface ICountryRepository
    {
        public IEnumerable<Country> GetCountries();
    }
}
