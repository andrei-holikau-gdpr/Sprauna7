using CoreBusiness;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ReceiverItem = CoreBusiness.ShopByShop.Models.RecipientItem;

namespace Plugins.Converters
{
    public static class ReceiverConverter
    {
        public static ReceiverItem ConvertToReceiverItem(this Receiver receiver)
        {
            ReceiverItem newReceiver = new();

            newReceiver.Id = receiver.SbsId;

            newReceiver.Email = receiver.Email;
            newReceiver.Phone = receiver.Phone;

            newReceiver.FirstName = receiver.FirstName;
            newReceiver.MiddleName = receiver.Surname;
            newReceiver.LastName = receiver.SecondName;

            newReceiver.Birthdate = receiver.Birthdate;

            newReceiver.PassportSerial = receiver.PassportSeries;
            newReceiver.PassportNumber = receiver.PassportID;

            newReceiver.PassportDate = receiver.PassportIssueDate;
            newReceiver.Type = receiver.Type;
            newReceiver.PassportFounder = receiver.PassportIssuedBy;
            newReceiver.Iin = receiver.Iin;

            newReceiver.PassportAddress
                = receiver.Country
                + receiver.Region
                + receiver.City
                + receiver.HouseBuildingNumber
                + receiver.Flat;

            newReceiver.Hide = (int)receiver.Hide;

            newReceiver.CreatedAt = receiver.CreatedAt;
            newReceiver.UpdatedAt = receiver.UpdatedAt;

            newReceiver.Region = receiver.Region;
            newReceiver.Street = receiver.Street;
            newReceiver.City = receiver.City;
            newReceiver.Building = receiver.House.ToString();
            newReceiver.Corpus = receiver.HouseBuildingNumber;
            newReceiver.Apartment = receiver.Flat.ToString();
            newReceiver.Index = receiver.Index;

            newReceiver.Fullname
                    = receiver.FirstName
                    + receiver.SecondName
                    + receiver.Surname;
            newReceiver.Passport
                    = receiver.PassportSeries
                    + receiver.PassportID;

            newReceiver.PassportHumanDate = receiver.PassportHumanDate;
            newReceiver.PassportDateForm = receiver.PassportDateForm;

            newReceiver.BirthdateForm = receiver.BirthdateForm;

            /* ReceiverItem newReceiver = new()
            {
                Id = 1,
                Email = "nov@gmail.com",
                Phone = "+375293453255",
                FirstName = "Сергей",
                MiddleName = "Иванович",
                LastName = "Иванов",
                Birthdate = DateTime.Now,
                PassportSerial = "КВ",
                PassportNumber = "789",
                PassportDate = DateTime.Now,
                Type = 1,
                PassportFounder = "РОВД",
                Iin = "456",
                PassportAddress = "PassportAddress",
                Hide = 0,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Region = "Минск обл",
                Street = "Ленинская",
                City = "Минск",
                Building = "12",
                Corpus = "3",
                Apartment = "4",
                Index = "234234",
                Fullname = "Fullname",
                Passport = "Passport",
                PassportHumanDate = "PassportHumanDate",
                PassportDateForm = "PassportDateForm",
                BirthdateForm = "BirthdateForm"
            };
            
            //DateTime PassportDate;
            //DateTime.TryParse(receiver.PassportDateForm, out PassportDate); 

             */

            return newReceiver;
        }
    }
}
