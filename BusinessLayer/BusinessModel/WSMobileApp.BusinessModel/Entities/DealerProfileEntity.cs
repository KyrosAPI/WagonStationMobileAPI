using System.Runtime.Serialization;
using WSMobileApp.BusinessModel.Collections;

namespace WSMobileApp.BusinessModel.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public sealed class DealerProfileEntity 
    {
        /// <summary>
        /// Gets or sets the user profile.
        /// </summary>
        /// <value>
        /// The user profile.
        /// </value>
        [DataMember]
        public UserProfileEntity UserProfile { get; set; }

        /// <summary>
        /// Dealer Profile Id
        /// </summary>
        [DataMember]
        public long DealerProfileId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ShopName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ShopAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string PinCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal Latitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal Longitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int BusinessTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int BusinessNatureTypeId { get; set; }

        /// <summary>
        /// Shop Picture
        /// </summary>
        [DataMember]
        public AttachmentEntity ShopPicture { get; set; }

        /// <summary>
        /// Business Nature Type
        /// </summary>
        [DataMember]
        public BusinessNatureTypeEntity BusinessNatureType { get; set; }

        /// <summary>
        /// Business Type
        /// </summary>
        [DataMember]
        public BusinessTypeEntity BusinessType { get; set; }

        /// <summary>
        /// Business Nature Types
        /// </summary>
        [DataMember]
        public BusinessNatureTypeCollection BusinessNatureTypes { get; set; }

        /// <summary>
        /// Business Types
        /// </summary>
        [DataMember]
        public BusinessTypeCollection BusinessTypes { get; set; }

        /// <summary>
        /// OfferDetails
        /// </summary>
        [DataMember]
        public OfferDetailsCollection OfferDetails { get; set; }

        /// <summary>
        /// DealerRatings
        /// </summary>
        [DataMember]
        public DealerRatingsCollection DealerRatings { get; set; }

        /// <summary>
        /// OverAllRating
        /// </summary>
        [DataMember]
        public decimal OverAllRating { get; set; }

        /// <summary>
        /// PendingForServiceRequestCount
        /// </summary>
        [DataMember]
        public int PendingForServiceRequestCount { get; set; }

        [DataMember]
        public int Distance { get; set; }

        /// <summary>
        /// OfferCount
        /// </summary>
        [DataMember]
        public int OfferCount { get; set; }

        /// <summary>
        /// WashDealerBusinessCount
        /// </summary>
        [DataMember]
        public int WashDealerBusinessCount { get; set; }

        /// <summary>
        /// ServiceDealerBusinessCount
        /// </summary>
        [DataMember]
        public int ServiceDealerBusinessCount { get; set; }

        /// <summary>
        /// StoreDealerBusinessCount
        /// </summary>
        [DataMember]
        public int StoreDealerBusinessCount { get; set; }

        /// <summary>
        /// Gets or sets the google API key.
        /// </summary>
        /// <value>
        /// The google API key.
        /// </value>
        [DataMember]
        public string GoogleApiKey { get; set; }

        /// <summary>
        /// Gets or sets the service request pending for approval count.
        /// </summary>
        /// <value>
        /// The service request pending for approval count.
        /// </value>
        [DataMember]
        public int ServiceRequestPendingForApprovalCount { get; set; }

        /// <summary>
        /// Gets or sets the pending service count.
        /// </summary>
        /// <value>
        /// The pending service count.
        /// </value>
        [DataMember]
        public int PendingServiceCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is pickup drop facility available.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is pickup drop facility available; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsPickupDropFacilityAvailable { get; set; }

        /// <summary>
        /// Gets or sets the name of the authorized dealership.
        /// </summary>
        /// <value>
        /// The name of the authorized dealership.
        /// </value>
        [DataMember]
        public string AuthorizedDealershipName { get; set; }
    }
}
