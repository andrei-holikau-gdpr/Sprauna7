using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class DepartmentDpRepository : IDepartmentDpRepository
    {
        private readonly SpraunaContext db;

        public DepartmentDpRepository(SpraunaContext db)
        {
            this.db = db;
        }
        public void AddDepartment(DepartmentDeliveryParcel department)
        {
            db.DepartmentDeliveryParcels.Add(department);
            db.SaveChanges();
        }

        public void DeleteDepartment(int departmentId)
        {
            var item = db.DepartmentDeliveryParcels.Find(departmentId);

            if (item == null) { return; }

            db.DepartmentDeliveryParcels.Remove(item);
            db.SaveChanges();
        }

#pragma warning disable CS8766
        // ToDo: CS8766
        public DepartmentDeliveryParcel? GetDepartmentById(int departmentId)
        {
            return db.DepartmentDeliveryParcels?.Find(departmentId);
        }
#pragma warning restore CS8766

        public IEnumerable<DepartmentDeliveryParcel> GetDepartments()
        {
            return db.DepartmentDeliveryParcels.ToList();
        }

        public IEnumerable<DepartmentDeliveryParcel> GetDepartmentDpsByRegion(int regionId)
        {
            return db.DepartmentDeliveryParcels.Where(x => x.RegionId == regionId).ToList();
        }

        public void UpdateDepartment(DepartmentDeliveryParcel department)
        {
            var itemToUpdate = db.DepartmentDeliveryParcels.Find(department.DepartmentDeliveryParcelId);

            if (itemToUpdate != null)
            {
                itemToUpdate.Address = department.Address;
                itemToUpdate.Description = department.Description;

                db.SaveChanges();
            }
        }
    }
}
