
using System;
using System.Data;

namespace WSMobileApp.DataProcess.ServiceDetails
{
    public interface IServiceDetailsDataProcess
    {
        /// <summary>
        /// Manages the service request.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <param name="carDetailsId">The car details identifier.</param>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="appointmentDate">The appointment date.</param>
        /// <param name="appointmentTime">The appointment time.</param>
        /// <param name="appointmentRequestDate">The appointment request date.</param>
        /// <param name="isPickupDropAvailable">if set to <c>true</c> [is pickup drop available].</param>
        /// <param name="inspectionDescription">The inspection description.</param>
        /// <param name="periodicMaintenanceDescription">The periodic maintenance description.</param>
        /// <param name="specificationDescription">The specification description.</param>
        /// <param name="attachmentIds">The attachment ids.</param>
        /// <returns></returns>
        DataSet ManageServiceRequest(long serviceRequestId, long dealerProfileId, long carDetailsId, long userProfileId, DateTime appointmentDate, TimeSpan appointmentTime, DateTime appointmentRequestDate, bool isPickupDropAvailable,string inspectionDescription, string periodicMaintenanceDescription, string specificationDescription, DataTable attachmentIds);

        /// <summary>
        /// Gets the user service history.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        DataSet GetUserServiceHistory(long userProfileId);

        /// <summary>
        /// Manages the service status.
        /// </summary>
        /// <param name="serviceRequstId">The service requst identifier.</param>
        /// <param name="serviceStatusTypeId">The service status type identifier.</param>
        /// <returns></returns>
        DataSet ManageServiceStatus(long serviceRequstId, int serviceStatusTypeId);

        /// <summary>
        /// Gets the pending for approval by dealer profile identifier.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        DataSet GetServicePendingForApprovalByDealerProfileId(long dealerProfileId);

        /// <summary>
        /// Gets the service pending for action by dealer profile identifier.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        DataSet GetServicePendingForActionByDealerProfileId(long dealerProfileId);

        /// <summary>
        /// Gets the service pending for approval by user profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        DataSet GetServicePendingForApprovalByUserProfileId(long userProfileId);

        /// <summary>
        /// Gets the service pending for action by user profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        DataSet GetServicePendingForActionByUserProfileId(long userProfileId);

        /// <summary>
        /// Gets the active services by user profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        DataSet GetActiveServicesByUserProfileId(long userProfileId);

        /// <summary>
        /// Cancels the service request by dealer.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <param name="cancelReason">The cancel reason.</param>
        /// <param name="serviceStatusTypeId">The service status type identifier.</param>
        /// <returns></returns>
        DataSet CancelServiceRequestByDealer(long serviceRequestId, string cancelReason, int serviceStatusTypeId);

        /// <summary>
        /// Gets the dealer service history.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        DataSet GetDealerServiceHistory(long dealerProfileId);
    }
}
