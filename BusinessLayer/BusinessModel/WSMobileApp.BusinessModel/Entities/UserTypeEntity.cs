
using System.Runtime.Serialization;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    public sealed class UserTypeEntity
    {
        [DataMember]
        public int UserTypeId { get; set; }

        [DataMember]
        public string UserTypeCode { get; set; }

        [DataMember]
        public string UserTypeDescription { get; set; }
    }
}
