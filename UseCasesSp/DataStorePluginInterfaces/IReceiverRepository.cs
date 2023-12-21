using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IReceiverRepository
    {
        IEnumerable<Receiver> GetReceivers();
        void AddReceiver(Receiver receiver);
        void UpdateReceiver(Receiver receiver);
        Receiver GetReceiverById(int receiverId);
        void DeleteReceiver(int receiverId);
    }
}
