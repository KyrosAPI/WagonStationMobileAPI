using System.Runtime.Serialization;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    public sealed class UpdateMobileNumberEntity 
    {
        /// <summary>
        /// Gets or sets the user profile identifier.
        /// </summary>
        /// <value>
        /// The user profile identifier.
        /// </value>
        [DataMember]
        public long UserProfileId { get; set; }

        /// <summary>
        /// Gets or sets the user mobile number.
        /// </summary>
        /// <value>
        /// The user mobile number.
        /// </value>
        [DataMember]
        public string UserMobileNumber { get; set; }
    }
}
