using System.Runtime.Serialization;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    public sealed class FilterDealerCriteria
    {
        /// <summary>
        /// Gets or sets the current latitude.
        /// </summary>
        /// <value>
        /// The current latitude.
        /// </value>
        [DataMember]
        public decimal CurrentLatitude { get; set; }

        /// <summary>
        /// Gets or sets the current longitude.
        /// </summary>
        /// <value>
        /// The current longitude.
        /// </value>
        [DataMember]
        public decimal CurrentLongitude { get; set; }

        /// <summary>
        /// Gets or sets the current date.
        /// </summary>
        /// <value>
        /// The current date.
        /// </value>
        [DataMember]
        public string CurrentDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is company owned.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is company owned; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsCompanyOwned { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is multi brand.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is multi brand; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsMultiBrand { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is pickup drop available.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is pickup drop available; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsPickupDropAvailable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is having offers.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is having offers; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsHavingOffers { get; set; }

        /// <summary>
        /// Gets or sets the name of the authorized dealer ship.
        /// </summary>
        /// <value>
        /// The name of the authorized dealer ship.
        /// </value>
        [DataMember]
        public string AuthorizedDealerShipName { get; set; }
    }
}
