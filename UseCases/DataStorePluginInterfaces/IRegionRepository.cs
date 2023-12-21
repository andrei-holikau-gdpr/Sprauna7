using CoreBusiness;
using System.Collections.Generic;

namespace Plugins.DataStore.InMemory
{
    public interface IRegionRepository
    {
        void AddRegion(Region region);
        void DeleteRegion(int regionId);
        IEnumerable<Region> GetRegions();
        Region GetRegionById(int regionId);
        void UpdateRegion(Region region);
    }
}