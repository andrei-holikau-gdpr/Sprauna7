using CoreBusiness.ExpressPay;

namespace Plugins.ExpressPay
{
    public class ExpressPayServices
    {
        //Расскоментировать любой метод для проверки работы API

        //Добавляет счет
        public InvoiceJson? AddInvoice(InvoiceDataForCreate newInvoice)
        {
            return InvoiceExample.AddInvoice(newInvoice);
        }

        /// <summary>
        /// Получает детальную информацию по номеру счета
        /// </summary>
        /// <param name="numberInvoice"></param>
        public string GetDetailsInvoice(string numberInvoice)
        {
            return InvoiceExample.GetDetailsInvoice(numberInvoice);
        }

        /// <summary>
        /// Получает статус счета
        /// </summary>
        /// <param name="numberInvoice"></param>
        public string GetStatusInvoice(string numberInvoice)
        {
            return InvoiceExample.GetStatusInvoice(numberInvoice);
        }

        // Отменяет счет, где статус ожидание оплаты
        public string CancelInvoice(string numberInvoice)
        {
            return InvoiceExample.CancelInvoice(numberInvoice);
        }

        // Получает список счетов в указанном фильтре
        public string GetListInvoices()
        {
            return InvoiceExample.GetListInvoices();
        }

        //Получает список платежей в указанном фильтре
        public string GetListPayments()
        {
            return PaymentExample.GetListPayments();
        }

        //Получает детальную информацию по номеру платежа
        public string GetDetailsPayment()
        {
            return PaymentExample.GetDetailsPayment();
        }
    }
}