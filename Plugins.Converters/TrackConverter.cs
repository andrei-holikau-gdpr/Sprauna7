using CoreBusiness;
using CoreBusiness.ShopByShop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.Converters
{
    public static class TrackConverter
    {
        public static TrackItem ConvertToTrackItem(
            this Purchase purchase, 
            int recipientId, 
            string pvz)
        {
            var ProductsForSbs = new List<Product>();
            if (purchase.ProductSps != null)
            {
                foreach (var prod in purchase.ProductSps)
                {
                    ProductsForSbs.Add(ProductConverter.ConvertToProduct(prod));
                }
            }

            var trackItem = new TrackItem()
            {
                Products = ProductsForSbs,

                // * 0
                Id = purchase.SbsTrackId,
                
                // * 2
                RecipientId = (int?)recipientId,
                // * 3
                UserName = purchase.Name,
                // * 4
                Surname = purchase.Surname,
                // * 5
                Pvz = pvz, // ToDo: Remove crutch "70130010"
                           //Pvz = purchase.DepartmentDeliveryParcelId.ToString(),
                // * 6
                Store = purchase.Shop,
                // * 7
                Wait = purchase.Wait, // ToDo: удалить заглушку
                // * 8
                Agree = purchase.AgreeWithTools ? 1 : 0,
                // * 9
                DeliveryType = purchase.DeliveryType,

                CreatedAt = purchase.CreatedAt,
                UpdatedAt = purchase.UpdatedAt,
                Comment = purchase.Description                

                // ConsolidationId;
                // LeadId;
                // Status;
                // Hide;

                // Address;
                // City;
                // Price;

                // Weight;
                // Type;

                // ShopNumber;
                // Apartment;
                // CdekNumber;
                // PaymentToken;
                // CommentAmo;
                // TrackStatus;
                // AdditionalServices;
                // AdditionalServicesPrice;

                // Insurence;
                // Photo;
                // CheckSize;
                // Packing;
                // Invoice;
                // StatusLabel;
                // PriceReal;
                // AdditionalServicesText;
                // PvzAddress;
                // File;
            };

            // * 1
            trackItem.Code = purchase.TrackNumber;
            
            // trackItem.Code = GetRandomCode(); // ToDo: удалить заглушку


            return trackItem;
        }


    }
}
