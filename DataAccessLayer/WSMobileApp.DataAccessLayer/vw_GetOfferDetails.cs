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
    
    public partial class vw_GetOfferDetails
    {
        public long UserProfileId { get; set; }
        public string UserQualifier { get; set; }
        public string UserPassword { get; set; }
        public string OneTimePassword { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeCode { get; set; }
        public string UserTypeDescription { get; set; }
        public Nullable<System.DateTime> LastLoginOn { get; set; }
        public string UserName { get; set; }
        public string UserMobileNumber { get; set; }
        public string UserEmail { get; set; }
        public Nullable<bool> IsPromotionalEmailRequired { get; set; }
        public Nullable<long> UserProfilePictureId { get; set; }
        public Nullable<long> ProfilePictureAttachmentId { get; set; }
        public string ProfilePictureSource { get; set; }
        public Nullable<System.DateTime> ProfilePictureUploaedOn { get; set; }
        public Nullable<long> DealerProfileId { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string PinCode { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Nullable<int> BusinessTypeId { get; set; }
        public string BusinessTypeCode { get; set; }
        public string BusinessTypeDescription { get; set; }
        public Nullable<int> BusinessNatureTypeId { get; set; }
        public string BusinessNatureTypeCode { get; set; }
        public string BusinessNatureTypeDescription { get; set; }
        public Nullable<long> ShopPictureAttachmentId { get; set; }
        public string ShopPictureFileSource { get; set; }
        public Nullable<System.DateTime> ShopPictureUploadedOn { get; set; }
        public Nullable<System.DateTime> OfferStartDate { get; set; }
        public Nullable<System.DateTime> OfferEndDate { get; set; }
        public string OfferDescription { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
