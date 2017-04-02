using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using WSMobileApp.BusinessLogic.EntityConverter.Resource;
using WSMobileApp.Common.DataSecurity;
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.BusinessLogic.EntityConverter.DataTableToEntity
{
    public sealed class DealerProfileDataTableToEntityConverter
    {
        /// <summary>
        /// Converts the data table to dealer profile entity.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="isFromLandingPage">if set to <c>true</c> [is from landing page].</param>
        /// <returns></returns>
        public static DealerProfileEntity ConvertDataTableToDealerProfileEntity(DataTable dataTable,bool isFromLandingPage = false)
        {
            if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }

            return (from DataRow dataRow in dataTable.Rows select ConvertDataRowToDealerProfileEntity(dataRow,isFromLandingPage)).FirstOrDefault();
        }

        /// <summary>
        /// Converts the data table to dealer profile collection.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="isFromLandingPage">if set to <c>true</c> [is from landing page].</param>
        /// <returns></returns>
        public static DealerProfileCollection ConvertDataTableToDealerProfileCollection(DataTable dataTable,bool isFromLandingPage = false)
        {
            if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }

            var response = new DealerProfileCollection { Items = new List<DealerProfileEntity>() };
            foreach (DataRow dataRow in dataTable.Rows)
            {
                response.Items.Add(ConvertDataRowToDealerProfileEntity(dataRow,isFromLandingPage));
            }

            return response;
        }

        #region Private Methods

        /// <summary>
        /// Converts the data row to dealer profile entity.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <param name="isFromLandingPage">if set to <c>true</c> [is from landing page].</param>
        /// <returns></returns>
        private static DealerProfileEntity ConvertDataRowToDealerProfileEntity(DataRow dataRow,bool isFromLandingPage)
        {
            return new DealerProfileEntity
                       {
                           UserProfile = new UserProfileEntity
                                             {
                                                 IsSuccess = true,
                                                 UserProfileId = dataRow[EntityConverterResource.UserProfileId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.UserProfileId], CultureInfo.InvariantCulture),
                                                 UserQualifier = dataRow[EntityConverterResource.UserQualifier] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.UserQualifier], CultureInfo.InvariantCulture),
                                                 UserPassword = dataRow[EntityConverterResource.UserPassword] == DBNull.Value ? string.Empty : EncryptDecrypt.Decrypt(Convert.ToString(dataRow[EntityConverterResource.UserPassword], CultureInfo.InvariantCulture)),
                                                 OneTimePassword = dataRow[EntityConverterResource.OneTimePassword] == DBNull.Value ? string.Empty : EncryptDecrypt.Decrypt(Convert.ToString(dataRow[EntityConverterResource.OneTimePassword], CultureInfo.InvariantCulture)),
                                                 UserTypeId = dataRow[EntityConverterResource.UserTypeId] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[EntityConverterResource.UserTypeId], CultureInfo.InvariantCulture),
                                                 LastLoginOn = dataRow[EntityConverterResource.LastLoginOn] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow[EntityConverterResource.LastLoginOn], CultureInfo.InvariantCulture),
                                                 UserType = new UserTypeEntity
                                                 {
                                                     UserTypeId = dataRow[EntityConverterResource.UserTypeId] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[EntityConverterResource.UserTypeId], CultureInfo.InvariantCulture),
                                                     UserTypeCode = dataRow[EntityConverterResource.UserTypeCode] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.UserTypeCode], CultureInfo.InvariantCulture),
                                                     UserTypeDescription = dataRow[EntityConverterResource.UserTypeDescription] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.UserTypeDescription], CultureInfo.InvariantCulture)
                                                 },
                                                 UserName = dataRow[EntityConverterResource.UserName] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.UserName], CultureInfo.InvariantCulture),
                                                 UserMobileNumber = dataRow[EntityConverterResource.UserMobileNumber] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.UserMobileNumber], CultureInfo.InvariantCulture),
                                                 UserEmail = dataRow[EntityConverterResource.UserEmail] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.UserEmail], CultureInfo.InvariantCulture),
                                                 IsPrmotionalEmailRequired = dataRow[EntityConverterResource.IsPromotionalEmailRequired] != DBNull.Value && Convert.ToBoolean(dataRow[EntityConverterResource.IsPromotionalEmailRequired], CultureInfo.InvariantCulture),
                                                 ProfilePicture = new AttachmentEntity
                                                 {
                                                     IsSuccess = true,
                                                     AttachmentId = dataRow[EntityConverterResource.ProfilePictureAttachmentId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.ProfilePictureAttachmentId], CultureInfo.InvariantCulture),
                                                     FileSource = dataRow[EntityConverterResource.ProfilePictureSource] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.ProfilePictureSource], CultureInfo.InvariantCulture),
                                                     FileUploadedOn = dataRow[EntityConverterResource.ProfilePictureUploadedOn] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow[EntityConverterResource.ProfilePictureUploadedOn], CultureInfo.InvariantCulture),
                                                     FileName = dataRow[EntityConverterResource.ProfilePictureFileName] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.ProfilePictureFileName], CultureInfo.InvariantCulture),
                                                     ContentType = dataRow[EntityConverterResource.ProfilePictureContentType] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.ProfilePictureContentType], CultureInfo.InvariantCulture),
                                                     //FileBinary = dataRow[EntityConverterResource.ProfilePictureFileBinary] == DBNull.Value ? null : (byte[])(dataRow[EntityConverterResource.ProfilePictureFileBinary]),
                                                     //FileBinaryInString = dataRow[EntityConverterResource.ProfilePictureFileBinary] == DBNull.Value ? string.Empty : Encoding.ASCII.GetString((byte[])(dataRow[EntityConverterResource.ProfilePictureFileBinary]))

                                                 },
                                                 DeviceId = dataRow[EntityConverterResource.DeviceId] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.DeviceId],CultureInfo.InvariantCulture),
                                             },
                           DealerProfileId = dataRow[EntityConverterResource.DealerProfileId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.DealerProfileId], CultureInfo.InvariantCulture),
                           ShopName = dataRow[EntityConverterResource.ShopName] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.ShopName], CultureInfo.InvariantCulture),
                           ShopAddress = dataRow[EntityConverterResource.ShopAddress] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.ShopAddress], CultureInfo.InvariantCulture),
                           GoogleApiKey = dataRow[EntityConverterResource.GoogleApiKey] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.GoogleApiKey], CultureInfo.InvariantCulture),
                           PinCode = dataRow[EntityConverterResource.PinCode] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.PinCode], CultureInfo.InvariantCulture),
                           Latitude = dataRow[EntityConverterResource.Latitude] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow[EntityConverterResource.Latitude], CultureInfo.InvariantCulture),
                           Longitude = dataRow[EntityConverterResource.Longitude] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow[EntityConverterResource.Longitude], CultureInfo.InvariantCulture),
                           BusinessType = new BusinessTypeEntity
                                              {
                                                  IsSuccess = true,
                                                  BusinessTypeId = dataRow[EntityConverterResource.BusinessTypeId] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[EntityConverterResource.BusinessTypeId], CultureInfo.InvariantCulture),
                                                  BusinessTypeCode = dataRow[EntityConverterResource.BusinessTypeCode] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.BusinessTypeCode], CultureInfo.InvariantCulture),
                                                  BusinessTypeDescription = dataRow[EntityConverterResource.BusinessTypeDescription] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.BusinessTypeDescription], CultureInfo.InvariantCulture)
                                              },
                           BusinessNatureType = new BusinessNatureTypeEntity
                                                    {
                                                        IsSuccess = true,
                                                        BusinessNatureTypeId = dataRow[EntityConverterResource.BusinessNatureTypeId] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[EntityConverterResource.BusinessNatureTypeId], CultureInfo.InvariantCulture),
                                                        BusinessNatureTypeCode = dataRow[EntityConverterResource.BusinessNatureTypeCode] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.BusinessNatureTypeCode], CultureInfo.InvariantCulture),
                                                        BusinessNatureTypeDescription = dataRow[EntityConverterResource.BusinessNatureTypeDescription] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.BusinessNatureTypeDescription], CultureInfo.InvariantCulture)
                                                    },
                           ShopPicture = new AttachmentEntity
                                             {
                                                 IsSuccess = true,
                                                 AttachmentId = dataRow[EntityConverterResource.ShopPictureAttachmentId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.ShopPictureAttachmentId], CultureInfo.InvariantCulture),
                                                 FileSource = dataRow[EntityConverterResource.ShopPictureFileSource] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.ShopPictureFileSource], CultureInfo.InvariantCulture),
                                                 FileUploadedOn = dataRow[EntityConverterResource.ShopPictureUploadedOn] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow[EntityConverterResource.ShopPictureUploadedOn], CultureInfo.InvariantCulture),
                                                 FileName = dataRow[EntityConverterResource.ShopPictureFileName] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.ShopPictureFileName], CultureInfo.InvariantCulture),
                                                 ContentType = dataRow[EntityConverterResource.ShopPictureContentType] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.ShopPictureContentType], CultureInfo.InvariantCulture),
                                                 //FileBinary = dataRow[EntityConverterResource.ShopPictureFileBinary] == DBNull.Value ? null : (byte[])(dataRow[EntityConverterResource.ShopPictureFileBinary]),
                                                 //FileBinaryInString = dataRow[EntityConverterResource.ShopPictureFileBinary] == DBNull.Value ? string.Empty : Encoding.ASCII.GetString((byte[])(dataRow[EntityConverterResource.ShopPictureFileBinary]))
                                             },
                           OverAllRating = dataRow[EntityConverterResource.OverAllRating] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[EntityConverterResource.OverAllRating], CultureInfo.InvariantCulture),
                           OfferCount = dataRow[EntityConverterResource.OfferCount] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[EntityConverterResource.OfferCount], CultureInfo.InvariantCulture),
                           Distance = !isFromLandingPage ? 0 : dataRow[EntityConverterResource.Distance] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[EntityConverterResource.Distance],CultureInfo.InvariantCulture),
                           ServiceRequestPendingForApprovalCount = dataRow[EntityConverterResource.ServiceRequestPendingForApprovalCount] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[EntityConverterResource.ServiceRequestPendingForApprovalCount],CultureInfo.InvariantCulture),
                           PendingServiceCount = dataRow[EntityConverterResource.PendingServiceCount] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[EntityConverterResource.PendingServiceCount],CultureInfo.InvariantCulture),
                           IsPickupDropFacilityAvailable = dataRow[EntityConverterResource.IsPickUpDropFacilityAvailable] != DBNull.Value && Convert.ToBoolean(dataRow[EntityConverterResource.IsPickUpDropFacilityAvailable],CultureInfo.InvariantCulture),
                           AuthorizedDealershipName = dataRow[EntityConverterResource.AuthorizedDealershipName] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.AuthorizedDealershipName],CultureInfo.InvariantCulture)
                       };
        }

        #endregion
    }
}
