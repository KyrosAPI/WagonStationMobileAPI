using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.UnitTest.ManageCarDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            var carDetailsEntity = new CarDetailsEntity
            {
                UserProfileId = 100442,
                CarDetailsId = 0,
                CarName = "Maruthi Suzuki",
                CarMakeYear = 2003,
                CarModelName = "Zen",
                NumberPlate = "TN 02 VW 5487",
                CarPicture = new AttachmentEntity
                                 {
                                     AttachmentId = 101719
                                 },
                                 CarDisplayName = "nick name",
                                 TrackingId = "142"
            };



            var ser = new DataContractJsonSerializer(typeof(CarDetailsEntity));

            var mem = new MemoryStream();
            ser.WriteObject(mem, carDetailsEntity);
            var data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            var webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            Console.WriteLine(data);
            try
            {
                webClient.UploadString("http://localhost:50001/WagonStationService.svc/ManageCarDetails", "POST", data);
            }
            catch (Exception)
            {
                
                throw;
            }
            
            Console.ReadKey();
        }
    }
}
