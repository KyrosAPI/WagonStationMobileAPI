using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.UnitTest.ManageUserProfile
{
    class Program
    {
        static void Main()
        {
            var userProfileEntity = new UserProfileEntity
            {
                UserProfileId = 100019,
                UserName = "Dhanaraj D",
                UserEmail = "dhanaraj.d@outlook.com",
                DeviceId = "DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDd"
            };

            var ser = new DataContractJsonSerializer(typeof(UserProfileEntity));

            var mem = new MemoryStream();
            ser.WriteObject(mem, userProfileEntity);
            var data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            var webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;

            Console.WriteLine(data);

            webClient.UploadString("http://localhost:50001/WagonStationService.svc/ManageUserProfile", "POST", data);

            Console.ReadKey();
        }
    }
}
