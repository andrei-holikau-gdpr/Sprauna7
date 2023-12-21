using System;

namespace ExPay.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            //Расскоментировать любой метод для проверки работы API

            //Добавляет счет
            InvoiceExample.AddInvoice();

            //Получает детальную информацию по номеру счета
            InvoiceExample.GetDetailsInvoice();

            //Получает статус счета
            //InvoiceExample.GetStatusInvoice();

            //Отменяет счет, где статус ожидание оплаты
            //InvoiceExample.CancelInvoice();

            //Получает список счетов в указанном фильтре
            //InvoiceExample.GetListInvoices();

            //Получает список платежей в указанном фильтре
            //PaymentExample.GetListPayments();

            //Получает детальную информацию по номеру платежа
            //PaymentExample.GetDetailsPayment();

            Console.ReadKey();
        }
    }
}
