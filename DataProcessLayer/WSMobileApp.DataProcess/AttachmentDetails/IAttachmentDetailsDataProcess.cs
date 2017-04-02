using System.Data;

namespace WSMobileApp.DataProcess.AttachmentDetails
{
    public interface IAttachmentDetailsDataProcess
    {
        /// <summary>
        /// ManageProfilePicture
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="attachmentFileName">Name of the attachment file.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="fileBinary">The file binary.</param>
        /// <param name="fileSource">The file source.</param>
        /// <returns>
        /// DataSet
        /// </returns>
        DataSet ManageProfilePicture(long attachmentId, long userProfileId, string attachmentFileName, string contentType, byte[] fileBinary,string fileSource);

        /// <summary>
        /// DeleteProfilePicture
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>int</returns>
        int DeleteProfilePicture(long attachmentId);

        /// <summary>
        /// DeleteShopPicture
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>int</returns>
        int DeleteShopPicture(long attachmentId);

        /// <summary>
        /// GetAttachmentById
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>DataSet</returns>
        DataSet GetAttachmentById(long attachmentId);

        /// <summary>
        /// DeleteAttachmentById
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>int</returns>
        int DeleteAttachmentById(long attachmentId);

        /// <summary>
        /// ManageShopPicture
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="attachmentFileName">Name of the attachment file.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="fileBinary">The file binary.</param>
        /// <param name="fileSource">The file source.</param>
        /// <returns>
        /// DataSet
        /// </returns>
        DataSet ManageShopPicture(long attachmentId, long userProfileId, string attachmentFileName, string contentType, byte[] fileBinary,string fileSource);

        /// <summary>
        /// ManageAttachment
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <param name="attachmentFileName">Name of the attachment file.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="fileBinary">The file binary.</param>
        /// <param name="fileSource">The file source.</param>
        /// <returns>
        /// DataSet
        /// </returns>
        DataSet ManageAttachment(long attachmentId, string attachmentFileName, string contentType, byte[] fileBinary, string fileSource);
    }
}
