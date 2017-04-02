
using System;
using System.Runtime.Serialization;
using WSMobileApp.BusinessModel.Collections;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    public sealed class ServiceRequestEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the service request identifier.
        /// </summary>
        /// <value>
        /// The service request identifier.
        /// </value>
        [DataMember]
        public long ServiceRequestId { get; set; }

        /// <summary>
        /// Gets or sets the service request no.
        /// </summary>
        /// <value>
        /// The service request no.
        /// </value>
        [DataMember]
        public string ServiceRequestNo { get; set; }

        /// <summary>
        /// Gets or sets the dealer profile.
        /// </summary>
        /// <value>
        /// The dealer profile.
        /// </value>
        [DataMember]
        public DealerProfileEntity DealerProfile { get; set; }

        /// <summary>
        /// Gets or sets the car details.
        /// </summary>
        /// <value>
        /// The car details.
        /// </value>
        [DataMember]
        public CarDetailsEntity CarDetails { get; set; }

        /// <summary>
        /// Gets or sets the user profile identifier.
        /// </summary>
        /// <value>
        /// The user profile identifier.
        /// </value>
        [DataMember]
        public long UserProfileId { get; set; }

        /// <summary>
        /// Gets or sets the dealer profile identifier.
        /// </summary>
        /// <value>
        /// The dealer profile identifier.
        /// </value>
        [DataMember]
        public long DealerProfileId { get; set; }

        /// <summary>
        /// Gets or sets the car details identifier.
        /// </summary>
        /// <value>
        /// The car details identifier.
        /// </value>
        [DataMember]
        public long CarDetailsId { get; set; }

        /// <summary>
        /// Gets or sets the user profile.
        /// </summary>
        /// <value>
        /// The user profile.
        /// </value>
        [DataMember]
        public UserProfileEntity UserProfile { get; set; }

        /// <summary>
        /// Gets or sets the appointment date.
        /// </summary>
        /// <value>
        /// The appointment date.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        public DateTime AppointmentDate { get; set; }

        /// <summary>
        /// Gets or sets the appointment time.
        /// </summary>
        /// <value>
        /// The appointment time.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        public TimeSpan AppointmentTime { get; set; }

        /// <summary>
        /// Gets or sets the appointment time in string.
        /// </summary>
        /// <value>
        /// The appointment time in string.
        /// </value>
        [DataMember]
        public string AppointmentTimeInString { get; set; }

        /// <summary>
        /// Gets or sets the appointment request date.
        /// </summary>
        /// <value>
        /// The appointment request date.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        public DateTime AppointmentRequestDate { get; set; }

        /// <summary>
        /// Gets or sets the appointment request date in string.
        /// </summary>
        /// <value>
        /// The appointment request date in string.
        /// </value>
        [DataMember]
        public string AppointmentRequestDateInString { get; set; }

        /// <summary>
        /// Gets or sets the appointment request date in string.
        /// </summary>
        /// <value>
        /// The appointment request date in string.
        /// </value>
        [DataMember]
        public string AppointmentDateInString { get; set; }

        /// <summary>
        /// Gets or sets the appointment accepted on.
        /// </summary>
        /// <value>
        /// The appointment accepted on.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        public DateTime AppointmentAcceptedOn { get; set; }

        /// <summary>
        /// Gets or sets the service delivered on.
        /// </summary>
        /// <value>
        /// The service delivered on.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        public DateTime ServiceDeliveredOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is pickup drop available.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is pickup drop available; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsPickupDropAvailable { get; set; }

        /// <summary>
        /// Gets or sets the service descriptions.
        /// </summary>
        /// <value>
        /// The service descriptions.
        /// </value>
        [DataMember]
        public ServiceDescriptionCollection ServiceDescriptions { get; set; }

        /// <summary>
        /// Gets or sets the service status.
        /// </summary>
        /// <value>
        /// The service status.
        /// </value>
        [DataMember]
        public ServiceStatusCollection ServiceStatus { get; set; }

        /// <summary>
        /// Gets or sets the service attachments.
        /// </summary>
        /// <value>
        /// The service attachments.
        /// </value>
        [DataMember]
        public AttachmentCollection ServiceAttachments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is review submitted.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is review submitted; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsReviewSubmitted { get; set; }

        /// <summary>
        /// Gets or sets the cancel reason.
        /// </summary>
        /// <value>
        /// The cancel reason.
        /// </value>
        [DataMember]
        public string CancelReason { get; set; }
    }
}
