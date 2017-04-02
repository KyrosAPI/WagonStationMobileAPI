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
    
    public partial class DealerProfile
    {
        public DealerProfile()
        {
            this.DealerPictures = new HashSet<DealerPicture>();
            this.DealerRatings = new HashSet<DealerRating>();
            this.OfferDetails = new HashSet<OfferDetail>();
            this.ServiceRequests = new HashSet<ServiceRequest>();
            this.ShopPictures = new HashSet<ShopPicture>();
        }
    
        public long DealerProfileId { get; set; }
        public long UserProfileId { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string PinCode { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Nullable<int> BusinessTypeId { get; set; }
        public Nullable<int> BusinessNatureTypeId { get; set; }
        public string GoogleApiKey { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual ICollection<DealerPicture> DealerPictures { get; set; }
        public virtual BusinessNatureType BusinessNatureType { get; set; }
        public virtual BusinessType BusinessType { get; set; }
        public virtual DealerProfile DealerProfile1 { get; set; }
        public virtual DealerProfile DealerProfile2 { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<DealerRating> DealerRatings { get; set; }
        public virtual ICollection<OfferDetail> OfferDetails { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
        public virtual ICollection<ShopPicture> ShopPictures { get; set; }
    }
}
