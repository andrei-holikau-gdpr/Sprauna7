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
    public class GetReceiverByIdUseCase : IGetReceiverByIdUseCase
    {
        private readonly IReceiverRepository receiverRepository;

        public GetReceiverByIdUseCase(IReceiverRepository receiverRepository)
        {
            this.receiverRepository = receiverRepository;
        }

        public Receiver Execute(int receiverId)
        {
            return receiverRepository.GetReceiverById(receiverId);
        }
    }
}
