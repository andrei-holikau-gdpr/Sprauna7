using CoreBusiness.ShopByShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.ShopByShop.Services
{
    public class ShopByShopService
    {
        #region Protected Fields

        protected readonly ShopByShopSettings sbsConfig;

        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        protected readonly HttpClient httpClient = new();

        protected const string ExceptionSp_SbsConfigNoValid = $"ExceptionSp (0728-1700): sbsConfig no valid.";

        #endregion
        //---
        #region Protected Methods

        protected void ValidationConfig()
        {
            if (!sbsConfig.IsValidConfig())
                throw new Exception(ExceptionSp_SbsConfigNoValid);
        }

        protected void GetAuthorization()
        {
            ValidationConfig();

            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Bearer", sbsConfig.Token);

            if(sbsConfig.Accept != null)
            {
                httpClient.DefaultRequestHeaders.Add("Accept", sbsConfig.Accept);
            }
        }

        #endregion
        //---
        #region Public Methods

        public ShopByShopService(ShopByShopSettings shopByShopConfig, HttpClient? client = null)
        {
            sbsConfig = shopByShopConfig;
            httpClient = client ?? new HttpClient();

            ValidationConfig();
            GetAuthorization();
        }

        #endregion
    }
}
