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
    
    public partial class ServiceStatu
    {
        public long ServiceStatusId { get; set; }
        public long ServiceRequestId { get; set; }
        public Nullable<int> ServiceStatusTypeId { get; set; }
        public Nullable<System.DateTime> StatusUpdatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual ServiceRequest ServiceRequest { get; set; }
        public virtual ServiceStatusType ServiceStatusType { get; set; }
    }
}