using CoreBusiness;
using Plugins.DataStore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.SQL
{
    public class RegionRepository : IRegionRepository
    {
        private readonly SpraunaContext db;
        public RegionRepository(SpraunaContext db)
        {
            this.db = db;
        }

        public void AddRegion(Region region)
        {
            db.Regions.Add(region);
            db.SaveChanges();
        }

        public void UpdateRegion(Region region)
        {
            var itemToUpdate = db.Regions.Find(region.RegionId);

            if (itemToUpdate != null)
            {
                itemToUpdate.Name = region.Name;
                itemToUpdate.Description = region.Description;

                db.SaveChanges();
            }
        }

        public IEnumerable<Region> GetRegions()
        {
            return db.Regions.ToList();
        }

#pragma warning disable CS8766
        // ToDo: warning CS8766
        public Region? GetRegionById(int regionId)
        {
            return db.Regions.Find(regionId);
        }
#pragma warning restore CS8766

        public void DeleteRegion(int regionId)
        {
            var item = db.Regions.Find(regionId);
            if (item == null) { return; }

            db.Regions.Remove(item);            
            db.SaveChanges();
        }
    }
}
