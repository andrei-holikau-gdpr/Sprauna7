using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public static class PackageOptions
    {
        #region const

        public const string NameSingle = "Package";
        public const string NameMany = "Packages";

        public const string MainName = "Покупка";
        public const string AddPackage = "Добавить посылку";
        public const string InformationAboutPackage = "Информация о посылке";

        #endregion

        public static Package CopyPackage(Package oldObject)
        {
            Package newObject = new Package();

            newObject.NumberPackage = oldObject.NumberPackage;



            newObject.Description = oldObject.Description;

            return newObject;
        }

        public static string GetDescription(StatusesPackage statusesPackage)
        {
            return statusesPackage switch
            {
                
                StatusesPackage.Expected                => "ожидаемая",         // 1                                      
                StatusesPackage.ReceivedAtTheWarehouse  => "получено на склад", // 2                                                              
                StatusesPackage.Problem                 => "проблема",          // 3                
                StatusesPackage.OnThePackage            => "на упаковке",       // 4                
                StatusesPackage.Preparation             => "подготовка",        // 5                
                StatusesPackage.CostCalculation         => "просчет стоимости", // 6                
                StatusesPackage.Paid                    => "оплачено",          // 7                
                StatusesPackage.Trace                   => "отследить",         // 8                
                StatusesPackage.Delivered               => "доставлено",        // 9                
                StatusesPackage.Closed                  => "закрыто",           // 10                
                StatusesPackage.Registry                => "реестр",            // 11                
                StatusesPackage.UnderRreview            => "на проверке",       // 12                
                StatusesPackage.Customs                 => "таможня",           // 15
                
                StatusesPackage.Draft                   => "Черновик",          // 16
                _ => "",
            };
        }
    }
}
