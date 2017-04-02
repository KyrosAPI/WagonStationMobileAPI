
using System.Data;

namespace WSMobileApp.DataProcess.UserProfile
{
    public interface IUserProfileDataProcess
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
        DataSet UserLogin(string userQualifier, string userPassword, int userTypeId, string deviceId, string senderId);

        /// <summary>
        /// ValidateOneTimePassword
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <param name="userPassword">userPassword</param>
        /// <param name="oneTimePassword"></param>
        /// <param name="userTypeId"></param>
        /// <returns></returns>
        DataSet ValidateOneTimePassword(string userQualifier, string userPassword, string oneTimePassword, int userTypeId);

        /// <summary>
        /// ResendOneTimePassword
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <param name="userPassword">userPassword</param>
        /// <param name="oneTimePassword">oneTimePassword</param>
        /// <param name="userTypeId">userTypeId</param>
        /// <returns></returns>
        DataSet ResendOneTimePassword(string userQualifier, string userPassword, string oneTimePassword, int userTypeId);

        /// <summary>
        /// Checks the one time password.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="oneTimePassword">The one time password.</param>
        /// <returns></returns>
        DataSet CheckOneTimePassword(long userProfileId, string oneTimePassword);

        /// <summary>
        /// ForgotPassword
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// DataSet
        /// </returns>
        DataSet ForgotPassword(string userQualifier, string password);

        /// <summary>
        /// ChangePassword
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="oldPassword">oldPassword</param>
        /// <param name="newPassword">newPassword</param>
        /// <returns>DataSet</returns>
        DataSet ChangePassword(long userProfileId, string oldPassword, string newPassword);

        /// <summary>
        /// UpdateMobileNumber
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="userMobileNumber">userMobileNumber</param>
        /// <param name="oneTimePassword">oneTimePassword</param>
        /// <returns>DataSet</returns>
        DataSet UpdateMobileNumber(long userProfileId, string userMobileNumber, string oneTimePassword);

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
        DataSet ManageUserProfile(long userProfileId, string userName, string userEmail, bool isPromotionalEmailRequird, string deviceId);

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
        DataSet ManageDealerProfile(long dealerProfileId, long userProfileId, string userName, string userEmail, string shopName, string shopAddress, string pinCode, decimal latitude, decimal longitude, int businessTypeId, int businessNatureTypeId, string googleApiKey, bool isPickupDropFacilityAvailable, string authorizedDealershipName, string deviceId);

        /// <summary>
        /// Determines whether [is mobile number already registered] [the specified user qualifier].
        /// </summary>
        /// <param name="userQualifier">The user qualifier.</param>
        /// <returns></returns>
        IDataReader IsMobileNumberAlreadyRegistered(string userQualifier);
    }
}
