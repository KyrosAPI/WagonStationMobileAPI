
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.Common.UserProfile
{
    public interface IUserProfileLogic
    {
        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <param name="userPassword">userPassword</param>
        /// <param name="userTypeId">userTypeId</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="senderId">The sender identifier.</param>
        /// <returns>
        /// UserProfileEntity
        /// </returns>
        UserProfileEntity UserLogin(string userQualifier, string userPassword, int userTypeId,string deviceId,string senderId);

        /// <summary>
        /// ValidateOneTimePassword
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <param name="userPassword">userPassword</param>
        /// <param name="userTypeId">userTypeId</param>
        /// <returns>UserProfileEntity</returns>
        UserProfileEntity ValidateOneTimePassword(string userQualifier, string userPassword, int userTypeId);

        /// <summary>
        /// ResendOneTimePassword
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <param name="userPassword">userPassword</param>
        /// <param name="userTypeId">userTypeId</param>
        /// <returns>UserProfileEntity</returns>
        UserProfileEntity ResendOneTimePassword(string userQualifier, string userPassword, int userTypeId);

        /// <summary>
        /// Checks the one time password.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="oneTimePassword">The one time password.</param>
        /// <returns></returns>
        UserProfileEntity CheckOneTimePassword(long userProfileId, string oneTimePassword);

        /// <summary>
        /// ForgotPassword
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <returns>UserProfileEntity</returns>
        UserProfileEntity ForgotPassword(string userQualifier);

        /// <summary>
        /// ChangePassword
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="oldPassword">oldPassword</param>
        /// <param name="newPassword">newPassword</param>
        /// <returns>UserProfileEntity</returns>
        UserProfileEntity ChangePassword(long userProfileId, string oldPassword, string newPassword);

        /// <summary>
        /// UpdateMobileNumber
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="userMobileNumber">userMobileNumber</param>
        /// <returns>UserProfileEntity</returns>
        UserProfileEntity UpdateMobileNumber(long userProfileId, string userMobileNumber);

        /// <summary>
        /// ManageUserProfile
        /// </summary>
        /// <param name="userProfileEntity">The user profile entity.</param>
        /// <returns>
        /// UserProfileEntity
        /// </returns>
        UserProfileEntity ManageUserProfile(UserProfileEntity userProfileEntity);

        /// <summary>
        /// ManageDealerProfile
        /// </summary>
        /// <param name="dealerProfileEntity">The dealer profile entity.</param>
        /// <returns>
        /// UserProfileEntity
        /// </returns>
        UserProfileEntity ManageDealerProfile(DealerProfileEntity dealerProfileEntity);
    }
}
