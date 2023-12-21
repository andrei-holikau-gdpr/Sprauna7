using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    
    public class ProductSp
    {
        public int ProductSpId { get; set; }

        #region Required

        [Required]
        public string CurrentUserId { get; set; }

        [Required(ErrorMessage = "Необходимо ввести \"Тип товара и марка\"")]
        [StringLength(70, MinimumLength = 15, ErrorMessage = "\"Тип товара и марка\" от 15 до 70 символов")]
        public string ProductTypeAndBrand { get; set; }

        [Required(ErrorMessage = "Необходимо ввести \"Количество\"")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Необходимо ввести \"Ссылка на товар\"")]
        // [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        // [Display(Name = "Release Date")]
        // [DataType(DataType.Date)]
        public string UrlToProduct { get; set; }

        [Required(ErrorMessage = "Необходимо ввести \"Цена в злотых\"")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Необходимо ввести \"Ссылка на картинку\"")]
        public string UrlToImage { get; set; }

        // ToDo: Сделать поле обязательным
        [Required(ErrorMessage = "Необходимо ввести \"Трек номер\"")]
        public string TrackNumber { get; set; }


        public int? SbsId { get; set; }

        #endregion
        // ---
        #region No Required
        

        #endregion
        // ---
        #region Relations Id

        public int PurchaseNewId { get; set; }
        public int? CategoryId { get; set; }

        public string Description { get; set; } = "";



        #endregion
        // ---
        #region  Relations Objects
        public Purchase Purchase { get; set; }
        public Category Category { get; set; }



        #endregion
    }    
}