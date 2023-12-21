using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly SpraunaContext db;

        public InvoiceRepository(SpraunaContext db)
        {
            this.db = db;
        }
        public void AddInvoice(Invoice invoice)
        {
            db.Invoices.Add(invoice);
            db.SaveChanges();
        }

        public void DeleteInvoice(int invoiceId)
        {
            var item = db.Invoices.Find(invoiceId);

            if (item == null) { return; }

            db.Invoices.Remove(item);
            db.SaveChanges();
        }

#pragma warning disable CS8766
        // ToDo: CS8766
        public Invoice? GetInvoiceById(int invoiceId)
        {
            return db.Invoices.Find(invoiceId);
        }
#pragma warning restore CS8766

        public IEnumerable<Invoice> GetInvoices()
        {
            return db.Invoices.ToList();
        }

        public void UpdateInvoice(Invoice invoice)
        {
                throw new Exception("Метод не реализован. ");

                db.SaveChanges();
        }
    }
}