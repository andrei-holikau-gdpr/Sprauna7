using System.ComponentModel.DataAnnotations;

namespace Plugins.PMBoK
{
    public class TaskPMBoK
    {
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        [Required]
        public DateTime CreatedDT { get; set; } = DateTime.Now;

        // Status Enum

        #region Relations Id
        public int ProjectId { get; set; }
        public int CategoryOfTaskId { get; set; }
        public int PMBoKCategoryId { get; set; }
        public int WebPageId { get; set; }

        #endregion

        #region  Relations Objects

        public Project? Project { get; set; }
        public CategoryOfTask? CategoryOfTask { get; set; }
        public PMBoKCategory? PMBoKCategory { get; set; }
        public WebPage? WebPage { get; set; }

        #endregion

    }
}