﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.CoreBusiness;

public class Otvet
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public string? Image { get; set; }
    public bool Checked { get; set; }
}
