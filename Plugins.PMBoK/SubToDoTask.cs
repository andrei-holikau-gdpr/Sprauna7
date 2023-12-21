using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.PMBoK
{
    public class SubToDoTask
    {
        public int SubToDoTaskId { get; set; }
        public string? Task { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
