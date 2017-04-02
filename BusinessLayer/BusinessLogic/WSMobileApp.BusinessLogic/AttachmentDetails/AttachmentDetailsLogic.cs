using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using WSMobileApp.BusinessLogic.EntityConverter.DataTableToEntity;
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;
using WSMobileApp.DataProcess.AttachmentDetails;

namespace WSMobileApp.BusinessLogic.AttachmentDetails
{
    public sealed class AttachmentDetailsLogic : IAttachmentDetailsLogic
    {
        #region Implementation of IAttachmentDetailsLogic

        /// <summary>
        /// ManageProfilePicture
        /// </summary>
        /// <param name="attachmentEntity">The attachment entity.</param>
        /// <returns>
        /// AttachmentEntity
        /// </returns>
        public AttachmentEntity ManageProfilePicture(AttachmentEntity attachmentEntity)
        {
            try
            {
               // attachmentEntity.FileBinary = string.IsNullOrWhiteSpace(attachmentEntity.FileBinaryInString) ? null : Encoding.ASCII.GetBytes(attachmentEntity.FileBinaryInString);
                return ConvertAttachmentCollectionToAttachmentEntity(ConvertDataSetToAttachmentCollection(InitializeAttachmentDetailsDataProcess.ManageProfilePicture(attachmentEntity.AttachmentId, attachmentEntity.UserProfileId, attachmentEntity.FileName, attachmentEntity.ContentType, null,attachmentEntity.FileSource)));
            }
            catch (Exception exception)
            {
                return ConvertExceptionToAttachmentEntity(exception);
            }
        }

        /// <summary>
        /// GetAttachmentByAttachmentId
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>AttachmentEntity</returns>
        public AttachmentEntity GetAttachmentByAttachmentId(long attachmentId)
        {
            try
            {
                return ConvertAttachmentCollectionToAttachmentEntity(ConvertDataSetToAttachmentCollection(InitializeAttachmentDetailsDataProcess.GetAttachmentById(attachmentId)));

            }
            catch (Exception exception)
            {
                return ConvertExceptionToAttachmentEntity(exception);
            }
        }

        /// <summary>
        /// ManageShopPicture
        /// </summary>
        /// <param name="attachmentEntity">The attachment entity.</param>
        /// <returns>
        /// AttachmentEntity
        /// </returns>
        public AttachmentEntity ManageShopPicture(AttachmentEntity attachmentEntity)
        {
            try
            {
                attachmentEntity.FileBinary = string.IsNullOrWhiteSpace(attachmentEntity.FileBinaryInString) ? null : Encoding.ASCII.GetBytes(attachmentEntity.FileBinaryInString);
                return ConvertAttachmentCollectionToAttachmentEntity(ConvertDataSetToAttachmentCollection(InitializeAttachmentDetailsDataProcess.ManageShopPicture(attachmentEntity.AttachmentId, attachmentEntity.UserProfileId, attachmentEntity.FileName, attachmentEntity.ContentType, attachmentEntity.FileBinary,attachmentEntity.FileSource)));
            }
            catch (Exception exception)
            {
                return ConvertExceptionToAttachmentEntity(exception);
            }
        }

        /// <summary>
        /// DeleteProfilePicture
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>AttachmentEntity</returns>
        public AttachmentEntity DeleteProfilePicture(long attachmentId)
        {
            try
            {
                var response = InitializeAttachmentDetailsDataProcess.DeleteProfilePicture(attachmentId);
                return response > 0 ? new AttachmentEntity { IsSuccess = true } : new AttachmentEntity { IsSuccess = false };
            }
            catch (Exception exception)
            {
                return new AttachmentEntity { IsSuccess = false, Message = exception.InnerException == null ? exception.Message : exception.InnerException.Message };
            }
        }

        /// <summary>
        /// DeleteShopPicture
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>AttachmentEntity</returns>
        public AttachmentEntity DeleteShopPicture(long attachmentId)
        {
            try
            {
                var response = InitializeAttachmentDetailsDataProcess.DeleteShopPicture(attachmentId);
                return response > 0 ? new AttachmentEntity { IsSuccess = true } : new AttachmentEntity { IsSuccess = false };
            }
            catch (Exception exception)
            {
                return new AttachmentEntity { IsSuccess = false, Message = exception.InnerException == null ? exception.Message : exception.InnerException.Message };
            }
        }

        /// <summary>
        /// DeleteAttachmentById
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>AttachmentEntity</returns>
        public AttachmentEntity DeleteAttachmentById(long attachmentId)
        {
            try
            {
                var response = InitializeAttachmentDetailsDataProcess.DeleteAttachmentById(attachmentId);
                return response > 0 ? new AttachmentEntity { IsSuccess = true } : new AttachmentEntity { IsSuccess = false };
            }
            catch (Exception exception)
            {
                return new AttachmentEntity { IsSuccess = false, Message = exception.InnerException == null ? exception.Message : exception.InnerException.Message };
            }
        }

        /// <summary>
        /// ManageCarDetailsPicture
        /// </summary>
        /// <param name="attachmentEntity">The attachment entity.</param>
        /// <returns>
        /// AttachmentEntity
        /// </returns>
        public AttachmentEntity ManageCarDetailsPicture(AttachmentEntity attachmentEntity)
        {
            try
            {
                attachmentEntity.FileBinary = string.IsNullOrWhiteSpace(attachmentEntity.FileBinaryInString) ? null : Encoding.ASCII.GetBytes(attachmentEntity.FileBinaryInString);
                return ConvertAttachmentCollectionToAttachmentEntity(ConvertDataSetToAttachmentCollection(InitializeAttachmentDetailsDataProcess.ManageAttachment(attachmentEntity.AttachmentId, attachmentEntity.FileName, attachmentEntity.ContentType, attachmentEntity.FileBinary,attachmentEntity.FileSource)));
            }
            catch (Exception exception)
            {
                return ConvertExceptionToAttachmentEntity(exception);
            }
        }

        /// <summary>
        /// ManageServicePicture
        /// </summary>
        /// <param name="attachmentEntity">The attachment entity.</param>
        /// <returns>
        /// AttachmentEntity
        /// </returns>
        public AttachmentEntity ManageServicePicture(AttachmentEntity attachmentEntity)
        {
            try
            {
                attachmentEntity.FileBinary = string.IsNullOrWhiteSpace(attachmentEntity.FileBinaryInString) ? null : Encoding.ASCII.GetBytes(attachmentEntity.FileBinaryInString);
                return ConvertAttachmentCollectionToAttachmentEntity(ConvertDataSetToAttachmentCollection(InitializeAttachmentDetailsDataProcess.ManageAttachment(attachmentEntity.AttachmentId, attachmentEntity.FileName, attachmentEntity.ContentType, attachmentEntity.FileBinary,attachmentEntity.FileSource)));
            }
            catch (Exception exception)
            {
                return ConvertExceptionToAttachmentEntity(exception);
            }
        }

        #endregion

        #region Initializers

        /// <summary>
        /// _initalizeAttachmentDetailsDataProcess
        /// </summary>
        private IAttachmentDetailsDataProcess _initalizeAttachmentDetailsDataProcess;

        /// <summary>
        /// InitializeAttachmentDetailsDataProcess
        /// </summary>
        private IAttachmentDetailsDataProcess InitializeAttachmentDetailsDataProcess
        {
            get
            {
                return _initalizeAttachmentDetailsDataProcess ?? (_initalizeAttachmentDetailsDataProcess = new AttachmentDetailsDataProcess());
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// ConvertStreamToByte
        /// </summary>
        /// <param name="stream">stream</param>
        /// <returns>byte[]</returns>
        private static byte[] ConvertStreamToByte(Stream stream)
        {
            var imag = new Bitmap(stream);
            return ImageToByte(imag);
        }

        /// <summary>
        /// ImageToByte
        /// </summary>
        /// <param name="img">img</param>
        /// <returns>byte[]</returns>
        public static byte[] ImageToByte(Image img)
        {
            var converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        /// <summary>
        /// ConvertDataSetToAttachmentCollection
        /// </summary>
        /// <param name="dataSet">dataSet</param>
        /// <returns>AttachmentCollection</returns>
        private static AttachmentCollection ConvertDataSetToAttachmentCollection(DataSet dataSet)
        {
            return dataSet == null
                       ? null
                       : (dataSet.Tables[0] == null
                       ? null
                       : (dataSet.Tables[0].Rows.Count <= 0
                       ? null
                       : AttachmentDataTableToEntityConverter.ConvertDataTableToAttachmentCollection(dataSet.Tables[0])));
        }

        /// <summary>
        /// ConvertExceptionToAttachmentEntity
        /// </summary>
        /// <param name="exception">exception</param>
        /// <returns>AttachmentEntity</returns>
        private static AttachmentEntity ConvertExceptionToAttachmentEntity(Exception exception)
        {
            return new AttachmentEntity { IsSuccess = false, Message = exception.InnerException == null ? exception.Message : exception.InnerException.Message };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attachmentCollection"></param>
        /// <returns></returns>
        private static AttachmentEntity ConvertAttachmentCollectionToAttachmentEntity(AttachmentCollection attachmentCollection)
        {
            return attachmentCollection == null ? null : attachmentCollection.Items == null ? null : attachmentCollection.Items.FirstOrDefault();
        }

        #endregion
    }
}
