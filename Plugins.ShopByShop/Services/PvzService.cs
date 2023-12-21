using CoreBusiness.ShopByShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UseCases.ShopByShop.InterfacesRepositories;

namespace Plugins.ShopByShop.Services
{
    public class PvzService : ShopByShopService, IPvzRepository
    {
        #region Private Fields Pvz

        // Получение всех Pvz
        private readonly string UrlGetPvzs = "/pvz";

        #endregion
        //--
        #region Public Methods

        public PvzService(ShopByShopSettings shopByShopConfig, HttpClient? client = null)
            : base(shopByShopConfig, client)
        {
            UrlGetPvzs = sbsConfig.UrlApi + UrlGetPvzs;
        }

        #pragma warning disable CS8600, CS8603 //todo: #pragma warning disable CS8600 

        /// <summary>
        /// Получение всех треков пользователя
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PvzItem>?> GetPvzsAsync()
        {
            var jsonResponse = await httpClient.GetStringAsync(UrlGetPvzs);
            // Parse JSON response https://metanit.com/sharp/tutorial/6.5.php

            if (jsonResponse != null && !string.IsNullOrWhiteSpace(jsonResponse))
            {
                PvzsJson pvzsJson = JsonSerializer.Deserialize<PvzsJson>(jsonResponse);

                return pvzsJson?.data?.pvz;
            }

            return null;
        }

        #pragma warning restore CS8600, CS8603

        #endregion
    }
}