using System;
using Twilio;
namespace WSMobileApp.UnitTest.SMSNotification
{
    class Program
    {
        static void Main(string[] args)
        {
            const string accountSid = "AC58b0704587a2ba5f753841ecb91cf336";
            const string authToken = "9778ed6aa962fbbc4d62f7b04e9c4763";
            var twilio = new TwilioRestClient(accountSid, authToken);

            var message = twilio.SendMessage("+13159391179", "+919994304699", string.Format("Use {0} as your one time password to login to your account","00000"));
            Console.WriteLine(message.Sid);
        }
    }
}
