using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PMBok.CoreBusiness;

public class Project
{
    #region Required

    [Key]
    [DisplayName("Id")]
    public int ProjectId { get; set; }

    [Required]
    [DisplayName("Название проекта")]
    public string Name { get; set; }

    #endregion
    // ---
    #region Relations Id



    #endregion
    // ---
    #region  Relations Objects



    #endregion
}