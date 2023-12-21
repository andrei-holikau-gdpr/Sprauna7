using CoreBusiness;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ReceiverInMemoryRepository : IReceiverRepository
    {
        private List<Receiver> receivers;
        public ReceiverInMemoryRepository()
        {
            receivers = new List<Receiver>()
            {
                new Receiver{
                    ReceiverId = 1,
                    Nationality         = "Беларус",
                    PassportSeries = "МР",
                    PassportID = "Номер паспорта 1",
                    PassportIssueDate = DateTime.Now,
                    PassportIssuedBy = "Кем выдан 1",
                    SecondName = "Иванов",
                    FirstName = "Иван",
                    Surname = "Иванович",
                    Country = "Беларусь",
                    Region = "Минская область",
                    City = "Минск",
                    Street = "ул.Ленинская",
                    House = 1,
                    HouseBuildingNumber = "а",
                    Flat = 1,
                    Index = "123123",
                    Phone = "+375441112233",
                    PassportScan = "Скан паспорта 1",
                    IsDefault = true
                },
                new Receiver{
                    ReceiverId = 2,
                    Nationality         = "Беларус",
                    PassportSeries = "МР",
                    PassportID = "Номер паспорта 2",
                    PassportIssueDate = DateTime.Now,
                    PassportIssuedBy = "Кем выдан 2",
                    SecondName = "Петров",
                    FirstName = "Петр",
                    Surname = "Петрович",
                    Country = "Беларусь",
                    Region = "Могилевская область",
                    City = "Могилев",
                    Street = "ул.Центральная",
                    House = 2,
                    HouseBuildingNumber = "с",
                    Flat = 2,
                    Index = "212000",
                    Phone = "+375291122234",
                    PassportScan = "Скан паспорта 2"
                }
            };
        }

        public void AddReceiver(Receiver receiver)
        {
            //if (receivers.Any(x => x.Name.Equals(receiver.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (receivers != null && receivers.Count > 0)
            {
                var maxId = receivers.Max(x => x.ReceiverId);
                receiver.ReceiverId = maxId + 1;
            }
            else
            {
                receiver.ReceiverId = 1;
            }

            receivers?.Add(receiver);
        }

        public void UpdateReceiver(Receiver receiver)
        {
            var itemToUpdate = GetReceiverById(receiver.ReceiverId);
            if (itemToUpdate != null)
            {
                itemToUpdate.ReceiverId = receiver.ReceiverId;
                itemToUpdate.Nationality = receiver.Nationality;
                itemToUpdate.PassportSeries = receiver.PassportSeries;
                itemToUpdate.PassportID = receiver.PassportID;
                itemToUpdate.PassportIssueDate = receiver.PassportIssueDate;
                itemToUpdate.PassportIssuedBy = receiver.PassportIssuedBy;
                itemToUpdate.SecondName = receiver.SecondName;
                itemToUpdate.FirstName = receiver.FirstName;
                itemToUpdate.Surname = receiver.Surname;

                itemToUpdate.Country = receiver.Country;
                itemToUpdate.Region = receiver.Region;
                itemToUpdate.City = receiver.City;
                itemToUpdate.Street = receiver.Street;
                itemToUpdate.House = receiver.House;
                itemToUpdate.HouseBuildingNumber = receiver.HouseBuildingNumber;
                itemToUpdate.Flat = receiver.Flat;
                itemToUpdate.Index = receiver.Index;
                itemToUpdate.Phone = receiver.Phone;
                itemToUpdate.PassportScan = receiver.PassportScan;

                itemToUpdate.Description = receiver.Description;
            }
        }

        public IEnumerable<Receiver> GetReceivers()
        {
            return receivers;
        }

#pragma warning disable CS8766
        // ToDo: warning CS8766
        public Receiver? GetReceiverById(int receiverId)
        {
            return receivers?.FirstOrDefault(x => x.ReceiverId == receiverId);
        }
#pragma warning restore CS8766

        public void DeleteReceiver(int receiverId)
        {
            var item = GetReceiverById(receiverId);
            if(item != null) {
                receivers?.Remove(item);
            }            
        }
    }
}
