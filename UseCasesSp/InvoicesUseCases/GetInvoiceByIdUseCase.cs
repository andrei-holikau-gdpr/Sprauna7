using CoreBusiness;
using Plugins.DataStore.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCasesSp.UseCaseInterfaces;

namespace UseCasesSp
{
    public class GetInvoiceByIdUseCase : IGetInvoiceByIdUseCase
    {
        private readonly IInvoiceRepository invoiceRepository;


        public GetInvoiceByIdUseCase(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public Invoice Execute(int invoiceId)
        {
            return invoiceRepository.GetInvoiceById(invoiceId);
        }
    }
}
