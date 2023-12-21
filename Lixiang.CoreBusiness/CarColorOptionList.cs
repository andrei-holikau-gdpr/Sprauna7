using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lixiang.CoreBusiness;

public class CarColorOptionList
{
    public List<CarModel> CarModels { get; set; } = new();
    public List<CarColorOption> CarFasadColorOptions { get; set; } = new();
    public List<CarColorOption> CarInteriorColorOptions { get; set; } = new();
    public List<CarColorOption> CarWheelDisksOptions { get; set; } = new();
    public List<SimpleOption> OptionalEquipments { get; set; } = new();
    public List<ImageHtmlTag> ImageHtmlTags { get; set; } = new();
}
