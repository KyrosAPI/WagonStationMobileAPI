
using System.Runtime.Serialization;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    public class BaseEntity
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
