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
    
    public partial class UserType
    {
        public UserType()
        {
            this.UserProfiles = new HashSet<UserProfile>();
        }
    
        public int UserTypeId { get; set; }
        public string UserTypeCode { get; set; }
        public string UserTypeDescription { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
