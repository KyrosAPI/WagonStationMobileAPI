
using System.Runtime.Serialization;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    public sealed class ServiceDescriptionEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the service description identifier.
        /// </summary>
        /// <value>
        /// The service description identifier.
        /// </value>
        [DataMember]
        public long ServiceDescriptionId { get; set; }

        /// <summary>
        /// Gets or sets the service request identifier.
        /// </summary>
        /// <value>
        /// The service request identifier.
        /// </value>
        [DataMember]
        public long ServiceRequestId { get; set; }

        /// <summary>
        /// Gets or sets the service description type identifier.
        /// </summary>
        /// <value>
        /// The service description type identifier.
        /// </value>
        [DataMember]
        public int ServiceDescriptionTypeId { get; set; }

        /// <summary>
        /// Gets or sets the service description type code.
        /// </summary>
        /// <value>
        /// The service description type code.
        /// </value>
        [DataMember]
        public string ServiceDescriptionTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the service description.
        /// </summary>
        /// <value>
        /// The type of the service description.
        /// </value>
        [DataMember]
        public string ServiceDescriptionType { get; set; }

        /// <summary>
        /// Gets or sets the service description.
        /// </summary>
        /// <value>
        /// The service description.
        /// </value>
        [DataMember]
        public string ServiceDescription { get; set; }
    }
}
