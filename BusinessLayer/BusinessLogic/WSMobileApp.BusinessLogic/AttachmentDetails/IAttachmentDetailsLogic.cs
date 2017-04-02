using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.BusinessLogic.AttachmentDetails
{
    public interface IAttachmentDetailsLogic
    {
        /// <summary>
        /// ManageProfilePicture
        /// </summary>
        /// <param name="attachmentEntity">The attachment entity.</param>
        /// <returns>
        /// AttachmentEntity
        /// </returns>
        AttachmentEntity ManageProfilePicture(AttachmentEntity attachmentEntity);

        /// <summary>
        /// GetAttachmentByAttachmentId
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>AttachmentEntity</returns>
        AttachmentEntity GetAttachmentByAttachmentId(long attachmentId);

        /// <summary>
        /// ManageShopPicture
        /// </summary>
        /// <param name="attachmentEntity">The attachment entity.</param>
        /// <returns>
        /// AttachmentEntity
        /// </returns>
        AttachmentEntity ManageShopPicture(AttachmentEntity attachmentEntity);

        /// <summary>
        /// DeleteProfilePicture
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>AttachmentEntity</returns>
        AttachmentEntity DeleteProfilePicture(long attachmentId);

        /// <summary>
        /// DeleteShopPicture
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>AttachmentEntity</returns>
        AttachmentEntity DeleteShopPicture(long attachmentId);

        /// <summary>
        /// DeleteAttachmentById
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>AttachmentEntity</returns>
        AttachmentEntity DeleteAttachmentById(long attachmentId);

        /// <summary>
        /// ManageCarDetailsPicture
        /// </summary>
        /// <param name="attachmentEntity">The attachment entity.</param>
        /// <returns>
        /// AttachmentEntity
        /// </returns>
        AttachmentEntity ManageCarDetailsPicture(AttachmentEntity attachmentEntity);

        /// <summary>
        /// ManageServicePicture
        /// </summary>
        /// <param name="attachmentEntity">The attachment entity.</param>
        /// <returns>
        /// AttachmentEntity
        /// </returns>
        AttachmentEntity ManageServicePicture(AttachmentEntity attachmentEntity);
    }
}
