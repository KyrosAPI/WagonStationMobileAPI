using System;
using System.IO;
using System.Runtime.Serialization;

namespace WSMobileApp.BusinessModel.Entities
{
    [DataContract]
    [Serializable]
    public sealed class AttachmentEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the attachment identifier.
        /// </summary>
        /// <value>
        /// The attachment identifier.
        /// </value>
        [DataMember]
        public long AttachmentId { get; set; }

        /// <summary>
        /// Gets or sets the user profile identifier.
        /// </summary>
        /// <value>
        /// The user profile identifier.
        /// </value>
        [DataMember]
        public long UserProfileId { get; set; }

        /// <summary>
        /// Gets or sets the service request identifier.
        /// </summary>
        /// <value>
        /// The service request identifier.
        /// </value>
        [DataMember]
        public long ServiceRequestId { get; set; }

        /// <summary>
        /// Gets or sets the file source.
        /// </summary>
        /// <value>
        /// The file source.
        /// </value>
        [DataMember]
        public string FileSource { get; set; }

        /// <summary>
        /// Gets or sets the file uploaded on.
        /// </summary>
        /// <value>
        /// The file uploaded on.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        public DateTime FileUploadedOn { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>
        /// The type of the content.
        /// </value>
        [DataMember]
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the file binary.
        /// </summary>
        /// <value>
        /// The file binary.
        /// </value>
        [DataMember]
        public byte[] FileBinary { get; set; }

        /// <summary>
        /// Gets or sets the file binary in string.
        /// </summary>
        /// <value>
        /// The file binary in string.
        /// </value>
        [DataMember]
        public string FileBinaryInString { get; set; }

        /// <summary>
        /// Gets or sets the file stream.
        /// </summary>
        /// <value>
        /// The file stream.
        /// </value>
        [DataMember]
        public Stream FileStream { get; set; }
    }
}
