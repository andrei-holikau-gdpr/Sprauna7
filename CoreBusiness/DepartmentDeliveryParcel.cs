using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class DepartmentDeliveryParcel
    {
        public int DepartmentDeliveryParcelId { get; set; }
        [Required(ErrorMessage = "Необходимо ввести \"Адрес пункта выдачи послки\"")]
        public string Address { get; set; }
        public string AddressForMap { get; set; }
        public string Description { get; set; }

        public int GipermallId { get; set; }

        public int Hide { get; set; }

        // Relations Id
        public int? RegionId { get; set; }

        // Relations Objects
        public Region Region { get; set; }
        public List<Purchase> Purchases { get; set; }
    }
}
