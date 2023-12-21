using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public static class ReceiverOptions
    {
        #region const

        public const string NameSingle = "Receiver";
        public const string NameMany = "Receivers";

        // Паспортные данные и ИНН

        public const string Nationality = "Гражданство";
        public const string PassportSeries = "Серия паспорта";
        public const string PassportID = "Номер паспорта";
        public const string PassportIssueDate = "Дата выдачи";
        public const string PassportIssuedBy = "Кем выдан";
        public const string SecondName = "Фамилия";
        public const string FirstName = "Имя";
        public const string Surname = "Отчество";

        // Адрес регистрации

        public const string Country = "Страна";
        public const string Region = "Область";
        public const string City = "Город";
        public const string Street = "Улица";
        public const string House = "Дом";
        public const string HouseBuildingNumber = "Корпус";
        public const string Flat = "Квартира";
        public const string Index = "Индекс";
        public const string Phone = "Контактный номер";
        public const string PassportScan = "Скан паспорта";
        public const string Description = "Примечание";

        #endregion

        #region List

        public static List<string> countries = new() { "Беларусь" };
        public static List<string> regions = new() { "Минская область", "Могилевская облавть" };

        #endregion

        public static Receiver CopyReceiver(Receiver oldObject)
        {
            if (oldObject == null)
            {
                throw new ArgumentNullException(" Receiver oldObject == null");
            }
            else
            {
                Receiver newObject = new Receiver();

                newObject.CurrentUserId = oldObject.CurrentUserId;
                newObject.Nationality = oldObject.Nationality;
                newObject.PassportSeries = oldObject.PassportSeries;
                newObject.PassportID = oldObject.PassportID;
                newObject.PassportIssueDate = oldObject.PassportIssueDate;
                newObject.PassportIssuedBy = oldObject.PassportIssuedBy;
                newObject.SecondName = oldObject.SecondName;
                newObject.FirstName = oldObject.FirstName;
                newObject.Surname = oldObject.Surname;

                newObject.Country = oldObject.Country;
                newObject.Region = oldObject.Region;
                newObject.City = oldObject.City;
                newObject.Street = oldObject.Street;
                newObject.House = oldObject.House;
                newObject.HouseBuildingNumber = oldObject.HouseBuildingNumber;
                newObject.Flat = oldObject.Flat;
                newObject.Index = oldObject.Index;
                newObject.Phone = oldObject.Phone;
                newObject.PassportScan = oldObject.PassportScan;

                newObject.Description = oldObject.Description;

                newObject.Birthdate = oldObject.Birthdate;
                newObject.Email = oldObject.Email;
                newObject.Iin = oldObject.Iin;

                newObject.SbsId = oldObject.SbsId;


                return newObject;
            }
        }

        public static String GetFIO(Receiver receiver)
        {
            return $" {receiver.SecondName} {receiver.FirstName[0]}. {receiver.Surname[0]}.";
        }
    }
}