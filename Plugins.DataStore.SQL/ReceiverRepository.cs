using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ReceiverRepository : IReceiverRepository
    {
        private readonly SpraunaContext db;

        public ReceiverRepository(SpraunaContext db)
        {
            this.db = db;
        }
        public void AddReceiver(Receiver receiver)
        {
            db.Receivers.Add(receiver);
            db.SaveChanges();
        }

        public void DeleteReceiver(int receiverId)
        {
            var item = db.Receivers.Find(receiverId);

            if (item == null) { return; }

            db.Receivers.Remove(item);
            db.SaveChanges();
        }

#pragma warning disable CS8766
        // ToDo: CS8766
        public Receiver? GetReceiverById(int receiverId)
        {
            return db.Receivers.Find(receiverId);
        }
#pragma warning restore CS8766

        public IEnumerable<Receiver> GetReceivers()
        {
            return db.Receivers.ToList();
        }

        public void UpdateReceiver(Receiver receiver)
        {
            var itemToUpdate = db.Receivers.Find(receiver.ReceiverId);

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

                db.SaveChanges();
            }
        }
    }
}