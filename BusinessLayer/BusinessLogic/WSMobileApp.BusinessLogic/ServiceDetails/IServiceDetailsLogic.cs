using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.BusinessLogic.ServiceDetails
{
    public interface IServiceDetailsLogic
    {
        /// <summary>
        /// Manages the service request.
        /// </summary>
        /// <param name="serviceRequestEntity">The service request entity.</param>
        /// <returns></returns>
        ServiceRequestCollection ManageServiceRequest(ServiceRequestEntity serviceRequestEntity);

        /// <summary>
        /// Gets the user service history.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        UserServiceHistoryEntity GetUserServiceHistory(long userProfileId);

        /// <summary>
        /// Cancels the service request.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        ServiceRequestCollection CancelServiceRequest(long serviceRequestId);

        /// <summary>
        /// Accepts the service request.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        ServiceRequestCollection AcceptServiceRequest(long serviceRequestId);

        /// <summary>
        /// Rejects the service request.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        ServiceRequestCollection RejectServiceRequest(long serviceRequestId);

        /// <summary>
        /// Updates the work in progress.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        ServiceRequestCollection UpdateWorkInProgress(long serviceRequestId);

        /// <summary>
        /// Updates the ready for delivery.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        ServiceRequestCollection UpdateReadyForDelivery(long serviceRequestId);

        /// <summary>
        /// Updates the delivered.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        ServiceRequestCollection UpdateDelivered(long serviceRequestId);

        /// <summary>
        /// Gets the service pending for approval by dealer profile identifier.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        DealerServiceEntity GetServicePendingForApprovalByDealerProfileId(long dealerProfileId);

        /// <summary>
        /// Gets the service pending for action by dealer profile identifier.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        DealerServiceEntity GetServicePendingForActionByDealerProfileId(long dealerProfileId);

        /// <summary>
        /// Gets the service pending for approval by dealer profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        DealerServiceEntity GetServicePendingForApprovalByUserProfileId(long userProfileId);

        /// <summary>
        /// Gets the service pending for action by dealer profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        DealerServiceEntity GetServicePendingForActionByUserProfileId(long userProfileId);

        /// <summary>
        /// Gets the active services by user profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        ServiceRequestCollection GetActiveServicesByUserProfileId(long userProfileId);

        /// <summary>
        /// Cancels the service request by dealer.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <param name="cancelReason">The cancel reason.</param>
        /// <returns></returns>
        ServiceRequestCollection CancelServiceRequestByDealer(long serviceRequestId, string cancelReason);

        /// <summary>
        /// Gets the dealer service history.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        ServiceRequestCollection GetDealerServiceHistory(long dealerProfileId);
    }
}
