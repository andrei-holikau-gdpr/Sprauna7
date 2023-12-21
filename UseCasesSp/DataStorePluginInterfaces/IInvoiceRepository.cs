using CoreBusiness;

namespace Plugins.DataStore.SQL
{
    public interface IInvoiceRepository
    {
        void AddInvoice(Invoice invoice);
        void DeleteInvoice(int invoiceId);
        Invoice? GetInvoiceById(int invoiceId);
        IEnumerable<Invoice> GetInvoices();
        void UpdateInvoice(Invoice invoice);
    }
}