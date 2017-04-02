using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.ServiceModel;
using WSMobileApp.BusinessLogic.AttachmentDetails;
using WSMobileApp.BusinessLogic.CarDetails;
using WSMobileApp.BusinessLogic.ServiceDetails;
using WSMobileApp.BusinessLogic.UserProfile;
using WSMobileApp.Common.CarDetails;
using WSMobileApp.Common.DealerProfile;
using WSMobileApp.Common.UserProfile;
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApplication.BusinessService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class WagonStationService : IWagonStationService
    {
        #region UserLogin / User Registration

        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="userLoginEntity"></param>
        /// <returns>
        /// UserProfileEntity
        /// </returns>
        public UserProfileEntity UserLogin(UserLoginEntity userLoginEntity)
        {
            return InitializeUserProfileLogic.UserLogin(userLoginEntity.UserQualifier, userLoginEntity.UserPassword, userLoginEntity.UserTypeId, userLoginEntity.DeviceId,string.Empty);
        }

        /// <summary>
        /// ValidateOneTimePassword
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <param name="userPassword">userPassword</param>
        /// <param name="userTypeId">userTypeId</param>
        /// <returns>UserProfileEntity</returns>
        public UserProfileEntity ValidateOneTimePassword(string userQualifier, string userPassword, string userTypeId)
        {
            return InitializeUserProfileLogic.ValidateOneTimePassword(userQualifier, userPassword, Convert.ToInt32(userTypeId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Checks the one time password.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="oneTimePassword">The one time password.</param>
        /// <returns></returns>
        public UserProfileEntity CheckOneTimePassword(string userProfileId, string oneTimePassword)
        {
            return InitializeUserProfileLogic.CheckOneTimePassword(Convert.ToInt64(userProfileId, CultureInfo.InvariantCulture), oneTimePassword);
        }

        /// <summary>
        /// ResendOneTimePassword
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <param name="userPassword">userPassword</param>
        /// <param name="userTypeId">userTypeId</param>
        /// <returns>UserProfileEntity</returns>
        public UserProfileEntity ResendOneTimePassword(string userQualifier, string userPassword, string userTypeId)
        {
            return InitializeUserProfileLogic.ResendOneTimePassword(userQualifier, userPassword, Convert.ToInt32(userTypeId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// ForgotPassword
        /// </summary>
        /// <param name="userQualifier">userQualifier</param>
        /// <returns>UserProfileEntity</returns>
        public UserProfileEntity ForgotPassword(string userQualifier)
        {
            return InitializeUserProfileLogic.ForgotPassword(userQualifier);
        }

        #endregion

        #region User Profile

        /// <summary>
        /// ChangePassword
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="oldPassword">oldPassword</param>
        /// <param name="newPassword">newPassword</param>
        /// <returns>UserProfileEntity</returns>
        public UserProfileEntity ChangePassword(string userProfileId, string oldPassword, string newPassword)
        {
            return InitializeUserProfileLogic.ChangePassword(Convert.ToInt64(userProfileId, CultureInfo.InvariantCulture), oldPassword, newPassword);
        }

        /// <summary>
        /// UpdateMobileNumber
        /// </summary>
        /// <param name="userProfileEntity">The user profile entity.</param>
        /// <returns>
        /// UserProfileEntity
        /// </returns>
        public UserProfileEntity UpdateMobileNumber(string userProfileId, string userMobileNumber)
        {
            return InitializeUserProfileLogic.UpdateMobileNumber(Convert.ToInt64(userProfileId,CultureInfo.InvariantCulture),userMobileNumber);
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
            return InitializeUserProfileLogic.ManageUserProfile(userProfileEntity);
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
            return InitializeUserProfileLogic.ManageDealerProfile(dealerProfileEntity);
        }



        /// <summary>
        /// Manages the profile picture.
        /// </summary>
        /// <param name="attachmentEntity">The attachment entity.</param>
        /// <returns></returns>
        public AttachmentEntity ManageProfilePicture(AttachmentEntity attachmentEntity)
        {
            return InitializeAttachmentDetailsLogic.ManageProfilePicture(attachmentEntity);
        }

        /// <summary>
        /// Manages the profile picture stream.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        public string ManageProfilePictureStream(string fileName,Stream stream)
        {
            var profilePicturePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Attachments","ProfilePicture");
            return Path.Combine(ConfigurationManager.AppSettings["ProfilePictureFolder"], ConvertStreamToImage(fileName, stream, profilePicturePath));
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
            return InitializeAttachmentDetailsLogic.ManageShopPicture(attachmentEntity);
        }

        /// <summary>
        /// Manages the shop picture stream.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        public string ManageShopPictureStream(string fileName, Stream stream)
        {
            var shopPicturePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Attachments", "ShopPicture");
            return Path.Combine(ConfigurationManager.AppSettings["ShopPictureFolder"], ConvertStreamToImage(fileName, stream, shopPicturePath));
        }

        /// <summary>
        /// DeleteProfilePicture
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>AttachmentEntity</returns>
        public AttachmentEntity DeleteProfilePicture(string attachmentId)
        {
            return InitializeAttachmentDetailsLogic.DeleteProfilePicture(Convert.ToInt64(attachmentId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// DeleteShopPicture
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>AttachmentEntity</returns>
        public AttachmentEntity DeleteShopPicture(string attachmentId)
        {
            return InitializeAttachmentDetailsLogic.DeleteShopPicture(Convert.ToInt64(attachmentId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Delete Attachment By Id
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>AttachmentEntity</returns>
        public AttachmentEntity DeleteAttachmentById(string attachmentId)
        {
            return InitializeAttachmentDetailsLogic.DeleteAttachmentById(Convert.ToInt64(attachmentId, CultureInfo.InvariantCulture));
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
            return InitializeAttachmentDetailsLogic.ManageCarDetailsPicture(attachmentEntity);
        }

        /// <summary>
        /// Manages the car details picture stream.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        public string ManageCarDetailsPictureStream(string fileName, Stream stream)
        {
            var carPicturePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Attachments", "CarPicture");
            return Path.Combine(ConfigurationManager.AppSettings["CarPictureFolder"], ConvertStreamToImage(fileName, stream, carPicturePath));
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
            return InitializeAttachmentDetailsLogic.ManageServicePicture(attachmentEntity);
        }

        /// <summary>
        /// Manages the service picture stream.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        public string ManageServicePictureStream(string fileName, Stream stream)
        {
            var servicePicturePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Attachments", "ServicePicture");
            return Path.Combine(ConfigurationManager.AppSettings["ServicePictureFolder"], ConvertStreamToImage(fileName, stream, servicePicturePath));
        }

        #endregion

        #region Offer Details

        /// <summary>
        /// DeleteOfferDetails
        /// </summary>
        /// <param name="offerDetailsId">offerDetailsId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>OfferDetailsCollection</returns>
        public OfferDetailsCollection DeleteOfferDetails(string offerDetailsId, string userProfileId)
        {
            return InitializeOfferDetailsLogic.DeleteOfferDetails(Convert.ToInt64(offerDetailsId, CultureInfo.InvariantCulture), Convert.ToInt64(userProfileId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// GetOfferDetailsByDealerProfileId
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <param name="currentDate">The current date.</param>
        /// <returns>
        /// OfferDetailsCollection
        /// </returns>
        public OfferDetailsCollection GetOfferDetailsByDealerProfileId(string dealerProfileId,string currentDate)
        {
            return InitializeOfferDetailsLogic.GetOfferDetailsByDealerProfileId(Convert.ToInt64(dealerProfileId, CultureInfo.InvariantCulture),Convert.ToDateTime(currentDate,CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// GetOfferDetailsById
        /// </summary>
        /// <param name="offerDetailsId">offerDetailsId</param>
        /// <returns>OfferDetailsEntity</returns>
        public OfferDetailsEntity GetOfferDetailsById(string offerDetailsId)
        {
            return InitializeOfferDetailsLogic.GetOfferDetailsById(Convert.ToInt64(offerDetailsId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// GetOfferDetailsByUserProfileId
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>OfferDetailsCollection</returns>
        public OfferDetailsCollection GetOfferDetailsByUserProfileId(string userProfileId)
        {
            return InitializeOfferDetailsLogic.GetOfferDetailsByUserProfileId(Convert.ToInt64(userProfileId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// ManageOfferDetails
        /// </summary>
        /// <param name="offerDetailsEntity">The offer details entity.</param>
        /// <returns>
        /// OfferDetailsCollection
        /// </returns>
        public OfferDetailsCollection ManageOfferDetails(OfferDetailsEntity offerDetailsEntity)
        {
            return InitializeOfferDetailsLogic.ManageOfferDetails(offerDetailsEntity);
        }

        #endregion

        #region Dealer Ratings

        /// <summary>
        /// CreateDealerRatings
        /// </summary>
        /// <param name="dealerRatingsEntity">The dealer ratings entity.</param>
        /// <returns>
        /// DealerRatingsCollection
        /// </returns>
        public DealerRatingsCollection CreateDealerRatings(DealerRatingsEntity dealerRatingsEntity)
        {
            return InitializeDealerRatingsLogic.CreateDealerRatings(dealerRatingsEntity);
        }

        /// <summary>
        /// DeleteDealerRatings
        /// </summary>
        /// <param name="dealerRatingsId">dealerRatingsId</param>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <returns>DealerRatingsCollection</returns>
        public DealerRatingsCollection DeleteDealerRatings(string dealerRatingsId, string dealerProfileId)
        {
            return InitializeDealerRatingsLogic.DeleteDealerRatings(Convert.ToInt64(dealerRatingsId, CultureInfo.InvariantCulture), Convert.ToInt64(dealerProfileId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// GetDealerRatingsByDealerProfileId
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <returns>DealerRatingsCollection</returns>
        public DealerRatingsCollection GetDealerRatingsByDealerProfileId(string dealerProfileId)
        {
            return InitializeDealerRatingsLogic.GetDealerRatingsByDealerProfileId(Convert.ToInt64(dealerProfileId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// GetAttachmentsById
        /// </summary>
        /// <param name="attachmentId">attachmentId</param>
        /// <returns>AttachmentEntity</returns>
        public AttachmentEntity GetAttachmentsById(string attachmentId)
        {
            return InitializeAttachmentDetailsLogic.GetAttachmentByAttachmentId(Convert.ToInt64(attachmentId, CultureInfo.InvariantCulture));
        }

        #endregion

        #region Car Details

        /// <summary>
        /// ManageCarDetails
        /// </summary>
        /// <param name="carDetailsEntity">The car details entity.</param>
        /// <returns>
        /// CarDetailsCollection
        /// </returns>
        public CarDetailsCollection ManageCarDetails(CarDetailsEntity carDetailsEntity)
        {
            return InitializeCarDetailsLogic.ManageCarDetails(carDetailsEntity);
        }

        /// <summary>
        /// DeleteCarDetailsById
        /// </summary>
        /// <param name="carDetailsId">carDetailsId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>CarDetailsCollection</returns>
        public CarDetailsCollection DeleteCarDetailsById(string carDetailsId, string userProfileId)
        {
            return InitializeCarDetailsLogic.DeleteCarDetailsById(Convert.ToInt64(carDetailsId, CultureInfo.InvariantCulture), Convert.ToInt64(userProfileId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// GetCarDetailsById
        /// </summary>
        /// <param name="carDetailsId">carDetailsId</param>
        /// <returns>CarDetailsEntity</returns>
        public CarDetailsEntity GetCarDetailsById(string carDetailsId)
        {
            return InitializeCarDetailsLogic.GetCarDetailsById(Convert.ToInt64(carDetailsId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// GetCarDetailsByUserProfileId
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>CarDetailsCollection</returns>
        public CarDetailsCollection GetCarDetailsByUserProfileId(string userProfileId)
        {
            return InitializeCarDetailsLogic.GetCarDetailsByUserProfileId(Convert.ToInt64(userProfileId, CultureInfo.InvariantCulture));
        }

        #endregion

        #region Dealer Profile

        /// <summary>
        /// UserLandingPageDetailsByBusinessType
        /// </summary>
        /// <param name="currentLatitude">currentLatitude</param>
        /// <param name="currentLongitude">currentLongitude</param>
        /// <param name="currentDate">currentDate</param>
        /// <returns>UserProfileCollection</returns>
        public DealerProfileCollection UserLandingPageDetails(string currentLatitude, string currentLongitude, string currentDate)
        {
            return InitializeDealerProfileLogic.UserLandingPageDetails(Convert.ToDecimal(currentLatitude.Replace("$$", "."), CultureInfo.InvariantCulture), Convert.ToDecimal(currentLongitude.Replace("$$", "."), CultureInfo.InvariantCulture), Convert.ToDateTime(currentDate, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// UserLandingPageDetailsByBusinessType
        /// </summary>
        /// <param name="currentLatitude">currentLatitude</param>
        /// <param name="currentLongitude">currentLongitude</param>
        /// <param name="currentDate">currentDate</param>
        /// <param name="businessTypeId">businessTypeId</param>
        /// <returns>UserProfileCollection</returns>
        public DealerProfileCollection UserLandingPageDetailsByBusinessType(string currentLatitude, string currentLongitude, string currentDate, string businessTypeId)
        {
            return InitializeDealerProfileLogic.UserLandingPageDetailsByBusinessType(Convert.ToDecimal(currentLatitude.Replace("$$", "."), CultureInfo.InvariantCulture), Convert.ToDecimal(currentLongitude.Replace("$$", "."), CultureInfo.InvariantCulture), Convert.ToDateTime(currentDate, CultureInfo.InvariantCulture), Convert.ToInt32(businessTypeId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// GetDealerProfileById
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <param name="currentDate">currentDate</param>
        /// <returns>UserProfileCollection</returns>
        public DealerProfileCollection GetDealerProfileById(string dealerProfileId, string currentDate)
        {
            return InitializeDealerProfileLogic.GetDealerProfileById(Convert.ToInt64(dealerProfileId, CultureInfo.InvariantCulture), Convert.ToDateTime(currentDate, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// SortDealerDetailsByDistance
        /// </summary>
        /// <param name="currentLatitude">currentLatitude</param>
        /// <param name="currentLongitude">currentLongitude</param>
        /// <param name="currentDate">currentDate</param>
        /// <returns>UserProfileCollection</returns>
        public DealerProfileCollection SortDealerDetailsByDistance(string currentLatitude, string currentLongitude, string currentDate)
        {
            return InitializeDealerProfileLogic.SortDealerDetailsByDistance(Convert.ToDecimal(currentLatitude.Replace("$$", "."), CultureInfo.InvariantCulture), Convert.ToDecimal(currentLongitude.Replace("$$", "."), CultureInfo.InvariantCulture), Convert.ToDateTime(currentDate, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// SortDealerDetailsByRatings
        /// </summary>
        /// <param name="currentDate">currentDate</param>
        /// <returns>UserProfileCollection</returns>
        public DealerProfileCollection SortDealerDetailsByRatings(string currentDate)
        {
            return InitializeDealerProfileLogic.SortDealerDetailsByRatings(Convert.ToDateTime(currentDate, CultureInfo.InvariantCulture));
        }


        #endregion

        #region Service Request

        /// <summary>
        /// Manages the service request.
        /// </summary>
        /// <param name="serviceRequest">The service request.</param>
        /// <returns></returns>
        public ServiceRequestCollection ManageServiceRequest(ServiceRequestEntity serviceRequest)
        {
            return InitializeServiceDetailsLogic.ManageServiceRequest(serviceRequest);
        }

        /// <summary>
        /// Gets the user service history.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        public UserServiceHistoryEntity GetUserServiceHistory(string userProfileId)
        {
            return InitializeServiceDetailsLogic.GetUserServiceHistory(Convert.ToInt64(userProfileId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Cancels the service request.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection CancelServiceRequest(string serviceRequestId)
        {
            return InitializeServiceDetailsLogic.CancelServiceRequest(Convert.ToInt64(serviceRequestId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Accepts the service request.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection AcceptServiceRequest(string serviceRequestId)
        {
            return InitializeServiceDetailsLogic.AcceptServiceRequest(Convert.ToInt64(serviceRequestId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Rejects the service request.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection RejectServiceRequest(string serviceRequestId)
        {
            return InitializeServiceDetailsLogic.RejectServiceRequest(Convert.ToInt64(serviceRequestId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Updates the work in progress.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection UpdateWorkInProgress(string serviceRequestId)
        {
            return InitializeServiceDetailsLogic.UpdateWorkInProgress(Convert.ToInt64(serviceRequestId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Updates the ready for delivery.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection UpdateReadyForDelivery(string serviceRequestId)
        {
            return InitializeServiceDetailsLogic.UpdateReadyForDelivery(Convert.ToInt64(serviceRequestId, CultureInfo.InvariantCulture));
        }


        /// <summary>
        /// Gets the service pending for approval by dealer profile identifier.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        public DealerServiceEntity GetServicePendingForApprovalByDealerProfileId(string dealerProfileId)
        {
            return InitializeServiceDetailsLogic.GetServicePendingForApprovalByDealerProfileId(Convert.ToInt64(dealerProfileId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Gets the service pending for action by dealer profile identifier.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        public DealerServiceEntity GetServicePendingForActionByDealerProfileId(string dealerProfileId)
        {
            return InitializeServiceDetailsLogic.GetServicePendingForActionByDealerProfileId(Convert.ToInt64(dealerProfileId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Gets the service pending for approval by dealer profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        public DealerServiceEntity GetServicePendingForApprovalByUserProfileId(string userProfileId)
        {
            return InitializeServiceDetailsLogic.GetServicePendingForApprovalByUserProfileId(Convert.ToInt64(userProfileId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Gets the service pending for action by dealer profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        public DealerServiceEntity GetServicePendingForActionByUserProfileId(string userProfileId)
        {
            return InitializeServiceDetailsLogic.GetServicePendingForActionByUserProfileId(Convert.ToInt64(userProfileId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Gets the active services by user profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection GetActiveServicesByUserProfileId(string userProfileId)
        {
            return InitializeServiceDetailsLogic.GetActiveServicesByUserProfileId(Convert.ToInt64(userProfileId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Cancels the service request by dealer.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <param name="cancelReason">The cancel reason.</param>
        /// <returns></returns>
        public ServiceRequestCollection CancelServiceRequestByDealer(string serviceRequestId, string cancelReason)
        {
            return InitializeServiceDetailsLogic.CancelServiceRequestByDealer(Convert.ToInt64(serviceRequestId,CultureInfo.InvariantCulture), cancelReason);
        }

        /// <summary>
        /// Gets the dealer service history.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection GetDealerServiceHistory(string dealerProfileId)
        {
            return InitializeServiceDetailsLogic.GetDealerServiceHistory(Convert.ToInt64(dealerProfileId, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Updates the delivered.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection UpdateDelivered(string serviceRequestId)
        {
            return InitializeServiceDetailsLogic.UpdateDelivered(Convert.ToInt64(serviceRequestId, CultureInfo.InvariantCulture));
        }


        /// <summary>
        /// Filters the details.
        /// </summary>
        /// <param name="filterDealerCriteria">The filter dealer criteria.</param>
        /// <returns></returns>
        public DealerProfileCollection FilterDetails(FilterDealerCriteria filterDealerCriteria)
        {
            return InitializeDealerProfileLogic.FilterDetails(filterDealerCriteria);
        }


        #endregion

        #region Initializers

        private IServiceDetailsLogic _initailizeServiceDetailsLogic;

        private IServiceDetailsLogic InitializeServiceDetailsLogic
        {
            get { return _initailizeServiceDetailsLogic ?? (_initailizeServiceDetailsLogic = new ServiceDetailsLogic()); }
        }

        /// <summary>
        /// _initializeDealerProfileLogic
        /// </summary>
        private IDealerProfileLogic _initializeDealerProfileLogic;

        /// <summary>
        /// InitializeDealerProfileLogic
        /// </summary>
        private IDealerProfileLogic InitializeDealerProfileLogic
        {
            get { return _initializeDealerProfileLogic ?? (_initializeDealerProfileLogic = new DealerProfileLogic()); }
        }

        /// <summary>
        /// _initializeDealerRatingsLogic
        /// </summary>
        private IDealerRatingsLogic _initializeDealerRatingsLogic;

        /// <summary>
        /// InitializeDealerRatingsLogic
        /// </summary>
        private IDealerRatingsLogic InitializeDealerRatingsLogic
        {
            get { return _initializeDealerRatingsLogic ?? (_initializeDealerRatingsLogic = new DealerRatingsLogic()); }
        }

        /// <summary>
        /// _initializeOfferDetailsLogic
        /// </summary>
        private IOfferDetailsLogic _initializeOfferDetailsLogic;

        /// <summary>
        /// InitializeOfferDetailsLogic
        /// </summary>
        private IOfferDetailsLogic InitializeOfferDetailsLogic
        {
            get { return _initializeOfferDetailsLogic ?? (_initializeOfferDetailsLogic = new OfferDetailsLogic()); }
        }

        /// <summary>
        /// _initailzieBusinessUserProfileLogic
        /// </summary>
        private IUserProfileLogic _initailzieBusinessUserProfileLogic;

        /// <summary>
        /// InitializeUserProfileLogic
        /// </summary>
        private IUserProfileLogic InitializeUserProfileLogic
        {
            get
            {
                return _initailzieBusinessUserProfileLogic ?? (_initailzieBusinessUserProfileLogic = new UserProfileLogic());
            }
        }

        /// <summary>
        /// _initializeAttachmentDetailsLogic
        /// </summary>
        private IAttachmentDetailsLogic _initializeAttachmentDetailsLogic;

        /// <summary>
        /// InitializeAttachmentDetailsLogic
        /// </summary>
        private IAttachmentDetailsLogic InitializeAttachmentDetailsLogic
        {
            get
            {
                return _initializeAttachmentDetailsLogic ?? (_initializeAttachmentDetailsLogic = new AttachmentDetailsLogic());
            }
        }

        /// <summary>
        /// _initializeCarDetailsLogic
        /// </summary>
        private ICarDetailsLogic _initializeCarDetailsLogic;

        /// <summary>
        /// InitializeCarDetailsLogic
        /// </summary>
        private ICarDetailsLogic InitializeCarDetailsLogic
        {
            get { return _initializeCarDetailsLogic ?? (_initializeCarDetailsLogic = new CarDetailsLogic()); }
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Converts the stream to image.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="stream">The stream.</param>
        /// <param name="filePath">The file path.</param>
        private static string ConvertStreamToImage(string fileName, Stream stream, string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            fileName = string.Format("{0}_{1}", DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss_tt"), fileName);

            var serviceHostingEnvironmentPath = Path.Combine(filePath, fileName);

            using (var fileStream = new FileStream(serviceHostingEnvironmentPath, FileMode.Create))
            {
                int readCount;
                var buffer = new byte[8192];
                while ((readCount = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    fileStream.Write(buffer, 0, readCount);
                }
            }

            return fileName;
        }

        #endregion
    }
}