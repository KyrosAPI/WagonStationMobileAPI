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
    
    public partial class CarPicture
    {
        public long CarPictureId { get; set; }
        public long CarDetailsId { get; set; }
        public long AttachmentId { get; set; }
    
        public virtual CarDetail CarDetail { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
