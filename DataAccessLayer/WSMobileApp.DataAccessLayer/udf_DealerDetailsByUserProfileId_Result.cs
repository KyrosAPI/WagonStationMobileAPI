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
    
    public partial class udf_DealerDetailsByUserProfileId_Result
    {
        public long DealerProfileId { get; set; }
        public long UserProfileId { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string PinCode { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Nullable<int> BusinessTypeId { get; set; }
        public string BusinessTypeCode { get; set; }
        public string BusinessTypeDescription { get; set; }
        public Nullable<int> BusinessNatureTypeId { get; set; }
        public string BusinessNatureTypeDescription { get; set; }
        public string BusinessNatureTypeCode { get; set; }
        public Nullable<decimal> OverAllRating { get; set; }
        public Nullable<long> AttachmentId { get; set; }
        public string FileSource { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserMobileNumber { get; set; }
        public Nullable<int> PendingForServiceRequestCount { get; set; }
    }
}
