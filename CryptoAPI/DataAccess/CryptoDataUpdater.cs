using CryptoAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace CryptoAPI
{
    public class CryptoDataUpdater : ICryptoDataUpdater
    {
        private static string API_KEY = "5040419d-cebe-43e8-b290-e3e8da6d8357";

        public void Update()
        {
            using(var context = new CryptoMonitorContext())
            {
                List<Crypto> cryptos = context.Crypto.ToList();
                Crypto[] newCryptos = makeAPICall().ToArray();

                int i = 0;

                while (i <= 9)
                {
                    foreach (Crypto crypto in cryptos)
                    {
                        crypto.Name = newCryptos[i].Name;
                        crypto.Price = newCryptos[i].Price;
                        i++;
                    }
                }

                context.SaveChanges();
            }
        }

        private List<Crypto> makeAPICall()
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "10";
            queryString["convert"] = "EUR";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            string json = client.DownloadString(URL.ToString());

            dynamic dataSet = JsonConvert.DeserializeObject(json);

            List<Crypto> cryptos = new List<Crypto>();

            foreach (var coin in dataSet.data)
            {
                Crypto crypto = new Crypto();
                crypto.Name = coin.name;
                crypto.Price = coin.quote.EUR.price;
                cryptos.Add(crypto);
            }

            return cryptos;
        }
    }
}
