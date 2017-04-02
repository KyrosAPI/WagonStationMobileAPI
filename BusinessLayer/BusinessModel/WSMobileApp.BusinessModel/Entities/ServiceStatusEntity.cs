
using System;
using System.Runtime.Serialization;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    public sealed class ServiceStatusEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the service status identifier.
        /// </summary>
        /// <value>
        /// The service status identifier.
        /// </value>
        [DataMember]
        public long ServiceStatusId { get; set; }

        /// <summary>
        /// Gets or sets the service request identifier.
        /// </summary>
        /// <value>
        /// The service request identifier.
        /// </value>
        [DataMember]
        public long ServiceRequestId { get; set; }

        /// <summary>
        /// Gets or sets the service status type identifier.
        /// </summary>
        /// <value>
        /// The service status type identifier.
        /// </value>
        [DataMember]
        public int ServiceStatusTypeId { get; set; }

        /// <summary>
        /// Gets or sets the service status type code.
        /// </summary>
        /// <value>
        /// The service status type code.
        /// </value>
        [DataMember]
        public string ServiceStatusTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the service status type description.
        /// </summary>
        /// <value>
        /// The service status type description.
        /// </value>
        [DataMember]
        public string ServiceStatusTypeDescription { get; set; }

        /// <summary>
        /// Gets or sets the status updated on.
        /// </summary>
        /// <value>
        /// The status updated on.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        public DateTime StatusUpdatedOn { get; set; }
    }
}
