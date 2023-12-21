using CoreBusiness;

namespace UseCasesSp.UseCaseInterfaces
{
    public interface IGetInvoiceByIdUseCase
    {
        Invoice Execute(int invoiceId);
    }
}