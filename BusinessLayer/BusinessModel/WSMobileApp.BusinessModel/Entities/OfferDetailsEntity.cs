
using System;
using System.Runtime.Serialization;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    public sealed class OfferDetailsEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the offer details identifier.
        /// </summary>
        /// <value>
        /// The offer details identifier.
        /// </value>
        [DataMember]
        public long OfferDetailsId { get; set; }

        /// <summary>
        /// Gets or sets the dealer profile identifier.
        /// </summary>
        /// <value>
        /// The dealer profile identifier.
        /// </value>
        [DataMember]
        public long DealerProfileId { get; set; }

        /// <summary>
        /// Gets or sets the user profile identifier.
        /// </summary>
        /// <value>
        /// The user profile identifier.
        /// </value>
        [DataMember]
        public long UserProfileId { get; set; }

        /// <summary>
        /// Gets or sets the offer start date.
        /// </summary>
        /// <value>
        /// The offer start date.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        public DateTime OfferStartDate { get; set; }

        /// <summary>
        /// Gets or sets the offer end date.
        /// </summary>
        /// <value>
        /// The offer end date.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        public DateTime OfferEndDate { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        [DataMember]
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        [DataMember]
        public string EndDate { get; set; }

        /// <summary>
        /// Gets or sets the offer description.
        /// </summary>
        /// <value>
        /// The offer description.
        /// </value>
        [DataMember]
        public string OfferDescription { get; set; }
    }
}
