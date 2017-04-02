
using System.Collections.Generic;
using System.Data;

using WSMobileApp.DataAccessLayer;
using WSMobileApp.DataProcess.Resource;

namespace WSMobileApp.DataProcess.UserProfile
{
    public sealed class UserProfileDataProcess : IUserProfileDataProcess
    {
        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="userQualifier">User Qualifier</param>
        /// <param name="userPassword">User Password</param>
        /// <param name="userTypeId">User Type Id</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="senderId">The sender identifier.</param>
        /// <returns>
        /// DataSet
        /// </returns>
        public DataSet UserLogin(string userQualifier, string userPassword, int userTypeId, string deviceId, string senderId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_UserLogin, new Dictionary<string, object>()
            {
                {DataProcessResource.spparam_UserQualifier, userQualifier},
                {DataProcessResource.spparam_UserPassword, userPassword},
                {DataProcessResource.spparam_UserTypeId, userTypeId},
                {DataProcessResource.spparam_DeviceId,deviceId },
                {DataProcessResource.spparam_SenderId,senderId }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userQualifier"></param>
        /// <param name="userPassword"></param>
        /// <param name="oneTimePassword"></param>
        /// <param name="userTypeId"></param>
        /// <returns></returns>
        public DataSet ValidateOneTimePassword(string userQualifier, string userPassword, string oneTimePassword, int userTypeId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_ValidateOneTimePassword, new Dictionary<string, object> { { DataProcessResource.spparam_UserQualifier, userQualifier }, { DataProcessResource.spparam_UserPassword, userPassword }, { DataProcessResource.spparam_OneTimePassword, oneTimePassword }, { DataProcessResource.spparam_UserTypeId, userTypeId } });
        }

        /// <summary>
        /// ResendOneTimePassword
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <param name="userPassword">userPassword</param>
        /// <param name="oneTimePassword">oneTimePassword</param>
        /// <param name="userTypeId">userTypeId</param>
        /// <returns>DataSet</returns>
        public DataSet ResendOneTimePassword(string userQualifier, string userPassword, string oneTimePassword, int userTypeId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_ResendOneTimePassword, new Dictionary<string, object> { { DataProcessResource.spparam_UserQualifier, userQualifier }, { DataProcessResource.spparam_UserPassword, userPassword }, { DataProcessResource.spparam_OneTimePassword, oneTimePassword }, { DataProcessResource.spparam_UserTypeId, userTypeId } });
        }

        /// <summary>
        /// Checks the one time password.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="oneTimePassword">The one time password.</param>
        /// <returns></returns>
        public DataSet CheckOneTimePassword(long userProfileId, string oneTimePassword)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_CheckOneTimePassword, new Dictionary<string, object>
            {
                { DataProcessResource.spparam_UserProfileId,userProfileId },
                { DataProcessResource.spparam_OneTimePassword,oneTimePassword }
            });
        }

        /// <summary>
        /// ForgotPassword
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <param name="userPassword">The user password.</param>
        /// <returns>
        /// DataSet
        /// </returns>
        public DataSet ForgotPassword(string userQualifier, string userPassword)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_ForgotPassword, new Dictionary<string, object>
                                                                                                   {
                                                                                                       { DataProcessResource.spparam_UserQualifier, userQualifier },
                                                                                                       { DataProcessResource.spparam_UserPassword,userPassword }
                                                                                                   });
        }

        /// <summary>
        /// ChangePassword
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="oldPassword">oldPassword</param>
        /// <param name="newPassword">newPassword</param>
        /// <returns>DataSet</returns>
        public DataSet ChangePassword(long userProfileId, string oldPassword, string newPassword)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_ChangePassword, new Dictionary<string, object> { { DataProcessResource.spparam_UserProfileId, userProfileId }, { DataProcessResource.spparam_OldPassword, oldPassword }, { DataProcessResource.spparam_NewPassword, newPassword } });
        }

        /// <summary>
        /// UpdateMobileNumber
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="userMobileNumber">userMobileNumber</param>
        /// <param name="oneTimePassword">oneTimePassword</param>
        /// <returns>DataSet</returns>
        public DataSet UpdateMobileNumber(long userProfileId, string userMobileNumber, string oneTimePassword)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_UpdateMobileNumber, new Dictionary<string, object> { { DataProcessResource.spparam_UserProfileId, userProfileId }, { DataProcessResource.spparam_UserMobileNumber, userMobileNumber }, { DataProcessResource.spparam_OneTimePassword, oneTimePassword } });
        }

        /// <summary>
        /// ManageUserProfile
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="userName">userName</param>
        /// <param name="userEmail">userEmail</param>
        /// <param name="isPromotionalEmailRequird">isPromotionalEmailRequird</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>
        /// DataSet
        /// </returns>
        public DataSet ManageUserProfile(long userProfileId, string userName, string userEmail, bool isPromotionalEmailRequird, string deviceId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_ManageUserProfile, new Dictionary<string, object> { { DataProcessResource.spparam_UserProfileId, userProfileId }, { DataProcessResource.spparam_UserName, userName }, { DataProcessResource.spparam_UserEmail, userEmail }, { DataProcessResource.spparam_IsPromotionalEmailRequired, isPromotionalEmailRequird }, { DataProcessResource.spparam_DeviceId, deviceId } });
        }

        /// <summary>
        /// ManageDealerProfile
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="userName">userName</param>
        /// <param name="userEmail">userEmail</param>
        /// <param name="shopName">shopName</param>
        /// <param name="shopAddress">shopAddress</param>
        /// <param name="pinCode">pinCode</param>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <param name="businessTypeId">businessTypeId</param>
        /// <param name="businessNatureTypeId">businessNatureTypeId</param>
        /// <param name="googleApiKey">The google API key.</param>
        /// <param name="isPickupDropFacilityAvailable">if set to <c>true</c> [is pickup drop facility available].</param>
        /// <param name="authorizedDealershipName">Name of the authorized dealership.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>
        /// DataSet
        /// </returns>
        public DataSet ManageDealerProfile(long dealerProfileId, long userProfileId, string userName, string userEmail, string shopName, string shopAddress, string pinCode, decimal latitude, decimal longitude, int businessTypeId, int businessNatureTypeId, string googleApiKey, bool isPickupDropFacilityAvailable, string authorizedDealershipName, string deviceId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_ManageDealerProfile, new Dictionary<string, object>
                                                                                                       {
                                                                                                           {DataProcessResource.spparam_DealerProfileId,dealerProfileId},
                                                                                                           {DataProcessResource.spparam_UserProfileId,userProfileId},
                                                                                                           {DataProcessResource.spparam_UserName,userName},
                                                                                                           {DataProcessResource.spparam_UserEmail,userEmail},
                                                                                                           {DataProcessResource.spparam_ShopName,shopName},
                                                                                                           {DataProcessResource.spparam_ShopAddress,shopAddress},
                                                                                                           {DataProcessResource.spparam_PinCode,pinCode},
                                                                                                           {DataProcessResource.spparam_Latitude,latitude},
                                                                                                           {DataProcessResource.spparam_Longitude,longitude},
                                                                                                           {DataProcessResource.spparam_BusinessNatureTypeId,businessNatureTypeId},
                                                                                                           {DataProcessResource.spparam_BusinessTypeId,businessTypeId},
                                                                                                           {DataProcessResource.spparam_GoogleApiKey,googleApiKey},
                                                                                                           {DataProcessResource.spparam_IsPickupDropFacilityAvailable,isPickupDropFacilityAvailable},
                                                                                                           {DataProcessResource.spparam_AuthorizedDealershipName,authorizedDealershipName},
                                                                                                           {DataProcessResource.spparam_DeviceId,deviceId }
                                                                                                       });
        }

        /// <summary>
        /// Determines whether [is mobile number already registered] [the specified user qualifier].
        /// </summary>
        /// <param name="userQualifier">The user qualifier.</param>
        /// <returns></returns>
        public IDataReader IsMobileNumberAlreadyRegistered(string userQualifier)
        {
            return InitializeDataAccess.ExecuteDataReader(DataProcessResource.usp_IsMobileNumberRegistered, new Dictionary<string, object>
                                                                                                                {
                                                                                                                    {DataProcessResource.spparam_UserQualifier,userQualifier}
                                                                                                                });
        }

        #region Initializers

        private IDataAccess _initializeDataAccess;

        private IDataAccess InitializeDataAccess
        {
            get { return _initializeDataAccess ?? (_initializeDataAccess = new DataAccess()); }
        }

        #endregion
    }
}
