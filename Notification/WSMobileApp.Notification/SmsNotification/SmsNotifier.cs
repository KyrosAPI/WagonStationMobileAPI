using System;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

using WSMobileApp.BusinessModel.Entities;
using WSMobileApp.Notification.Resource;
using System.Xml.Linq;
using System.Linq;
using System.Threading;

namespace WSMobileApp.Notification.SmsNotification
{
    public sealed class SmsNotifier : ISmsNotifier
    {
        #region Implementation of ISmsNotifier

        /// <summary>
        /// Notifiys the one time password.
        /// </summary>
        /// <param name="toMobileNumber">To mobile number.</param>
        /// <param name="oneTimePassword">The one time password.</param>
        /// <returns></returns>
        public bool NotifiyOneTimePassword(string toMobileNumber, string oneTimePassword)
        {
            var message = string.Format(NotificationResource.Msg_OneTimePassword, oneTimePassword);
            return toMobileNumber.StartsWith("91",StringComparison.InvariantCultureIgnoreCase) ? NotifySms(toMobileNumber,message) : NotifyInternationalSms(toMobileNumber, message);
        }

        /// <summary>
        /// Notifies the forgot password.
        /// </summary>
        /// <param name="toMobileNumber">To mobile number.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        public bool NotifyForgotPassword(string toMobileNumber, string newPassword)
        {
            var message = string.Format(NotificationResource.Msg_ResetPassword, newPassword);
            return toMobileNumber.StartsWith("91",StringComparison.InvariantCultureIgnoreCase) ? NotifySms(toMobileNumber,message) : NotifyInternationalSms(toMobileNumber, message);
        }

        /// <summary>
        /// Notifies the accept service request.
        /// </summary>
        /// <param name="dealerName">Name of the dealer.</param>
        /// <param name="carNumber">The car number.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="toMobileNumber">To mobile number.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="senderId">The sender identifier.</param>
        /// <returns></returns>
        public bool NotifyAcceptServiceRequest(string dealerName, string carNumber, string userName, string toMobileNumber, string deviceId, string senderId)
        {
            return SendPushNotification(string.Format(NotificationResource.Msg_AcceptServiceRequest, carNumber, dealerName), deviceId, senderId);
        }

        /// <summary>
        /// Notifies the user cancel service request.
        /// </summary>
        /// <param name="dealerName">Name of the dealer.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="toMobileNumber">To mobile number.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="senderId">The sender identifier.</param>
        /// <returns></returns>
        public bool NotifyUserCancelServiceRequest(string dealerName, string userName, string toMobileNumber, string deviceId, string senderId)
        {
            //return NotifyInternationalSms(toMobileNumber, string.Format(NotificationResource.Msg_CancelServiceRequest, userName));
            return SendPushNotification(string.Format(NotificationResource.Msg_CancelServiceRequest, userName), deviceId, senderId);
        }

        /// <summary>
        /// Notifies the reject service request.
        /// </summary>
        /// <param name="dealerName">Name of the dealer.</param>
        /// <param name="carNumber">The car number.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="toMobileNumber">To mobile number.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="senderId">The sender identifier.</param>
        /// <returns></returns>
        public bool NotifyRejectServiceRequest(string dealerName, string carNumber, string userName, string toMobileNumber, string deviceId, string senderId)
        {
            //return NotifyInternationalSms(toMobileNumber, string.Format(NotificationResource.Msg_DeclineServiceRequest, carNumber, dealerName));
            return SendPushNotification(string.Format(NotificationResource.Msg_DeclineServiceRequest, carNumber, dealerName), deviceId, senderId);
        }

        /// <summary>
        /// Notifies the update work in progress.
        /// </summary>
        /// <param name="dealerName">Name of the dealer.</param>
        /// <param name="carNumber">The car number.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="toMobileNumber">To mobile number.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="senderId">The sender identifier.</param>
        /// <returns></returns>
        public bool NotifyUpdateWorkInProgress(string dealerName, string carNumber, string userName, string toMobileNumber, string deviceId, string senderId)
        {
            //return NotifyInternationalSms(toMobileNumber, string.Format(NotificationResource.Msg_WorkInProgress, carNumber, dealerName));
            return SendPushNotification(string.Format(NotificationResource.Msg_WorkInProgress, carNumber, dealerName), deviceId, senderId);
        }

        /// <summary>
        /// Notifies the update ready for delivery.
        /// </summary>
        /// <param name="dealerName">Name of the dealer.</param>
        /// <param name="carNumber">The car number.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="toMobileNumber">To mobile number.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="senderId">The sender identifier.</param>
        /// <returns></returns>
        public bool NotifyUpdateReadyForDelivery(string dealerName, string carNumber, string userName, string toMobileNumber, string deviceId, string senderId)
        {
            //return NotifyInternationalSms(toMobileNumber, string.Format(NotificationResource.Msg_ReadyForDelivery, carNumber, dealerName));
            return SendPushNotification(string.Format(NotificationResource.Msg_ReadyForDelivery, carNumber, dealerName), deviceId, senderId);
        }

        /// <summary>
        /// Notifies the delivered.
        /// </summary>
        /// <param name="dealerName">Name of the dealer.</param>
        /// <param name="carNumber">The car number.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="toMobileNumber">To mobile number.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns></returns>
        public bool NotifyDelivered(string dealerName, string carNumber, string userName, string toMobileNumber, string deviceId, string senderId)
        {
            //return NotifyInternationalSms(toMobileNumber, string.Format(NotificationResource.Msg_Delivered, carNumber, dealerName));
            return SendPushNotification(string.Format(NotificationResource.Msg_Delivered, carNumber, dealerName), deviceId, senderId);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Notifies the SMS.
        /// </summary>
        /// <param name="toMobileNumber">To mobile number.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        private static bool NotifySms(string toMobileNumber, string message)
        {
            using (var webClient = new WebClient())
            {
                var response = webClient.UploadValues(ConfigurationManager.AppSettings[NotificationResource.SmsApiUrl], new NameValueCollection
                                                                                              {
                                                                                                  {NotificationResource.Apikey_UserName,ConfigurationManager.AppSettings[NotificationResource.SmsUsername]},
                                                                                                  {NotificationResource.Apikey_Hash,ConfigurationManager.AppSettings[NotificationResource.SmsApiHashKey]},
                                                                                                  {NotificationResource.Apikey_Numbers,toMobileNumber.Substring(2)},
                                                                                                  {NotificationResource.Apikey_Message,message},
                                                                                                  {NotificationResource.Apikey_Sender,ConfigurationManager.AppSettings[NotificationResource.SmsSender]},
                                                                                                  {NotificationResource.ApiKey_Format,NotificationResource.ApiFormat }
                                                                                              });
                return ProcessLocalSmsDeliveryStatus(response);
            }
        }

        /// <summary>
        /// Notifies the international SMS.
        /// </summary>
        /// <param name="toMobileNumber">To mobile number.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        private static bool NotifyInternationalSms(string toMobileNumber, string message)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    return ProcessInternationalSmsDeliveryStatus(webClient.UploadValues(ConfigurationManager.AppSettings[NotificationResource.SmsInternationalApiUrl], new NameValueCollection
                                                                                              {
                                                                                                  {NotificationResource.Apikey_UserName,ConfigurationManager.AppSettings[NotificationResource.SmsInternationalApiUsername]},
                                                                                                  {NotificationResource.Apikey_Hash,ConfigurationManager.AppSettings[NotificationResource.SmsInternationalApiHashKey]},
                                                                                                  {NotificationResource.Apikey_Numbers, toMobileNumber},
                                                                                                  {NotificationResource.Apikey_Message,message},
                                                                                                  {NotificationResource.Apikey_Sender,ConfigurationManager.AppSettings[NotificationResource.SmsInternationalSender]},
                                                                                                  {NotificationResource.ApiKey_Test,ConfigurationManager.AppSettings[NotificationResource.IsSmsTestingEnviroment] },
                                                                                                  {NotificationResource.ApiKey_Format,NotificationResource.ApiFormat }
                                                                                              }));

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Proceses the SMS delivery status.
        /// </summary>
        /// <param name="apiResponse">The API response.</param>
        /// <returns></returns>
        private static bool ProcessInternationalSmsDeliveryStatus(byte[] apiResponse)
        {
            var xmlResponse = XDocument.Parse(Encoding.UTF8.GetString(apiResponse));

            var sendStatus = xmlResponse.Descendants("status").FirstOrDefault().Value;

            bool isMessageSent = isMessageSent = !string.IsNullOrWhiteSpace(sendStatus) && string.Equals(sendStatus.Trim(), "success", StringComparison.InvariantCultureIgnoreCase);

            var messageId = string.Empty;
            if (isMessageSent)
            {
                messageId = xmlResponse.Root.Element("messages").Element("message").Element("id").Value.Trim();
            }
            return isMessageSent && !string.IsNullOrWhiteSpace(messageId);
        }

        /// <summary>
        /// Processes the local SMS delivery status.
        /// </summary>
        /// <param name="apiResponse">The API response.</param>
        /// <returns></returns>
        private static bool ProcessLocalSmsDeliveryStatus(byte[] apiResponse)
        {
            var xmlResponse = XDocument.Parse(Encoding.UTF8.GetString(apiResponse));

            var sendStatus = xmlResponse.Descendants("status").FirstOrDefault().Value;

            bool isMessageSent = isMessageSent = !string.IsNullOrWhiteSpace(sendStatus) && string.Equals(sendStatus.Trim(), "success", StringComparison.InvariantCultureIgnoreCase);

            var messageId = string.Empty;
            if (isMessageSent)
            {
                messageId = xmlResponse.Root.Element("messages").Element("message").Element("id").Value.Trim();
            }
            return isMessageSent && !string.IsNullOrWhiteSpace(messageId);
        }

        /// <summary>
        /// Gets the message status.
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        /// <returns></returns>
        private static bool GetInternationMessageDeliveryStatus(string messageId)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    var response = webClient.UploadValues(ConfigurationManager.AppSettings[NotificationResource.SmsInternationalApiMessageStatus], new NameValueCollection
                                                                                              {
                                                                                                  {NotificationResource.Apikey_UserName,ConfigurationManager.AppSettings[NotificationResource.SmsInternationalApiUsername]},
                                                                                                  {NotificationResource.Apikey_Hash,ConfigurationManager.AppSettings[NotificationResource.SmsInternationalApiHashKey]},
                                                                                                  {NotificationResource.ApiKey_MessageId,messageId },
                                                                                                  {NotificationResource.ApiKey_Format, NotificationResource.ApiFormat }
                                                                                              });

                    var xmlResponse = XDocument.Parse(Encoding.UTF8.GetString(response));

                    var messageDeliveryStatus = xmlResponse.Root.Element("message").Element("status").Value.Trim();

                    return !string.IsNullOrWhiteSpace(messageDeliveryStatus) && string.Equals(messageDeliveryStatus, "D", StringComparison.InvariantCultureIgnoreCase);

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the local SMS delivery status.
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        /// <returns></returns>
        private static bool GetLocalSmsDeliveryStatus(string messageId)
        {
            
            using (var webClient = new WebClient())
            {
                var response = webClient.UploadValues(ConfigurationManager.AppSettings[NotificationResource.SmsLocalSmsDeliveryStatus], new NameValueCollection
                                                                                              {
                                                                                                  {NotificationResource.Apikey_UserName,ConfigurationManager.AppSettings[NotificationResource.SmsUsername]},
                                                                                                  {NotificationResource.Apikey_Hash,ConfigurationManager.AppSettings[NotificationResource.SmsApiHashKey]},
                                                                                                  {NotificationResource.ApiKey_MessageId,messageId },
                                                                                                  {NotificationResource.ApiKey_Format, NotificationResource.ApiFormat }
                                                                                              });
                var xmlResponse = XDocument.Parse(Encoding.UTF8.GetString(response));

                var messageDeliveryStatus = xmlResponse.Root.Element("message").Element("status").Value.Trim();

                return !string.IsNullOrWhiteSpace(messageDeliveryStatus) && string.Equals(messageDeliveryStatus, "D", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        /// <summary>
        /// Gets the one time password message template.
        /// </summary>
        /// <returns></returns>
        private static SmsTemplateResponseEntity GetMessageTemplates()
        {
            using (var webClient = new WebClient())
            {
                var response = webClient.UploadValues(ConfigurationManager.AppSettings[NotificationResource.SmsApiTemplateUrl], new NameValueCollection
                                                                                                                                    {
                                                                                                                                         { NotificationResource.Apikey_UserName,ConfigurationManager.AppSettings[NotificationResource.SmsUsername]},
                                                                                                                                         { NotificationResource.Apikey_Hash,ConfigurationManager.AppSettings[NotificationResource.SmsApiHashKey]}
                                                                                                                                    });

                var jsonResponse = Encoding.UTF8.GetString(response);

                var myDeserializedObjList = (SmsTemplateResponseEntity)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse, typeof(SmsTemplateResponseEntity));

                return myDeserializedObjList;
            }
        }

        /// <summary>
        /// Sends the push notification.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="senderId">The sender identifier.</param>
        /// <returns></returns>
        private static bool SendPushNotification(string message, string deviceId, string senderId)
        {
            try
            {

                string applicationID = Convert.ToString(ConfigurationManager.AppSettings["FireBaseApplicationId"], CultureInfo.InvariantCulture);

                senderId = Convert.ToString(ConfigurationManager.AppSettings["FireBaseSenderId"], CultureInfo.InvariantCulture);

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = message,
                        title = "Milesmate",
                        sound = "Enabled"

                    }
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                string str = sResponseFromServer;
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return false;
            }
        }

    }



    #endregion

    //#region Constants

    ///// <summary>
    ///// Gets the initialize twilio rest client.
    ///// </summary>
    ///// <value>
    ///// The initialize twilio rest client.
    ///// </value>
    //private static TwilioRestClient InitializeTwilioRestClient
    //{
    //    get
    //    {
    //        return new TwilioRestClient(AccountSid, AuthenticationToken);
    //    }
    //}

    //private const string OneTimePasswordNotificationMessage = "Your one time password: {0}";

    ///// <summary>
    ///// Gets the account sid.
    ///// </summary>
    ///// <value>
    ///// The account sid.
    ///// </value>
    //private static string AccountSid
    //{
    //    get
    //    {
    //        return ConfigurationManager.AppSettings["TwilioAccountSID"];
    //    }
    //}

    ///// <summary>
    ///// Gets the authentication token.
    ///// </summary>
    ///// <value>
    ///// The authentication token.
    ///// </value>
    //private static string AuthenticationToken
    //{
    //    get
    //    {
    //        return ConfigurationManager.AppSettings["TwilioAuthenticationToken"];
    //    }
    //}

    //#endregion

}

