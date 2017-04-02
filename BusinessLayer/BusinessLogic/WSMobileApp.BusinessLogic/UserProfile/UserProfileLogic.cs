using System;
using System.Data;
using System.Globalization;
using System.Linq;
using WSMobileApp.BusinessLogic.EntityConverter.DataTableToEntity;
using WSMobileApp.BusinessLogic.EntityConverter.Resource;
using WSMobileApp.BusinessModel.Entities;
using WSMobileApp.Common.DataSecurity;
using WSMobileApp.Common.GeoCodeGenerator;
using WSMobileApp.Common.PasswordGenerator;
using WSMobileApp.Common.UserProfile;
using WSMobileApp.DataProcess.UserProfile;
using WSMobileApp.Notification.SmsNotification;

namespace WSMobileApp.BusinessLogic.UserProfile
{
    public sealed class UserProfileLogic : IUserProfileLogic
    {
        /// <summary>
        /// UserLogin
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <param name="userPassword">userPassword</param>
        /// <param name="userTypeId">userTypeId</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="senderId">The sender identifier.</param>
        /// <returns>
        /// UserProfileEntity
        /// </returns>
        public UserProfileEntity UserLogin(string userQualifier, string userPassword, int userTypeId, string deviceId, string senderId)
        {
            try
            {
                return ConvertDataSetToUserProfileEntity(InitializeUserProfileDataProcess.UserLogin(userQualifier, EncryptDecrypt.Encrypt(userPassword), userTypeId, deviceId, senderId));
            }
            catch (Exception exception)
            {
                return ConvertExceptionToUserProfileEntity(exception);
            }
        }

        /// <summary>
        /// ValidateOneTimePassword
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <param name="userPassword">userPassword</param>
        /// <param name="userTypeId">userTypeId</param>
        /// <returns>UserProfileEntity</returns>
        public UserProfileEntity ValidateOneTimePassword(string userQualifier, string userPassword, int userTypeId)
        {
            try
            {
                if (IsMobileNumberAlreadyRegistered(userQualifier))
                {
                    return new UserProfileEntity { IsSuccess = false, Message = EntityConverterResource.SQL_VALIDATION_ERROR_002 };
                }

                var oneTimePassword = OneTimePasswordGenerator.GenerateOneTimePassword();

                var isSmsSent = InitializeSmsNotifier.NotifiyOneTimePassword(userQualifier, oneTimePassword);
                var response = new UserProfileEntity();

                if (isSmsSent)
                {
                    response = ConvertDataSetToUserProfileEntity(InitializeUserProfileDataProcess.ValidateOneTimePassword(userQualifier, EncryptDecrypt.Encrypt(userPassword), EncryptDecrypt.Encrypt(oneTimePassword), userTypeId));
                }
                return response == null ? null : ConvertMessageResponseToUserProfileEntity(isSmsSent, response);
            }
            catch (Exception exception)
            {
                return ConvertExceptionToUserProfileEntity(exception);
            }
        }

        /// <summary>
        /// Checks the one time password.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="oneTimePassword">The one time password.</param>
        /// <returns></returns>
        public UserProfileEntity CheckOneTimePassword(long userProfileId, string oneTimePassword)
        {
            try
            {
                return ConvertDataSetToUserProfileEntity(InitializeUserProfileDataProcess.CheckOneTimePassword(userProfileId, EncryptDecrypt.Encrypt(oneTimePassword)));
            }
            catch (Exception exception)
            {
                return ConvertExceptionToUserProfileEntity(exception);
            }
        }

        /// <summary>
        /// ResendOneTimePassword
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <param name="userPassword">userPassword</param>
        /// <param name="userTypeId">userTypeId</param>
        /// <returns>UserProfileEntity</returns>
        public UserProfileEntity ResendOneTimePassword(string userQualifier, string userPassword, int userTypeId)
        {
            try
            {
                var oneTimePassword = OneTimePasswordGenerator.GenerateOneTimePassword();
                var isSmsSent = InitializeSmsNotifier.NotifiyOneTimePassword(userQualifier, oneTimePassword);
                var response = new UserProfileEntity();

                if (isSmsSent)
                {
                    response = ConvertDataSetToUserProfileEntity(InitializeUserProfileDataProcess.ResendOneTimePassword(userQualifier, EncryptDecrypt.Encrypt(userPassword), EncryptDecrypt.Encrypt(oneTimePassword), userTypeId));
                }
                return response == null ? null : ConvertMessageResponseToUserProfileEntity(isSmsSent, response);
            }
            catch (Exception exception)
            {
                return ConvertExceptionToUserProfileEntity(exception);
            }
        }

        /// <summary>
        /// ForgotPassword
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <returns>UserProfileEntity</returns>
        public UserProfileEntity ForgotPassword(string userQualifier)
        {
            try
            {

                if (!IsMobileNumberAlreadyRegistered(userQualifier))
                {
                    return new UserProfileEntity { IsSuccess = false, Message = EntityConverterResource.SQL_VALIDATION_ERROR_005 };
                }

                var newPassword = GenrateRandomPassword.RandomPassword();
                var isSmsSent = InitializeSmsNotifier.NotifyForgotPassword(userQualifier, newPassword);
                var response = new UserProfileEntity();

                if (isSmsSent)
                {
                    response = ConvertDataSetToUserProfileEntity(InitializeUserProfileDataProcess.ForgotPassword(userQualifier, EncryptDecrypt.Encrypt(newPassword)));
                }
                return response == null ? null : ConvertMessageResponseToUserProfileEntity(isSmsSent, response);
            }
            catch (Exception exception)
            {
                return ConvertExceptionToUserProfileEntity(exception);
            }
        }

        /// <summary>
        /// ChangePassword
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="oldPassword">oldPassword</param>
        /// <param name="newPassword">newPassword</param>
        /// <returns>UserProfileEntity</returns>
        public UserProfileEntity ChangePassword(long userProfileId, string oldPassword, string newPassword)
        {
            try
            {
                return ConvertDataSetToUserProfileEntity(InitializeUserProfileDataProcess.ChangePassword(userProfileId, EncryptDecrypt.Encrypt(oldPassword), EncryptDecrypt.Encrypt(newPassword)));
            }
            catch (Exception exception)
            {
                return ConvertExceptionToUserProfileEntity(exception);
            }
        }

        /// <summary>
        /// UpdateMobileNumber
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="userMobileNumber">userMobileNumber</param>
        /// <returns>UserProfileEntity</returns>
        public UserProfileEntity UpdateMobileNumber(long userProfileId, string userMobileNumber)
        {
            try
            {
                if (IsMobileNumberAlreadyRegistered(userMobileNumber))
                {
                    return new UserProfileEntity { IsSuccess = false, Message = EntityConverterResource.SQL_VALIDATION_ERROR_002 };
                }

                var oneTimePassword = OneTimePasswordGenerator.GenerateOneTimePassword();
                var isSmsSent = InitializeSmsNotifier.NotifiyOneTimePassword(userMobileNumber, oneTimePassword);
                var response = new UserProfileEntity();

                if (isSmsSent)
                {
                    response = ConvertDataSetToUserProfileEntity(InitializeUserProfileDataProcess.UpdateMobileNumber(userProfileId, userMobileNumber, EncryptDecrypt.Encrypt(oneTimePassword)));
                }
                return response == null ? null : ConvertMessageResponseToUserProfileEntity(isSmsSent, response);
            }
            catch (Exception exception)
            {
                return ConvertExceptionToUserProfileEntity(exception);
            }
        }

        /// <summary>
        /// ManageUserProfile
        /// </summary>
        /// <param name="userProfileEntity">The user profile entity.</param>
        /// <returns>
        /// UserProfileEntity
        /// </returns>
        public UserProfileEntity ManageUserProfile(UserProfileEntity userProfileEntity)
        {
            try
            {
                return ConvertDataSetToUserProfileEntity(InitializeUserProfileDataProcess.ManageUserProfile(userProfileEntity.UserProfileId, userProfileEntity.UserName, userProfileEntity.UserEmail, userProfileEntity.IsPrmotionalEmailRequired, userProfileEntity.DeviceId));
            }
            catch (Exception exception)
            {
                return ConvertExceptionToUserProfileEntity(exception);
            }
        }

        /// <summary>
        /// ManageDealerProfile
        /// </summary>
        /// <param name="dealerProfileEntity">The dealer profile entity.</param>
        /// <returns>
        /// UserProfileEntity
        /// </returns>
        public UserProfileEntity ManageDealerProfile(DealerProfileEntity dealerProfileEntity)
        {
            try
            {

                if (dealerProfileEntity.UserProfile == null)
                {
                    return null;
                }

                decimal latitude = 0;
                decimal longtitude = 0;
                var address = string.Format("{0} {1}", dealerProfileEntity.ShopAddress.Replace("||", "/"), dealerProfileEntity.PinCode).Trim();
                var latitudeGenerator = new GeoCoder().GeoCode(address.Replace(",", " "));
                if (latitudeGenerator != null)
                {
                    latitude = Convert.ToDecimal(latitudeGenerator.Latitude, CultureInfo.InvariantCulture);
                    longtitude = Convert.ToDecimal(latitudeGenerator.Longitude, CultureInfo.InvariantCulture);
                }



                return ConvertDataSetToUserProfileEntity(InitializeUserProfileDataProcess.ManageDealerProfile(dealerProfileEntity.DealerProfileId, dealerProfileEntity.UserProfile.UserProfileId, dealerProfileEntity.UserProfile.UserName, dealerProfileEntity.UserProfile.UserEmail, dealerProfileEntity.ShopName, dealerProfileEntity.ShopAddress, dealerProfileEntity.PinCode, latitude, longtitude, dealerProfileEntity.BusinessType.BusinessTypeId, dealerProfileEntity.BusinessNatureType.BusinessNatureTypeId, dealerProfileEntity.GoogleApiKey, dealerProfileEntity.IsPickupDropFacilityAvailable, dealerProfileEntity.AuthorizedDealershipName, dealerProfileEntity.UserProfile.DeviceId));
            }
            catch (Exception exception)
            {
                return ConvertExceptionToUserProfileEntity(exception);
            }
        }

        #region Initializers

        /// <summary>
        /// initialize user profile data process
        /// </summary>
        private IUserProfileDataProcess _initializeUserProfileDataProcess;

        /// <summary>
        /// initialize user profile data process
        /// </summary>
        private IUserProfileDataProcess InitializeUserProfileDataProcess
        {
            get
            {
                return _initializeUserProfileDataProcess ?? (_initializeUserProfileDataProcess = new UserProfileDataProcess());
            }
        }

        /// <summary>
        /// The _initialize user profile converter
        /// </summary>
        private UserProfileDataTableToEntityConverter _initializeUserProfileConverter;

        /// <summary>
        /// Gets the initialize user profile converter.
        /// </summary>
        /// <value>
        /// The initialize user profile converter.
        /// </value>
        private UserProfileDataTableToEntityConverter InitializeUserProfileConverter
        {
            get
            {
                return _initializeUserProfileConverter ?? (_initializeUserProfileConverter = new UserProfileDataTableToEntityConverter());
            }
        }

        private ISmsNotifier _initializeSmsNotifier;

        /// <summary>
        /// Gets the initialize SMS notifier.
        /// </summary>
        /// <value>
        /// The initialize SMS notifier.
        /// </value>
        private ISmsNotifier InitializeSmsNotifier
        {
            get { return _initializeSmsNotifier ?? (_initializeSmsNotifier = new SmsNotifier()); }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Converts the message response to user profile entity.
        /// </summary>
        /// <param name="isSmsSent">if set to <c>true</c> [is SMS sent].</param>
        /// <param name="userProfileEntity">The user profile entity.</param>
        /// <returns></returns>
        private static UserProfileEntity ConvertMessageResponseToUserProfileEntity(bool isSmsSent, UserProfileEntity userProfileEntity)
        {
            var response = userProfileEntity;
            if (!isSmsSent)
            {
                response.IsSuccess = false;
                response.Message = "Message sending failed";
                return response;
            }

            response.IsSuccess = true;
            response.Message = "Message sent successfully";

            return response;
        }

        /// <summary>
        /// Convert DataSet to UserProfileEntity 
        /// </summary>
        /// <param name="dataSet">dataSet</param>
        /// <returns>UserProfileEntity</returns>
        private static UserProfileEntity ConvertDataSetToUserProfileEntity(DataSet dataSet)
        {
            if (dataSet == null)
            {
                return null;
            }

            if (dataSet.Tables[0] == null)
            {
                return null;
            }

            var response = UserProfileDataTableToEntityConverter.ConvertDataTableToUserProfileEntity(dataSet.Tables[0]);
            if (response != null)
            {
                switch (response.UserTypeId)
                {
                    case 1:
                        response.CarDetails = CarDetailsDataTableToEntityConverter.ConvertDataTableToCarDetailsCollection(dataSet.Tables[1]);
                        break;
                    case 2:
                        response.DealerProfiles = DealerProfileDataTableToEntityConverter.ConvertDataTableToDealerProfileCollection(dataSet.Tables[1]);
                        response.BusinessTypes = BusinessTypeDataTableToEntityConverter.ConvertDataTableToBusinessTypeCollection(dataSet.Tables[2]);
                        response.BusinessNatureTypes = BusinessNatureTypeDataTableToEntityConverter.ConvertDataTableToBusinessTypeCollection(dataSet.Tables[3]);
                        if (response.DealerProfiles != null && response.DealerProfiles.Items != null && response.DealerProfiles.Items.Any())
                        {
                            foreach (var dealerProfileEntity in response.DealerProfiles.Items)
                            {
                                dealerProfileEntity.OfferDetails = OfferDetailsDataTableToEntityConverter.ConvertDataTableToOfferDetailsCollection(dataSet.Tables[4]);
                                dealerProfileEntity.DealerRatings = DealerRatingsDataTableToEntityConverter.ConvertDataTableToDealerRatingsCollection(dataSet.Tables[5]);
                            }
                        }
                        break;
                }
            }

            return response;
        }

        /// <summary>
        /// Convert Exception to User Profile Entity
        /// </summary>
        /// <param name="exception">exception</param>
        /// <returns>UserProfileEntity</returns>
        private static UserProfileEntity ConvertExceptionToUserProfileEntity(Exception exception)
        {
            switch (exception.Message)
            {
                case "SQL_VALIDATION_ERROR_001":
                    return new UserProfileEntity { IsSuccess = false, Message = EntityConverterResource.SQL_VALIDATION_ERROR_001 };
                case "SQL_VALIDATION_ERROR_002":
                    return new UserProfileEntity { IsSuccess = false, Message = EntityConverterResource.SQL_VALIDATION_ERROR_002 };
                case "SQL_VALIDATION_ERROR_003":
                    return new UserProfileEntity { IsSuccess = false, Message = EntityConverterResource.SQL_VALIDATION_ERROR_003 };
                case "SQL_VALIDATION_ERROR_004":
                    return new UserProfileEntity { IsSuccess = false, Message = EntityConverterResource.SQL_VALIDATION_ERROR_004 };
                case "SQL_VALIDATION_ERROR_005":
                    return new UserProfileEntity { IsSuccess = false, Message = EntityConverterResource.SQL_VALIDATION_ERROR_005 };
                case "SQL_VALIDATION_ERROR_006":
                    return new UserProfileEntity { IsSuccess = false, Message = EntityConverterResource.SQL_VALIDATION_ERROR_006 };
                case "SQL_VALIDATION_ERROR_007":
                    return new UserProfileEntity { IsSuccess = false, Message = EntityConverterResource.SQL_VALIDATION_ERROR_007 };
                default:
                    return new UserProfileEntity { IsSuccess = false, Message = exception.InnerException == null ? exception.Message : exception.InnerException.Message };
            }
        }

        /// <summary>
        /// Determines whether [is mobile number already registered] [the specified user qualifier].
        /// </summary>
        /// <param name="userQualifier">The user qualifier.</param>
        /// <returns>
        ///   <c>true</c> if [is mobile number already registered] [the specified user qualifier]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsMobileNumberAlreadyRegistered(string userQualifier)
        {
            var dataReader = InitializeUserProfileDataProcess.IsMobileNumberAlreadyRegistered(userQualifier);
            using (dataReader)
            {
                return dataReader.Read() && (dataReader["IsExists"] != DBNull.Value && Convert.ToBoolean(dataReader["IsExists"], CultureInfo.InvariantCulture));
            }

        }

        #endregion
    }
}
