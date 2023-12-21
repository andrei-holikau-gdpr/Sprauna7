using CoreBusiness;
using Plugins.DataStore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.InMemorySp
{
    public class RegionInMemoryRepository : IRegionRepository
    {
        private List<Region> regions;
        public RegionInMemoryRepository()
        {
            regions = new List<Region>()
            {
                new Region{ RegionId = 1, Name = "Минск" },
                new Region{ RegionId = 2, Name = "Могилев" },
                new Region{ RegionId = 3, Name = "Витебск" },
                new Region{ RegionId = 4, Name = "Гродно" },
                new Region{ RegionId = 5, Name = "Гомель" },
                new Region{ RegionId = 6, Name = "Брест" },
                new Region{ RegionId = 7, Name = "Минская область" },
                new Region{ RegionId = 8, Name = "Могилевская область" },
                new Region{ RegionId = 9, Name = "Витебская область" },
                new Region{ RegionId = 10, Name = "Гродненская область" },
                new Region{ RegionId = 11, Name = "Гомельская область" },
                new Region{ RegionId = 12, Name = "Брестская область" }
            };
        }

        public void AddRegion(Region region)
        {
            if (regions.Any(x => x.Name.Equals(region.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (regions != null && regions.Count > 0)
            {
                var maxId = regions.Max(x => x.RegionId);
                region.RegionId = maxId + 1;
            }
            else
            {
                region.RegionId = 1;
            }

            regions?.Add(region);
        }

        public void UpdateRegion(Region region)
        {
            var regionToUpdate = GetRegionById(region.RegionId);
            if (regionToUpdate != null)
            {
                regionToUpdate.Name = region.Name;
                regionToUpdate.Description = region.Description;
            }
        }

        public IEnumerable<Region> GetRegions()
        {
            return regions;
        }

        public Region? GetRegionById(int regionId)
        {
            return regions.FirstOrDefault(x => x.RegionId == regionId);
        }

        public void DeleteRegion(int regionId)
        {
            var item = GetRegionById(regionId);
            if (item != null)
            {
                regions?.Remove(item);
            }
        }
    }
}
