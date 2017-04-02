
using System.Runtime.Serialization;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    public sealed class BusinessNatureTypeEntity : BaseEntity
    {
        [DataMember]
        public int BusinessNatureTypeId { get; set; }

        [DataMember]
        public string BusinessNatureTypeCode { get; set; }

        [DataMember]
        public string BusinessNatureTypeDescription { get; set; }
    }
}
