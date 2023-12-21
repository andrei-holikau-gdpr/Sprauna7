using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Region
    {
        public int RegionId { get; set; }

        [Required(ErrorMessage = "Необходимо ввести \"Название области или города\"")]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public List<DepartmentDeliveryParcel> DepartmentDeliveryParcels { get; set; }
    }
}
