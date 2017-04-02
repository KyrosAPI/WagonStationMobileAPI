using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.UnitTest.ManageDealerProfile
{
    class Program
    {
        static void Main(string[] args)
        {
            var userProfileEntity = new DealerProfileEntity
            {
                DealerProfileId = 0,
                UserProfile = new UserProfileEntity
                                  {
                                      UserProfileId = 100684,
                                      UserName = "Vikash Verma",
                                      UserEmail = "vikash@milesmate.com",
                                      DeviceId = "DDDDDDDDDDDDDDDDDDDDDDDDDDdd"
                                  },
                ShopName = "Kyros Technologies Private Limited",
                ShopAddress = "Nelufer Enclave, No.28, 2nd Main Road, Kasturibai Nagar, Adyar, Chennai",
                PinCode = "600020",
                BusinessType = new BusinessTypeEntity
                                   {
                                       BusinessTypeId = 2
                                   },
                BusinessNatureType = new BusinessNatureTypeEntity
                                         {
                                             BusinessNatureTypeId = 1
                                         },
                GoogleApiKey = "AIzaSyB2j693gnid2wuoGpON9tv8cJvV5ELdw38"
            };

            var ser = new DataContractJsonSerializer(typeof(DealerProfileEntity));

            var mem = new MemoryStream();
            ser.WriteObject(mem, userProfileEntity);
            var data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            var webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;

            Console.WriteLine(data);

            webClient.UploadString("http://localhost:50001/WagonStationService.svc/ManageDealerProfile", "POST", data);

            Console.ReadKey();
        }
    }
}
