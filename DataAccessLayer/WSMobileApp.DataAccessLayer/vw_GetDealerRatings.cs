//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSMobileApp.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class vw_GetDealerRatings
    {
        public Nullable<long> DealerProfileId { get; set; }
        public string DealerName { get; set; }
        public string DealerEmail { get; set; }
        public string DealerMobileNumber { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string PinCode { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Nullable<long> ShopPictureAttachmentId { get; set; }
        public string ShopPictureFileSource { get; set; }
        public Nullable<System.DateTime> ShopPictureUploadedOn { get; set; }
        public long DealerRatingsId { get; set; }
        public int Rating { get; set; }
        public long RatedBy { get; set; }
        public Nullable<System.DateTime> RatedOn { get; set; }
        public string RatingDescription { get; set; }
        public long RatedUserProfileId { get; set; }
        public string RatedUserName { get; set; }
        public string RatedUserEmail { get; set; }
        public string RatedUserMobileNumber { get; set; }
        public Nullable<long> RatedUserAttachmentId { get; set; }
        public string RatedUserAttachmentSource { get; set; }
        public Nullable<long> ProfilePictureAttachmentId { get; set; }
    }
}
