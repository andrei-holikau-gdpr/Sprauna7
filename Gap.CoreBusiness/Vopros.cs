using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.CoreBusiness;

public class Vopros
{
    public int Id { get; set; }
    public string TextVoprosa { get; set; } = "";
    public TypeVoprosEnum TypeVopros { get; set; }
    public List<Otvet> Otvets { get; set; }

    public int PositionInList { get; set; }
    public int Ves { get; set; }
}
