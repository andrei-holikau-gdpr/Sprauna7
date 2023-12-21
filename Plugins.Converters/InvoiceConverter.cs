using CoreBusiness.ExpressPay;
using CoreBusiness.ShopByShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;

namespace Plugins.Converters
{
    public static class InvoiceConverter
    {
        public static InvoiceDataForCreate ToInvoiceDataForCreate(
            Receiver receiver, 
            string amount,
            string info
            )
        {
            return new InvoiceDataForCreate()
            {
                Amount = amount,
                Info = info,
                Surname = receiver.SecondName,
                FirstName = receiver.FirstName,
                Patronymic = receiver.Surname,
                City = receiver.City,
                Street = receiver.Street,
                House = receiver.House.ToString(),
                Building = receiver.HouseBuildingNumber.ToString(),
                Apartment = receiver.Flat.ToString(),
                EmailNotification = receiver.Email
            };
        }
    }
}
