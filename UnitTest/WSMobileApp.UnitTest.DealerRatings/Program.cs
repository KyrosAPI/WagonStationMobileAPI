using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.UnitTest.DealerRatings
{
    class Program
    {
        static void Main(string[] args)
        {
            var offerDetailsEntity = new DealerRatingsEntity
            {
                DealerProfileId = 212,
                Ratings = 0,
                UserProfileId = 100654,
                RatingDescription = "Rating Description, Rating Descirption, Rating Description",
                ServiceRequestId = 100967
            };



            var ser = new DataContractJsonSerializer(typeof(DealerRatingsEntity));

            var mem = new MemoryStream();
            ser.WriteObject(mem, offerDetailsEntity);
            var data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            var webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            Console.WriteLine(data);
            try
            {
                webClient.UploadString("http://localhost:50001/WagonStationService.svc/CreateDealerRatings", "POST", data);
            }
            catch (Exception  exception)
            {
                
            }
           
            Console.WriteLine("Review Submitted successfully...");
            Console.ReadKey();
        }
    }
}
