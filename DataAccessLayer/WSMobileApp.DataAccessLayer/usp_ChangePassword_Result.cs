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
    
    public partial class usp_ChangePassword_Result
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
        public Nullable<System.DateTime> ProfilePictureUploadedOn { get; set; }
        public string ProfilePictureFileName { get; set; }
        public string ProfilePictureContentType { get; set; }
        public byte[] ProfilePictureFileBinary { get; set; }
    }
}
