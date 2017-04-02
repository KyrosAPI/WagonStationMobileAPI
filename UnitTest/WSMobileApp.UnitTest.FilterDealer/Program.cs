using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using WSMobileApp.BusinessModel.Entities;
using WSMobileApp.Common.DealerProfile;

namespace WSMobileApp.UnitTest.FilterDealer
{
    class Program
    {
        static void Main(string[] args)
        {
            var filterCriteria = new FilterDealerCriteria
            {
                CurrentDate = DateTime.Today.Date.ToString(),
                CurrentLatitude=Convert.ToDecimal("12.9835384",CultureInfo.InvariantCulture),
                CurrentLongitude = Convert.ToDecimal("80.262391",CultureInfo.InvariantCulture),
                IsCompanyOwned = true,
                IsHavingOffers =false,
                IsMultiBrand=false,
                IsPickupDropAvailable=true,
                AuthorizedDealerShipName="Honda"
            };



            var ser = new DataContractJsonSerializer(typeof(FilterDealerCriteria));

            var mem = new MemoryStream();
            ser.WriteObject(mem, filterCriteria);
            var data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            var webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            Console.WriteLine(data);
            try
            {
                webClient.UploadString("http://localhost:50001/WagonStationService.svc/FilterDetails", "POST", data);
            }
            catch (Exception exception)
            {

                throw;
            }

            Console.ReadKey();
        }
    }
}
