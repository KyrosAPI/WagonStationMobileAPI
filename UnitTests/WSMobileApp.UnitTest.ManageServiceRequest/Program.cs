
using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
using WSMobileApp.BusinessModel.Entities;
using WSMobileApp.BusinessLogic.ServiceDetails;

namespace WSMobileApp.UnitTest.ManageServiceRequest
{
    class Program
    {
        static void Main()
        {
            // const string json = @"{'AppointmentRequestDateInString':'2016-07-25','AppointmentTimeInString':'07:25 AM','AppointmentDateInString':'2016-07-25','CarDetails':{'CarDetailsId':100538},'DealerProfile':{'DealerProfileId':172},'IsPickupDropAvailable':1,'ServiceDescriptions':{'Items':[{'ServiceDescription':'Inspection Description','ServiceDescriptionTypeId':1},{'ServiceDescription':'Tyre puncture','ServiceDescriptionTypeId':3}]},'ServiceRequestId':0,'UserProfile':{'UserProfileId':100472}}";

           // const string json = @"{'AppointmentRequestDateInString':'2016-07-17 06:55:09','AppointmentTimeInString':'09:30 PM','AppointmentDateInString':'2016-02-27','CarDetails':{'CarDetailsId':100538},'DealerProfile':{'DealerProfileId':172},'IsPickupDropAvailable':1,'ServiceDescriptions':{'Items':[{'ServiceDescription':'Inspection Description','ServiceDescriptionTypeId':1},{'ServiceDescription':'Tyre puncture','ServiceDescriptionTypeId':3}]},'ServiceRequestId':0,'UserProfile':{'UserProfileId':100033}}";


            const string url = "http://wsmobileapp.azurewebsites.net/WagonStationService.svc/ManageServiceRequest";

            var serviceRequestEntity = new ServiceRequestEntity
            {
                AppointmentDateInString = DateTime.Now.ToString(),
                AppointmentRequestDateInString = DateTime.Now.ToString(),
                AppointmentTimeInString = "09:30 PM",
                CarDetails = new CarDetailsEntity { CarDetailsId = 100002 },
                DealerProfile = new DealerProfileEntity { DealerProfileId = 3 },
                IsPickupDropAvailable = true,
                ServiceAttachments = new BusinessModel.Collections.AttachmentCollection { Items = new System.Collections.Generic.List<AttachmentEntity> { new AttachmentEntity { AttachmentId = 100030 } } },
                ServiceDescriptions = new BusinessModel.Collections.ServiceDescriptionCollection { Items = new System.Collections.Generic.List<ServiceDescriptionEntity> { new ServiceDescriptionEntity { ServiceDescription = "Test", ServiceDescriptionTypeId = 3 } } },
                ServiceRequestId = 0,
                UserProfile = new UserProfileEntity { UserProfileId = 100033}
            };

            var response = new ServiceDetailsLogic().ManageServiceRequest(serviceRequestEntity);

            ////var request = (HttpWebRequest)WebRequest.Create(url);
            ////request.ContentType = "application/json; charset=utf-8"; //set the content type to JSON
            ////request.Method = "POST"; //make an HTTP POST

            //var ser = new DataContractJsonSerializer(typeof(ServiceRequestEntity));

            //var mem = new MemoryStream();
            //ser.WriteObject(mem, serviceRequestEntity);
            //var data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            //Console.WriteLine(data);

            //ser.WriteObject(mem, JsonConvert.DeserializeObject<ServiceRequestEntity>(json));
            //var data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            //var webClient = new WebClient();
            //webClient.Headers["Content-type"] = "application/json";
            //webClient.Encoding = Encoding.UTF8;
            //Console.WriteLine(data);
            //webClient.UploadString("http://localhost:50001/WagonStationService.svc/ManageServiceRequest", "POST", data);
            //Console.WriteLine("Order placed successfully...");
            //Console.ReadKey();

            //var mem = new MemoryStream();
            //ser.WriteObject(mem, offerDetailsEntity);

        }
    }
}
