
using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using WSMobileApp.BusinessLogic.UserProfile;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.UnitTest.UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {

            //var response = new UserProfileLogic().UserLogin("8374502053", "images87", 1, "fQFWtuK9Y0g:APA91bE7T5AaNbHHASqvEBvCh5Roi3RWd2ndPKl6migLqkBg-DF8fsG206fBR0S4ziRGsrxy80M9lbXxJ9tnAL_KcOMthWno9-752tLiac2JpX1Ol3wZVRQqMIW1bi28T3O5EwwbnMgp", string.Empty);

            var filterDealerCriteria = new FilterDealerCriteria
            {
                CurrentDate = DateTime.Now.ToString(),
                CurrentLatitude = 0,
                CurrentLongitude = 0,
                IsCompanyOwned = true,
                IsHavingOffers = false,
                IsMultiBrand = true,
                IsPickupDropAvailable = true
            };



            var ser = new DataContractJsonSerializer(typeof(FilterDealerCriteria));

            var mem = new MemoryStream();
            ser.WriteObject(mem, filterDealerCriteria);
            var data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            var webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            Console.WriteLine(data);
            try
            {
                webClient.UploadString("http://wsmobileapp.azurewebsites.net/WagonStationService.svc/UserLogin", "POST", data);
            }
            catch (Exception exception)
            {

                throw;
            }

            var userProfileEntity = new UserProfileEntity
            {
                UserProfileId = 100027,
                UserMobileNumber = "+919994304699"
            };

            var response = new UserProfileLogic().UpdateMobileNumber(userProfileEntity.UserProfileId, userProfileEntity.UserMobileNumber);

            //var ser = new DataContractJsonSerializer(typeof(UserProfileEntity));

            //var mem = new MemoryStream();
            //ser.WriteObject(mem, userProfileEntity);
            //var data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            //var webClient = new WebClient();
            //webClient.Headers["Content-type"] = "application/json";
            //webClient.Encoding = Encoding.UTF8;
            //Console.WriteLine(data);
            //try
            //{
            //    webClient.UploadString("localhost:50001/WagonStationService.svc/UpdateMobileNumber", "POST", data);
            //}
            //catch (Exception exception)
            //{

            //    throw;
            //}

            Console.ReadKey();
        }
    }
}
