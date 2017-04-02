using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApplication.BusinessService
{
    [ServiceContract]
    public interface IWagonStationService
    {
        #region User Login / User Registration

        /// <summary>
        /// Users the login.
        /// </summary>
        /// <param name="userLoginEntity">The user login entity.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/UserLogin")]
        UserProfileEntity UserLogin(UserLoginEntity userLoginEntity);

        /// <summary>
        /// Validates the one time password.
        /// </summary>
        /// <param name="userQualifier">The user qualifier.</param>
        /// <param name="userPassword">The user password.</param>
        /// <param name="userTypeId">The user type identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ValidateOneTimePassword/{userQualifier}/{userPassword}/{userTypeId}")]
        UserProfileEntity ValidateOneTimePassword(string userQualifier, string userPassword, string userTypeId);

        /// <summary>
        /// Resends the one time password.
        /// </summary>
        /// <param name="userQualifier">The user qualifier.</param>
        /// <param name="userPassword">The user password.</param>
        /// <param name="userTypeId">The user type identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ResendOneTimePassword/{userQualifier}/{userPassword}/{userTypeId}")]
        UserProfileEntity ResendOneTimePassword(string userQualifier, string userPassword, string userTypeId);

        /// <summary>
        /// Checks the one time password.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="oneTimePassword">The one time password.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/CheckOneTimePassword/{userProfileId}/{oneTimePassword}")]
        UserProfileEntity CheckOneTimePassword(string userProfileId, string oneTimePassword);

        /// <summary>
        /// Forgots the password.CheckOneTimePassword
        /// </summary>
        /// <param name="userQualifier">The user qualifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ForgotPassword/{userQualifier}")]
        UserProfileEntity ForgotPassword(string userQualifier);

        #endregion

        #region User Profile

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ChangePassword/{userProfileId}/{oldPassword}/{newPassword}")]
        UserProfileEntity ChangePassword(string userProfileId, string oldPassword, string newPassword);

        /// <summary>
        /// Updates the mobile number.
        /// </summary>
        /// <param name="userProfileEntity">The user profile entity.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/UpdateMobileNumber/{userProfileId}/{userMobileNumber}")]
        UserProfileEntity UpdateMobileNumber(string userProfileId,string userMobileNumber);

        /// <summary>
        /// Manages the user profile.
        /// </summary>
        /// <param name="userProfileEntity">The user profile entity.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ManageUserProfile")]
        UserProfileEntity ManageUserProfile(UserProfileEntity userProfileEntity);

        /// <summary>
        /// Manages the dealer profile.
        /// </summary>
        /// <param name="dealerProfileEntity">The dealer profile entity.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ManageDealerProfile")]
        UserProfileEntity ManageDealerProfile(DealerProfileEntity dealerProfileEntity);

        #endregion

        #region Offer Details

        /// <summary>
        /// Deletes the offer details.
        /// </summary>
        /// <param name="offerDetailsId">The offer details identifier.</param>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/DeleteOfferDetails/{offerDetailsId}/{userProfileId}")]
        OfferDetailsCollection DeleteOfferDetails(string offerDetailsId, string userProfileId);

        /// <summary>
        /// Gets the offer details by dealer profile identifier.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <param name="currentDate">The current date.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetOfferDetailsByDealerProfileId/{dealerProfileId}/{currentDate}")]
        OfferDetailsCollection GetOfferDetailsByDealerProfileId(string dealerProfileId,string currentDate);

        /// <summary>
        /// Gets the offer details by identifier.
        /// </summary>
        /// <param name="offerDetailsId">The offer details identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetOfferDetailsById/{offerDetailsId}")]
        OfferDetailsEntity GetOfferDetailsById(string offerDetailsId);

        /// <summary>
        /// Gets the offer details by user profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetOfferDetailsByUserProfileId/{userProfileId}")]
        OfferDetailsCollection GetOfferDetailsByUserProfileId(string userProfileId);

        /// <summary>
        /// Manages the offer details.
        /// </summary>
        /// <param name="offerDetailsEntity">The offer details entity.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ManageOfferDetails")]
        OfferDetailsCollection ManageOfferDetails(OfferDetailsEntity offerDetailsEntity);


        #endregion

        #region Dealer Ratings

        /// <summary>
        /// Creates the dealer ratings.
        /// </summary>
        /// <param name="dealerRatingsEntity">The dealer ratings entity.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/CreateDealerRatings")]
        DealerRatingsCollection CreateDealerRatings(DealerRatingsEntity dealerRatingsEntity);

        /// <summary>
        /// Deletes the dealer ratings.
        /// </summary>
        /// <param name="dealerRatingsId">The dealer ratings identifier.</param>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/DeleteDealerRatings/{dealerRatingsId}/{dealerProfileId}")]
        DealerRatingsCollection DeleteDealerRatings(string dealerRatingsId, string dealerProfileId);

        /// <summary>
        /// Gets the dealer ratings by dealer profile identifier.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetDealerRatingsByDealerProfileId/{dealerProfileId}")]
        DealerRatingsCollection GetDealerRatingsByDealerProfileId(string dealerProfileId);

        #endregion

        #region Attachments

        /// <summary>
        /// Gets the attachments by identifier.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetAttachmentsById/{attachmentId}")]
        AttachmentEntity GetAttachmentsById(string attachmentId);

        /// <summary>
        /// Manages the profile picture.
        /// </summary>
        /// <param name="attachmentEntity">The attachment entity.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json ,ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ManageProfilePicture")]
        AttachmentEntity ManageProfilePicture(AttachmentEntity attachmentEntity);

        /// <summary>
        /// Manages the profile picture stream.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ManageProfilePictureStream?fileName={fileName}")]
        string ManageProfilePictureStream(string fileName,Stream stream);

        /// <summary>
        /// Manages the shop picture.
        /// </summary>
        /// <param name="attachmentEntity">The attachment entity.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ManageShopPicture")]
        AttachmentEntity ManageShopPicture(AttachmentEntity attachmentEntity);


        /// <summary>
        /// Manages the shop picture stream.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ManageShopPictureStream?fileName={fileName}")]
        string ManageShopPictureStream(string fileName, Stream stream);

        /// <summary>
        /// Deletes the profile picture.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/DeleteProfilePicture/{attachmentId}")]
        AttachmentEntity DeleteProfilePicture(string attachmentId);

        /// <summary>
        /// Deletes the shop picture.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/DeleteShopPicture/{attachmentId}")]
        AttachmentEntity DeleteShopPicture(string attachmentId);

        /// <summary>
        /// Deletes the attachment by identifier.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/DeleteAttachmentById/{attachmentId}")]
        AttachmentEntity DeleteAttachmentById(string attachmentId);

        /// <summary>
        /// Manages the car details picture.
        /// </summary>
        /// <param name="attachmentEntity">The attachment entity.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ManageCarDetailsPicture")]
        AttachmentEntity ManageCarDetailsPicture(AttachmentEntity attachmentEntity);

        /// <summary>
        /// Manages the car details picture stream.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ManageCarDetailsPictureStream?fileName={fileName}")]
        string ManageCarDetailsPictureStream(string fileName, Stream stream);

        /// <summary>
        /// Manages the service picture.
        /// </summary>
        /// <param name="attachmentEntity">The attachment entity.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ManageServicePicture")]
        AttachmentEntity ManageServicePicture(AttachmentEntity attachmentEntity);

        /// <summary>
        /// Manages the service picture stream.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ManageServicePictureStream?fileName={fileName}")]
        string ManageServicePictureStream(string fileName, Stream stream);

        #endregion

        #region Car Details

        /// <summary>
        /// Manages the car details.
        /// </summary>
        /// <param name="carDetailsEntity">The car details entity.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ManageCarDetails")]
        CarDetailsCollection ManageCarDetails(CarDetailsEntity carDetailsEntity);

        /// <summary>
        /// Deletes the car details by identifier.
        /// </summary>
        /// <param name="carDetailsId">The car details identifier.</param>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/DeleteCarDetailsById/{carDetailsId}/{userProfileId}")]
        CarDetailsCollection DeleteCarDetailsById(string carDetailsId, string userProfileId);

        /// <summary>
        /// Gets the car details by identifier.
        /// </summary>
        /// <param name="carDetailsId">The car details identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetCarDetailsById/{carDetailsId}")]
        CarDetailsEntity GetCarDetailsById(string carDetailsId);

        /// <summary>
        /// Gets the car details by user profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetCarDetailsByUserProfileId/{userProfileId}")]
        CarDetailsCollection GetCarDetailsByUserProfileId(string userProfileId);

        #endregion

        #region Dealer Profile

        /// <summary>
        /// Users the landing page details.
        /// </summary>
        /// <param name="currentLatitude">The current latitude.</param>
        /// <param name="currentLongitude">The current longitude.</param>
        /// <param name="currentDate">The current date.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/UserLandingPageDetails/{currentLatitude}/{currentLongitude}/{currentDate}")]
        DealerProfileCollection UserLandingPageDetails(string currentLatitude, string currentLongitude, string currentDate);

        /// <summary>
        /// Users the type of the landing page details by business.
        /// </summary>
        /// <param name="currentLatitude">The current latitude.</param>
        /// <param name="currentLongitude">The current longitude.</param>
        /// <param name="currentDate">The current date.</param>
        /// <param name="businessTypeId">The business type identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/UserLandingPageDetailsByBusinessType/{currentLatitude}/{currentLongitude}/{currentDate}/{businessTypeId}")]
        DealerProfileCollection UserLandingPageDetailsByBusinessType(string currentLatitude, string currentLongitude, string currentDate, string businessTypeId);

        /// <summary>
        /// Gets the dealer profile by identifier.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <param name="currentDate">The current date.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetDealerProfileById/{dealerProfileId}/{currentDate}")]
        DealerProfileCollection GetDealerProfileById(string dealerProfileId, string currentDate);

        /// <summary>
        /// Sorts the dealer details by distance.
        /// </summary>
        /// <param name="currentLatitude">The current latitude.</param>
        /// <param name="currentLongitude">The current longitude.</param>
        /// <param name="currentDate">The current date.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/SortDealerDetailsByDistance/{currentLatitude}/{currentLongitude}/{currentDate}")]
        DealerProfileCollection SortDealerDetailsByDistance(string currentLatitude, string currentLongitude, string currentDate);

        /// <summary>
        /// Sorts the dealer details by ratings.
        /// </summary>
        /// <param name="currentDate">The current date.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/SortDealerDetailsByRatings/{currentDate}")]
        DealerProfileCollection SortDealerDetailsByRatings(string currentDate);

        #endregion

        #region Servicer Request

        /// <summary>
        /// Manages the service request.
        /// </summary>
        /// <param name="serviceRequest">The service request.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST",RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json,UriTemplate = "/ManageServiceRequest")]
        ServiceRequestCollection ManageServiceRequest(ServiceRequestEntity serviceRequest);


        /// <summary>
        /// Gets the user service history.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetUserServiceHistory/{userProfileId}")]
        UserServiceHistoryEntity GetUserServiceHistory(string userProfileId);


        /// <summary>
        /// Cancels the service request.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/CancelServiceRequest/{serviceRequestId}")]
        ServiceRequestCollection CancelServiceRequest(string serviceRequestId);

        /// <summary>
        /// Accepts the service request.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/AcceptServiceRequest/{serviceRequestId}")]
        ServiceRequestCollection AcceptServiceRequest(string serviceRequestId);

        /// <summary>
        /// Rejects the service request.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/RejectServiceRequest/{serviceRequestId}")]
        ServiceRequestCollection RejectServiceRequest(string serviceRequestId);

        /// <summary>
        /// Updates the work in progress.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/UpdateWorkInProgress/{serviceRequestId}")]
        ServiceRequestCollection UpdateWorkInProgress(string serviceRequestId);

        /// <summary>
        /// Updates the ready for delivery.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/UpdateReadyForDelivery/{serviceRequestId}")]
        ServiceRequestCollection UpdateReadyForDelivery(string serviceRequestId);

        /// <summary>
        /// Updates the delivered.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/UpdateDelivered/{serviceRequestId}")]
        ServiceRequestCollection UpdateDelivered(string serviceRequestId);

        /// <summary>
        /// Gets the service pending for approval by dealer profile identifier.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetServicePendingForApprovalByDealerProfileId/{dealerProfileId}")]
        DealerServiceEntity GetServicePendingForApprovalByDealerProfileId(string dealerProfileId);

        /// <summary>
        /// Gets the service pending for action by dealer profile identifier.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetServicePendingForActionByDealerProfileId/{dealerProfileId}")]
        DealerServiceEntity GetServicePendingForActionByDealerProfileId(string dealerProfileId);

        /// <summary>
        /// Gets the service pending for approval by dealer profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetServicePendingForApprovalByUserProfileId/{userProfileId}")]
        DealerServiceEntity GetServicePendingForApprovalByUserProfileId(string userProfileId);

        /// <summary>
        /// Gets the service pending for action by dealer profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetServicePendingForActionByUserProfileId/{userProfileId}")]
        DealerServiceEntity GetServicePendingForActionByUserProfileId(string userProfileId);

        /// <summary>
        /// Gets the active services by user profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetActiveServicesByUserProfileId/{userProfileId}")]
        ServiceRequestCollection GetActiveServicesByUserProfileId(string userProfileId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/CancelServiceRequestByDealer/{serviceRequestId}/{cancelReason}")]
        ServiceRequestCollection CancelServiceRequestByDealer(string serviceRequestId, string cancelReason);

        /// <summary>
        /// Gets the dealer service history.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetDealerServiceHistory/{dealerProfileId}")]
        ServiceRequestCollection GetDealerServiceHistory(string dealerProfileId);

        /// <summary>
        /// Filters the details.
        /// </summary>
        /// <param name="serviceRequest">The service request.</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/FilterDetails")]
        DealerProfileCollection FilterDetails(FilterDealerCriteria serviceRequest);

        #endregion
    }
}
