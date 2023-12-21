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
    public class EditReceiverUseCase : IEditReceiverUseCase
    {
        #region const 

        #endregion
        #region private fields

        private readonly IReceiverRepository receiverRepository;

        #endregion

        #region override methods

        public EditReceiverUseCase(IReceiverRepository receiverRepository)
        {
            this.receiverRepository = receiverRepository;
        }

        #endregion
        #region private methods

        public void Execute(Receiver receiver)
        {
            receiverRepository.UpdateReceiver(receiver);
        }

        #endregion
    }
}
