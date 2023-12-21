using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class CostOfDelivery
    {
        public int CostOfDeliveryId { get; set; }
        [Required]
        public double WeightKg { get; set; }
        [Required]
        public double CostPln { get; set; }
    }
}
