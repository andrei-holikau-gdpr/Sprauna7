using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CoreBusiness.ComponentEnums;

namespace CoreBusiness
{
    // Покупка
    public class Purchase
    {
        public int PurchaseId { get; set; }

        #region Additional fields for Sbs

        public int? SbsTrackId { get; set; }

        public int? DeliveryType { get; set; } = 2; // 2 - Обязательное значение для SBS
        public int? Wait { get; set; } = 0; // ToDo: удалить заглушку

        #endregion

        [Required(ErrorMessage = "Error 29082049 ")]
        public string CurrentUserId { get; set; }

        [Required (ErrorMessage = "Необходимо ввести Фамилия на посылке")]
        [StringLength(70, MinimumLength = 1)]
        public string Surname { get; set; } // Фамилия на посылке

        [Required(ErrorMessage = "Необходимо ввести Имя на посылке")]
        [StringLength(70, MinimumLength = 1)]
        public string Name { get; set; } // Имя на посылке

        [Required(ErrorMessage = "Необходимо Магазин")]
        public string Shop { get; set; } // Магазин 


        [Required, EnumDataType(typeof(CombineParcels))]
        public CombineParcels CombineParcels { get; set; } = CombineParcels.SendWithoutUnit;
        // Я хочу отправить посылку сразу без объединения с другими посылками

        [Required]  // 1 - Обязательное значение для SBS
        public bool AgreeWithTools { get; set; } = false; 
        // Я ознакомился и согласен с условиями раздела “Инструкция”

        public string TrackNumber { get; set; }

        public bool Lock { get; set; }

        public string Description { get; set; } = "";

        public DateTime? CreatedAt;
        public DateTime? UpdatedAt;

        #region Relations Id

        [Required]
        public int DepartmentDeliveryParcelId { get; set; } // Пункта выдачи посылки

        [Required]
        public int ReceiverId { get; set; } // Получатель
        
        [Required]
        public int PackageId { get; set; } // Посылка

        #endregion

        #region  Relations Objects

        public DepartmentDeliveryParcel DepartmentDeliveryParcel { get; set; }
        public Receiver Receiver { get; set; }
        public List<ProductSp> ProductSps { get; set; }

        #endregion
    }
}