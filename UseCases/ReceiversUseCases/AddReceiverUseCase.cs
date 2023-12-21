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
    public class AddReceiverUseCase : IAddReceiverUseCase
    {
        private readonly IReceiverRepository receiverRepository;

        public AddReceiverUseCase(IReceiverRepository receiverRepository)
        {
            this.receiverRepository = receiverRepository;
        }

        public void Execute(Receiver receiver)
        {
            receiverRepository.AddReceiver(receiver);
        }
    }
}
