using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    // Посылка
    [Table("PackageSp")]
    public class Package
    {
        public int PackageId { get; set; }

        #region Required

        [Required]
        public string CurrentUserId { get; set; }

        [Required, DisplayName("Статус посылки")]
        public StatusesPackage Status { get; set; }

        #endregion
        // ---
        #region No Required

        [DisplayName("№ посылки")]
        public string NumberPackage { get; set; }

        [DisplayName("Трек номер")]
        public string TrackNumber { get; set; }
        
        [DisplayName("Вес")]
        public double Weight { get; set; }
        
        [DisplayName("Цена PLN")]
        public double PricePLN { get; set; }
                
        [DisplayName("Цена BYN")]
        public double PriceBYN { get; set; }

        [DisplayName("Сборная посылка")]
        public bool IsCollectivePackage { get; set; } = false;

        public string Description { get; set; } = "";



        #endregion
        // ---
        #region Relations Id

        public int InvoiceId { get; set; }

        #endregion
        // ---
        #region  Relations Objects

        public List<Purchase> Purchases { get; set; } = new();

        public Invoice Invoice { get; set; }

        #endregion
    }

    /// <summary> Статусы посылки:
    /// 
    /// '48704632' => 1, // ожидаемая
    /// '48704635' => 2, // получено на склад
    /// '48704707' => 3, // проблема
    /// '48704638' => 4, // на упаковке
    /// '48704641' => 5, // подготовка
    /// '48704644' => 6, // просчет стоимости
    /// '48704647' => 7, // оплачено
    /// '48704650' => 8, // отследить
    /// '142'      => 9, // доставлено
    /// '143'      => 10, // закрыто
    /// '49039966' => 11, // реестр
    /// '49039960' => 12, // на проверке
    /// '55725914' => 15, // таможня
    /// 
    /// </summary>
    public enum StatusesPackage
    {
        /// <summary> '48704632' => 1, // ожидаемая </summary>
        [Description("ожидаемая")]
        Expected = 1,

        /// <summary> '48704635' => 2, // получено на склад </summary>
        [Description("получено на склад")]
        ReceivedAtTheWarehouse = 2,

        /// <summary> '48704707' => 3, // проблема </summary>
        [Description("проблема")]
        Problem = 3,

        /// <summary> '48704638' => 4, // на упаковке </summary>
        [Description("на упаковке")]
        OnThePackage = 4,

        /// <summary> '48704641' => 5, // подготовка </summary>
        [Description("подготовка")]
        Preparation = 5,

        /// <summary> '48704644' => 6, // просчет стоимости </summary>
        [Description("просчет стоимости")]
        CostCalculation = 6,

        /// <summary> '48704647' => 7, // оплачено </summary>
        [Description("оплачено")]
        Paid = 7,

        /// <summary> '48704650' => 8, // отследить </summary>
        [Description("отследить")]
        Trace = 8,

        /// <summary> '142'      => 9, // доставлено </summary>
        [Description("доставлено")]
        Delivered = 9,

        /// <summary> '143'      => 10, // закрыто </summary>
        [Description("закрыто")]
        Closed = 10,

        /// <summary> '49039966' => 11, // реестр </summary>
        [Description("реестр")]
        Registry = 11,

        /// <summary> '49039960' => 12, // на проверке </summary>
        [Description("на проверке")]
        UnderRreview = 12,

        /// <summary> '55725914' => 15, // таможня </summary>
        [Description("таможня")]
        Customs = 15,


        /// <summary> Черновик </summary>
        [Description("Черновик")]
        [EnumMember(Value = "Draft")]
        Draft = 16,

    }




    /// <summary>
    /// Расширение Enum
    /// </summary>
    //public class EnumExtensions
    //{
    //    /// <summary>
    //    /// Получить атрибут "Описание"
    //    /// </summary>
    //    /// <param name="value">Значение перечисления</param>
    //    /// <returns>Значение атрибута "Описание"</returns>
    //    public static string GetDescription(this Enum value)
    //    {
    //        FieldInfo fi = value.GetType().GetField(value.ToString());

    //        DescriptionAttribute[] attributes =
    //            (DescriptionAttribute[])fi.GetCustomAttributes(
    //            typeof(DescriptionAttribute),
    //            false);

    //        if (attributes != null &&
    //            attributes.Length > 0)
    //            return attributes[0].Description;
    //        else
    //            return value.ToString();
    //    }
    //}
}
