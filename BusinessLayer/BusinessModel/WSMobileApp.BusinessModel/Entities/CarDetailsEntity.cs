
using System.Runtime.Serialization;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    public sealed class CarDetailsEntity : BaseEntity
    {
        /// <summary>
        /// CarDetailsId
        /// </summary>
        [DataMember]
        public long CarDetailsId { get; set; }

        /// <summary>
        /// UserProfileId
        /// </summary>
        [DataMember]
        public long UserProfileId { get; set; }

        /// <summary>
        /// CarName
        /// </summary>
        [DataMember]
        public string CarName { get; set; }

        /// <summary>
        /// CarModelName
        /// </summary>
        [DataMember]
        public string CarModelName { get; set; }

        /// <summary>
        /// NumberPlate
        /// </summary>
        [DataMember]
        public string NumberPlate { get; set; }

        /// <summary>
        /// CarMakeYear
        /// </summary>
        [DataMember]
        public int CarMakeYear { get; set; }

        /// <summary>
        /// Gets or sets the car picture.
        /// </summary>
        /// <value>
        /// The car picture.
        /// </value>
        [DataMember]
        public AttachmentEntity CarPicture { get; set; }

        /// <summary>
        /// Gets or sets the display name of the car.
        /// </summary>
        /// <value>
        /// The display name of the car.
        /// </value>
        [DataMember]
        public string CarDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the tracking identifier.
        /// </summary>
        /// <value>
        /// The tracking identifier.
        /// </value>
        [DataMember]
        public string TrackingId { get; set; }
    }
}
