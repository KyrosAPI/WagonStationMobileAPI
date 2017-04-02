
using System.Runtime.Serialization;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    public sealed class BusinessTypeEntity : BaseEntity
    {
        [DataMember]
        public int BusinessTypeId { get; set; }

        [DataMember]
        public string BusinessTypeCode { get; set; }

        [DataMember]
        public string BusinessTypeDescription { get; set; }
    }
}
