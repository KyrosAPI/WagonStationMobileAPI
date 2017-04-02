using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using WSMobileApp.BusinessLogic.UserProfile;
using WSMobileApp.Notification.SmsNotification;

namespace WSMobileApp.UnitTest.ValidateOneTimePassword
{
    class Program
    {
        static void Main()
        {
            var res = new UserProfileLogic().ValidateOneTimePassword("917373360447", "917373360447",2);
        }

        public static string GetTemplates()
        {
            string userName = "vikash@waggonstation.com";
            string hash = "f36bb198a73dd253c11d60f1b0c27ffeb3711434";
            string numbers = "919994304699"; // in a comma seperated list
            string message = "This is your message";
            string sender = "GYPAPP";

            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("http://api.textlocal.in/get_templates/", new NameValueCollection()
                                                                                                {
                                                                                                    { "username", userName },
                                                                                                    { "hash", hash }
                                                                                                });

                String result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }

    }
}
