using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lixiang.CoreBusiness
{
    public class Car
    {
        private int Id;
        private string? Name;

        private double FullPrice { get; set; } = 0;
        public CarModel carModel { get; set; } = new();
        public CarColorOption carFasad { get; set; } = new();
        public CarColorOption carInterior { get; set; } = new();
        public CarColorOption carWheelDisk { get; set; } = new();

        public List<SimpleOption> SimpleOptions { get; set; } = new();

        public double GetFullPrice()
        {
            FullPrice = 0;
            FullPrice += carFasad.Price 
                + carInterior.Price 
                + carWheelDisk.Price
                + carModel.Price;
            foreach (SimpleOption option in SimpleOptions)
            {
                FullPrice += option.Price;
            }

            return FullPrice;
        }
    }
}
