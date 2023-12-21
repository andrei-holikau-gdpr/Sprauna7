using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBusiness
{
    [Table("Invoices")]
    public class Invoice
    {
        [Key]
        [DisplayName("Id")]
        public int InvoiceId { get; set; }
        [Required]
        public string CurrentUserId { get; set; }

        #region Required

        [Required]
        [DisplayName("Номер счета на оплату")]
        public string InvoiceNo { get; set; }           // Номер счета на оплату
        [Required]
        [DisplayName("Номер лицевого счета")]
        public string AccountNo { get; set; }           // Номер лицевого счета

        #endregion
        // ---
        #region No Required

        [Required]
        [DisplayName("Ссылка на оплату")]
        public string Url { get; set; }                 // Ссылка на оплату

        [DisplayName("Описание")]
        public string Description { get; set; }

        #endregion
        // ---
        #region NotMapped

        //[NotMapped]
        [DisplayName("Статус счета на оплату")]
        public StatusesInvoice Status { get; set; }     // Статус счета на оплату

        //[NotMapped]
        [DisplayName("Дата выставления счета")]
        public string Created { get; set; }             // Дата выставления счета. Формат - yyyyMMddHHmmss
        //[NotMapped]
        [DisplayName("Дата истечения срока действия")]
        public string Expiration { get; set; }          // Дата истечения срока действия выставления счета на оплату.
                                                        // Форматы – yyyyMMdd, yyyyMMddHHmm
        //[NotMapped]
        [DisplayName("Сумма счета на оплату")]
        public string Amount { get; set; }              //double Сумма счета на оплату
        [NotMapped]
        [DisplayName("Код валюты")]
        public CurrencyInvoice Currency { get; set; }   // Код валюты
        [NotMapped]
        [DisplayName("Номер счета по карте")]
        public int CardInvoiceNo { get; set; }          // Номер счета по карте (не обязательное. Возвращается только в случае, если выполнялась оплата счета по карте.)

        #endregion
        // ---
        #region Relations Id

        [Required(ErrorMessage = "Необходимо выбрать \"Посылку\"")]
        public int PackageId { get; set; }

        #endregion
        // ---
        #region  Relations Objects

        public Package Package { get; set; }

        #endregion
    }


    ///<summary> Возможные коды валют:
    ///    
    ///    933 – BYN;
    ///    974 – BYR;
    ///
    /// </summary>
    public enum CurrencyInvoice : int
    {
        ///<summary> 933 – BYN; </summary>
        BYN = 933,

        ///<summary> 974 – BYR; </summary>
        BYR = 974
    }

    /// <summary> Статус счета на оплату:
    ///
    ///  1 - Ожидает оплату
    ///  2 - Просрочен
    ///  3 - Оплачен
    ///  4 - Оплачен частично
    ///  5 - Отменен
    ///  6 - Оплачен с помощью банковской карты
    ///  7 - Платеж возращен
    ///
    ///  1 - Awaiting payment
    ///  2 - Expired
    ///  3 - Paid
    ///  4 - Paid in part
    ///  5 - Canceled
    ///  6 - Paid with a bank card
    ///  7 - Payment returned
    /// 
    /// </summary>
    public enum StatusesInvoice
    {
        /// <summary>
        /// 1 - Ожидает оплату
        /// </summary>
        AwaitingPayment = 1, 

        /// <summary>
        /// 2 - Просрочен
        /// </summary>
        Expired = 2,       

        /// <summary>
        /// 3 - Оплачен
        /// </summary>
        Paid = 3, 

        /// <summary>
        /// 4 - Оплачен частично
        /// </summary>
        PaidInPart = 4, 

        /// <summary>
        /// 5 - Отменен
        /// </summary>
        Canceled = 5, 

        /// <summary>
        /// 6 - Оплачен с помощью банковской карты
        /// </summary>
        PaidWithABankCard = 6, 

        /// <summary>
        /// 7 - Платеж возращен
        /// </summary>
        PaymentReturned = 7,

        /// <summary>
        /// 8 - Отправлен
        /// </summary>
        Sent = 8
    }
}
