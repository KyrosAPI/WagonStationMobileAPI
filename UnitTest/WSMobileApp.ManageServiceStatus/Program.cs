
using System;
using System.IO;
using System.Net;
using System.Text;

namespace WSMobileApp.ManageServiceStatus
{
    class Program
    {
        static void Main()
        {
            var webRequest = WebRequest.Create("http://localhost:50001/WagonStationService.svc/CancelServiceRequest/100693");
            var webResponse = webRequest.GetResponse();

            var enc = Encoding.GetEncoding(1252);
            var responseStream = new StreamReader(webResponse.GetResponseStream());
            var response = responseStream.ReadToEnd();
            responseStream.Close();

            Console.WriteLine(response);
        }
    }
}
