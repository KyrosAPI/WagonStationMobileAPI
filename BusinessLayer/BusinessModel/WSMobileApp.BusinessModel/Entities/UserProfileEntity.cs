using System;
using System.Runtime.Serialization;
using WSMobileApp.BusinessModel.Collections;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    public class UserProfileEntity : BaseEntity
    {
        /// <summary>
        /// User Profile Id
        /// </summary>
        [DataMember]
        public long UserProfileId { get; set; }

        /// <summary>
        /// User Qualifier
        /// </summary>
        [DataMember]
        public string UserQualifier { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        [DataMember]
        public string UserPassword { get; set; }

        /// <summary>
        /// One Time Password
        /// </summary>
        [DataMember]
        public string OneTimePassword { get; set; }

        /// <summary>
        /// User TypeId
        /// </summary>
        [DataMember]
        public int UserTypeId { get; set; }

        /// <summary>
        /// Last Login On
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime LastLoginOn { get; set; }

        /// <summary>
        /// User Name 
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// User Mobile Number
        /// </summary>
        [DataMember]
        public string UserMobileNumber { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        [DataMember]
        public string UserEmail { get; set; }

        /// <summary>
        /// User Type Entity
        /// </summary>
        [DataMember]
        public UserTypeEntity UserType { get; set; }

        /// <summary>
        /// Gets or sets the profile picture.
        /// </summary>
        /// <value>
        /// The profile picture.
        /// </value>
        [DataMember]
        public AttachmentEntity ProfilePicture { get; set; }

        /// <summary>
        /// Dealer Profile Entity
        /// </summary>
        [DataMember]
        public DealerProfileCollection DealerProfiles { get; set; }

        /// <summary>
        /// Gets or sets the car details.
        /// </summary>
        /// <value>
        /// The car details.
        /// </value>
        [DataMember]
        public CarDetailsCollection CarDetails { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is prmotional email required.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is prmotional email required; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsPrmotionalEmailRequired { get; set; }

        /// <summary>
        /// Gets or sets the business types.
        /// </summary>
        /// <value>
        /// The business types.
        /// </value>
        [DataMember]
        public BusinessTypeCollection BusinessTypes { get; set; }

        /// <summary>
        /// Gets or sets the business nature types.
        /// </summary>
        /// <value>
        /// The business nature types.
        /// </value>
        [DataMember]
        public BusinessNatureTypeCollection BusinessNatureTypes { get; set; }

        /// <summary>
        /// Gets or sets the service history count.
        /// </summary>
        /// <value>
        /// The service history count.
        /// </value>
        [DataMember]
        public int ServiceHistoryCount { get; set; }

        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        [DataMember]
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the sender identifier.
        /// </summary>
        /// <value>
        /// The sender identifier.
        /// </value>
        [DataMember]
        public string SenderId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is one time password verified.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is one time password verified; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsOneTimePasswordVerified { get; set; }
    }
}
