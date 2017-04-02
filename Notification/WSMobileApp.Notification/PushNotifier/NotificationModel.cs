using System;

namespace WSMobileApp.Notification.PushNotifier
{
    public sealed class NotificationModel
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the name of the sender.
        /// </summary>
        /// <value>
        /// The name of the sender.
        /// </value>
        public string SenderName { get; set; }

        /// <summary>
        /// Gets or sets the notification unique identifier.
        /// </summary>
        /// <value>
        /// The notification unique identifier.
        /// </value>
        public string NotificationGuid { get; set; }

        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>
        /// The time stamp.
        /// </value>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the name of the recepient.
        /// </summary>
        /// <value>
        /// The name of the recepient.
        /// </value>
        public string RecepientName { get; set; }

        /// <summary>
        /// Gets or sets the tracking identifier.
        /// </summary>
        /// <value>
        /// The tracking identifier.
        /// </value>
        public string TrackingId { get; set; }
    }
}
