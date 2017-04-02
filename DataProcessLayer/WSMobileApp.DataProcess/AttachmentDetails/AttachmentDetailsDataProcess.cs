using System.Collections.Generic;
using System.Data;
using WSMobileApp.DataAccessLayer;
using WSMobileApp.DataProcess.Resource;

namespace WSMobileApp.DataProcess.AttachmentDetails
{
    public sealed class AttachmentDetailsDataProcess : IAttachmentDetailsDataProcess
    {
        #region Implementation of IAttachmentDeatilsDataProcess

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
        public DataSet ManageProfilePicture(long attachmentId, long userProfileId, string attachmentFileName, string contentType, byte[] fileBinary, string fileSource)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_ManageProfilePicture, new Dictionary<string, object>
                                                                                                         {
                                                                                                             {DataProcessResource.spparam_AttachmentId,attachmentId},
                                                                                                             {DataProcessResource.spparam_UserProfileId,userProfileId},
                                                                                                             {DataProcessResource.spparam_AttachmentFileName,attachmentFileName},
                                                                                                             {DataProcessResource.spparam_ContentType,contentType},
                                                                                                             {DataProcessResource.spparam_FileBinary,fileBinary},
                                                                                                             {DataProcessResource.spparam_FileSource,fileSource}
                                                                                                         });
        }

        /// <summary>
        /// DeleteProfilePicture
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>int</returns>
        public int DeleteProfilePicture(long attachmentId)
        {
            return InitializeDataAccess.ExecuteNonQuery(DataProcessResource.usp_DeleteProfilePicture, new Dictionary<string, object>
                                                                                                          {
                                                                                                              {DataProcessResource.spparam_AttachmentId,attachmentId}
                                                                                                          });   
        }

        /// <summary>
        /// DeleteShopPicture
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>int</returns>
        public int DeleteShopPicture(long attachmentId)
        {
            return InitializeDataAccess.ExecuteNonQuery(DataProcessResource.usp_DeleteShopPicture, new Dictionary<string, object>
                                                                                                       {
                                                                                                           {DataProcessResource.spparam_AttachmentId,attachmentId}
                                                                                                       });   
        }

        /// <summary>
        /// GetAttachmentById
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>DataSet</returns>
        public DataSet GetAttachmentById(long attachmentId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_GetAttachmentById, new Dictionary<string, object>
                                                                                                     {
                                                                                                         {DataProcessResource.spparam_AttachmentId,attachmentId}
                                                                                                     });
        }

        /// <summary>
        /// DeleteAttachmentById
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>int</returns>
        public int DeleteAttachmentById(long attachmentId)
        {
            return InitializeDataAccess.ExecuteNonQuery(DataProcessResource.usp_DeleteAttachmentById, new Dictionary<string, object>
                                                                                                         {
                                                                                                             {DataProcessResource.spparam_AttachmentId,attachmentId}
                                                                                                         });
        }

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
        public DataSet ManageShopPicture(long attachmentId, long userProfileId, string attachmentFileName, string contentType, byte[] fileBinary,string fileSource)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_ManageShopPicture, new Dictionary<string, object>
                                                                                                         {
                                                                                                             {DataProcessResource.spparam_AttachmentId,attachmentId},
                                                                                                             {DataProcessResource.spparam_UserProfileId,userProfileId},
                                                                                                             {DataProcessResource.spparam_AttachmentFileName,attachmentFileName},
                                                                                                             {DataProcessResource.spparam_ContentType,contentType},
                                                                                                             {DataProcessResource.spparam_FileBinary,fileBinary},
                                                                                                             {DataProcessResource.spparam_FileSource,fileSource}
                                                                                                         });
        }

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
        public DataSet ManageAttachment(long attachmentId, string attachmentFileName, string contentType, byte[] fileBinary, string fileSource)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_ManagePicture, new Dictionary<string, object>
                                                                                                         {
                                                                                                             {DataProcessResource.spparam_AttachmentId,attachmentId},
                                                                                                             {DataProcessResource.spparam_AttachmentFileName,attachmentFileName},
                                                                                                             {DataProcessResource.spparam_ContentType,contentType},
                                                                                                             {DataProcessResource.spparam_FileBinary,fileBinary},
                                                                                                             {DataProcessResource.spparam_FileSource,fileSource}
                                                                                                         });
        }

        #endregion

        #region Initializers

        /// <summary>
        /// The _initialize data access
        /// </summary>
        private IDataAccess _initializeDataAccess;

        /// <summary>
        /// Gets the initialize data access.
        /// </summary>
        /// <value>
        /// The initialize data access.
        /// </value>
        private IDataAccess InitializeDataAccess
        {
            get { return _initializeDataAccess ?? (_initializeDataAccess = new DataAccess()); }
        }

        #endregion
    }
}
