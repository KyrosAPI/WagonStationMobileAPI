using System;
using System.Runtime.Serialization;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    public sealed class DealerRatingsEntity : BaseEntity
    {
        /// <summary>
        /// DealerRatingsId
        /// </summary>
        [DataMember]
        public long DealerRatingsId { get; set; }

        /// <summary>
        /// DealerProfileId
        /// </summary>
        [DataMember]
        public long DealerProfileId { get; set; }

        /// <summary>
        /// Ratings
        /// </summary>
        [DataMember]
        public int Ratings { get; set; }

        /// <summary>
        /// UserProfileId
        /// </summary>
        [DataMember]
        public long UserProfileId { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// RatedOn
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public DateTime RatedOn { get; set; }

        /// <summary>
        /// RatingDescription
        /// </summary>
        [DataMember]
        public string RatingDescription { get; set; }

        /// <summary>
        /// Gets or sets the service request identifier.
        /// </summary>
        /// <value>
        /// The service request identifier.
        /// </value>
        [DataMember]
        public long ServiceRequestId { get; set; }

    }
}
