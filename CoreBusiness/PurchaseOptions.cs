using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public static class PurchaseOptions
    {
        #region const

        public const string NameSingle = "Purchase";
        public const string NameMany = "Purchases";

        public const string MainName = "Посылка";

        public const string Surname = "Фамилия на посылке";
        public const string Name = "Имя на посылке";
        public const string Shop = "Магазин";
        public const string DepartmentDeliveryParce = "Пункт выдачи посылки";
        public const string Receiver = "Получатель";
        public const string SendWithoutUnit = "Я хочу отправить посылку сразу без объединения с другими посылками";
        public const string AgreeWithTools = "Я ознакомился и согласен с условиями раздела “Инструкция”";

        public const string Description = "Описание";
        public const string TrackNumber = "Траск №";

        #endregion

        #region Lists

        public static List<string> sendWithoutUnitOptions = new() { "Объединить", "Не объединить" };

        #endregion

        public static Purchase CopyPurchase(Purchase oldObject)
        {
            if (oldObject == null)
            {
                throw new ArgumentNullException("ArgumentNullException Error:2156");
            }
            else
            {
                Purchase newObject = new Purchase();

                newObject.CurrentUserId = oldObject?.CurrentUserId;
                newObject.Surname = oldObject.Surname;
                newObject.Name = oldObject.Name;
                newObject.Shop = oldObject.Shop;

                newObject.CombineParcels = oldObject.CombineParcels;

                newObject.AgreeWithTools = oldObject.AgreeWithTools;

                newObject.Lock = oldObject.Lock;

                newObject.Description = oldObject.Description;
                newObject.TrackNumber = oldObject.TrackNumber;
                newObject.SbsTrackId = oldObject.SbsTrackId;

                //Relations
                newObject.DepartmentDeliveryParcelId = oldObject.DepartmentDeliveryParcelId;
                newObject.ReceiverId = oldObject.ReceiverId;

                return newObject;
            }
        }

        /*
        public static void FillPurchase(ref Purchase oldObject, Purchase newObject)
        {
            newObject.Surname = oldObject.Surname;
            newObject.Name = oldObject.Name;
            newObject.Shop = oldObject.Shop;
            newObject.ParcelPickUpPoint = oldObject.ParcelPickUpPoint;
            newObject.SendWithoutUnit = oldObject.SendWithoutUnit;
            newObject.AgreeWithTools = oldObject.AgreeWithTools;

            newObject.Lock = oldObject.Lock;

            newObject.Description = oldObject.Description;
            newObject.TrackNumber = oldObject.TrackNumber;
        }
        */
    }
}
