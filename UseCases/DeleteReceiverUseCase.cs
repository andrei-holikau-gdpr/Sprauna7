using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class DeleteReceiverUseCase : IDeleteReceiverUseCase
    {
        private readonly IReceiverRepository receiverRepository;

        public DeleteReceiverUseCase(IReceiverRepository receiverRepository)
        {
            this.receiverRepository = receiverRepository;
        }
        public void Delete(int receiverId)
        {
            receiverRepository.DeleteReceiver(receiverId);
        }
    }
}
