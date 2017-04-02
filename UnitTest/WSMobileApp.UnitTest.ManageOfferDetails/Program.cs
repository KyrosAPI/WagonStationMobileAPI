
using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.UnitTest.ManageOfferDetails
{
    class Program
    {
        static void Main()
        {


            //const string json = @"{'OfferDetailsId': 0,'UserProfileId' : 100009,'StartDate': '2013-01-20','EndDate': '2016-01-20','OfferDescription': 'hello this is a example text offer' }";

            const string json = @"{'UserProfileId':100012,'AttachmentId':0,'FileName':'100012_profilepicture.jpg','FileBinaryInString':'[B@415c9d30','ContentType':'jpeg'}";



            //const string url = "http://wsmobileapplication.azurewebsites.net/WagonStationService.svc/ManageOfferDetails";

            //var request = (HttpWebRequest)WebRequest.Create(url);
            //request.ContentType = "application/json; charset=utf-8"; //set the content type to JSON
            //request.Method = "POST"; //make an HTTP POST

            var ser = new DataContractJsonSerializer(typeof(AttachmentEntity));

            var mem = new MemoryStream();
            ser.WriteObject(mem, JsonConvert.DeserializeObject<AttachmentEntity>(json));
            var data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            var webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            Console.WriteLine(data);
            webClient.UploadString("http://wsmobileapplication.azurewebsites.net/WagonStationService.svc/ManageProfilePicture", "POST", data);
            Console.WriteLine("Order placed successfully...");
            Console.ReadKey();

            

            //// Get the response.
            //WebResponse response = request.GetResponse();
            //var streamReader = new StreamReader(response.GetResponseStream());
            //var result = streamReader.ReadToEnd();

            //var offerDetailsEntity = new OfferDetailsEntity
            //{
            //    OfferDetailsId = 0,
            //    UserProfileId = 100013,
            //    OfferStartDate = DateTime.Now,
            //    OfferEndDate = DateTime.Now.AddDays(10),
            //    OfferDescription = "hello this is a example text offer"
            //};



            //var ser = new DataContractJsonSerializer(typeof(OfferDetailsEntity));

            //var mem = new MemoryStream();
            //ser.WriteObject(mem, offerDetailsEntity);
            //var data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            //var webClient = new WebClient();
            //webClient.Headers["Content-type"] = "application/json";
            //webClient.Encoding = Encoding.UTF8;
            //Console.WriteLine(data);
            //webClient.UploadString("http://localhost:50001/WagonStationService.svc/ManageOfferDetails", "POST", data);
            //Console.WriteLine("Order placed successfully...");
            //Console.ReadKey();
        }
    }
}
