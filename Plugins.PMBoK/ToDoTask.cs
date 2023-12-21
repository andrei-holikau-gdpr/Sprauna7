using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.PMBoK
{
    public class ToDoTask
    {
        public int ToDoTaskId { get; set; }

        public string? Task { get; set; }
        public string? Page { get; set; }
        public int Priority { get; set; } = 0;        
        public bool IsCompleted { get; set; } = false;
        public bool IsAtWork { get; set; } = false;
        public bool IsBug { get; set; } = false;

        public List<SubToDoTask> SubTasks { get; set; } = new();

        public string Description { get; set; } = "";
        public string? Category { get; set; } = "";
    }
}
