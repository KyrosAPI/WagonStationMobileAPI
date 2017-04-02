
using System.Runtime.Serialization;
using WSMobileApp.BusinessModel.Collections;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    public sealed class DealerServiceEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the service requests.
        /// </summary>
        /// <value>
        /// The service requests.
        /// </value>
        [DataMember]
        public ServiceRequestCollection ServiceRequests { get; set; }
    }
}
