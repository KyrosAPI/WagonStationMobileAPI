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
    public sealed class UserProfileDataTableToEntityConverter
    {
        #region UserProfile


        /// <summary>
        /// Converts the data table to user profile entity.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static UserProfileEntity ConvertDataTableToUserProfileEntity(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }

            return (from DataRow dataRow in dataTable.Rows select ConvertDataRowToUserProfileEntity(dataRow)).FirstOrDefault();
        }

        /// <summary>
        /// Converts the data table to user profile collection.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static UserProfileCollection ConvertDataTableToUserProfileCollection(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }

            var response = new UserProfileCollection { Items = new List<UserProfileEntity>() };

            foreach (DataRow dataRow in dataTable.Rows)
            {
                response.Items.Add(ConvertDataRowToUserProfileEntity(dataRow));
            }

            return response;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Converts the data row to user profile entity.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <returns></returns>
        private static UserProfileEntity ConvertDataRowToUserProfileEntity(DataRow dataRow)
        {
                return new UserProfileEntity
                {
                    IsSuccess =  true,
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
                    ServiceHistoryCount = dataRow[EntityConverterResource.ServiceHistoryCount] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[EntityConverterResource.ServiceHistoryCount],CultureInfo.InvariantCulture),
                    DeviceId = dataRow[EntityConverterResource.DeviceId] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.DeviceId],CultureInfo.InvariantCulture),
                    SenderId = dataRow[EntityConverterResource.SenderId] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.SenderId],CultureInfo.InvariantCulture),
                    IsOneTimePasswordVerified = dataRow[EntityConverterResource.IsOneTimePasswordVerified] != DBNull.Value && Convert.ToBoolean(dataRow[EntityConverterResource.IsOneTimePasswordVerified],CultureInfo.InvariantCulture) 
                };
        }

        #endregion
    }
}
