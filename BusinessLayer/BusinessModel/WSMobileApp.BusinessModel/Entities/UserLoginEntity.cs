using System.Runtime.Serialization;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    public sealed class UserLoginEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the user qualifier.
        /// </summary>
        /// <value>
        /// The user qualifier.
        /// </value>
        [DataMember]
        public string UserQualifier { get; set; }

        /// <summary>
        /// Gets or sets the user password.
        /// </summary>
        /// <value>
        /// The user password.
        /// </value>
        [DataMember]
        public string UserPassword { get; set; }

        /// <summary>
        /// Gets or sets the user type identifier.
        /// </summary>
        /// <value>
        /// The user type identifier.
        /// </value>
        [DataMember]
        public int UserTypeId { get; set; }

        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        [DataMember]
        public string DeviceId { get; set; }
    }
}
