using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ReceiversUseCases
{
    public class ViewReceiversUseCase : IViewReceiversUseCase
    {
        private readonly IReceiverRepository receiverRepository;

        public ViewReceiversUseCase(IReceiverRepository receiverRepository)
        {
            this.receiverRepository = receiverRepository;
        }
        public IEnumerable<Receiver> Execute()
        {
            return receiverRepository.GetReceivers();
        }
    }
}
