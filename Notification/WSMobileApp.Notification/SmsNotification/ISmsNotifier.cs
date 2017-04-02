namespace WSMobileApp.Notification.SmsNotification
{
    public interface ISmsNotifier
    {
        /// <summary>
        /// Notifiys the one time password.
        /// </summary>
        /// <param name="toMobileNumber">To mobile number.</param>
        /// <param name="oneTimePassword">The one time password.</param>
        /// <returns></returns>
        bool NotifiyOneTimePassword(string toMobileNumber, string oneTimePassword);

        /// <summary>
        /// Notifies the forgot password.
        /// </summary>
        /// <param name="toMobileNumber">To mobile number.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        bool NotifyForgotPassword(string toMobileNumber, string newPassword);

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
        bool NotifyAcceptServiceRequest(string dealerName, string carNumber, string userName, string toMobileNumber, string deviceId,string senderId);

        /// <summary>
        /// Notifies the user cancel service request.
        /// </summary>
        /// <param name="dealerName">Name of the dealer.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="toMobileNumber">To mobile number.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="senderId">The sender identifier.</param>
        /// <returns></returns>
        bool NotifyUserCancelServiceRequest(string dealerName, string userName, string toMobileNumber,string deviceId, string senderId);

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
        bool NotifyRejectServiceRequest(string dealerName, string carNumber, string userName, string toMobileNumber,string deviceId, string senderId);

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
        bool NotifyUpdateWorkInProgress(string dealerName,string carNumber, string userName, string toMobileNumber,string deviceId, string senderId);

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
        bool NotifyUpdateReadyForDelivery(string dealerName,string carNumber, string userName, string toMobileNumber,string deviceId, string senderId);

        /// <summary>
        /// Notifies the delivered.
        /// </summary>
        /// <param name="dealerName">Name of the dealer.</param>
        /// <param name="carNumber">The car number.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="toMobileNumber">To mobile number.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="senderId">The sender identifier.</param>
        /// <returns></returns>
        bool NotifyDelivered(string dealerName,string carNumber, string userName, string toMobileNumber, string deviceId, string senderId);
    }
}
