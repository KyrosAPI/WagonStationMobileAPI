
using System;
using System.Collections.Generic;
using System.Data;
using WSMobileApp.DataAccessLayer;
using WSMobileApp.DataProcess.Resource;

namespace WSMobileApp.DataProcess.ServiceDetails
{
    public sealed class ServiceDetailsDataProcess : IServiceDetailsDataProcess
    {
        #region Implementation of IServiceDetailsDataProcess

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
        public DataSet ManageServiceRequest(long serviceRequestId, long dealerProfileId, long carDetailsId, long userProfileId, DateTime appointmentDate, TimeSpan appointmentTime, DateTime appointmentRequestDate, bool isPickupDropAvailable, string inspectionDescription, string periodicMaintenanceDescription, string specificationDescription,DataTable attachmentIds)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_ManageServiceRequest, new Dictionary<string, object>
                                                                                                         {
                                                                                                             {DataProcessResource.spparam_ServiceRequestId,serviceRequestId},
                                                                                                             {DataProcessResource.spparam_DealerProfileId,dealerProfileId},
                                                                                                             {DataProcessResource.spparam_UserProfileId,userProfileId},
                                                                                                             {DataProcessResource.spparam_cardetailsid,carDetailsId},
                                                                                                             {DataProcessResource.spparam_AppointmentDate,appointmentDate},
                                                                                                             {DataProcessResource.spparam_AppointmentTime,appointmentTime},
                                                                                                             {DataProcessResource.spparam_AppointmentRequestDate,appointmentRequestDate},
                                                                                                             {DataProcessResource.spparam_IsPickupDropAvailable,isPickupDropAvailable},
                                                                                                             {DataProcessResource.spparam_InspectionDescription,inspectionDescription},
                                                                                                             {DataProcessResource.spparam_PeriodicMaintenanceDescription,periodicMaintenanceDescription},
                                                                                                             {DataProcessResource.spparam_SpecificationDescription,specificationDescription},
                                                                                                             {DataProcessResource.spparam_AttachmentIds,attachmentIds}
                                                                                                         });
        }

        /// <summary>
        /// Gets the user service history.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        public DataSet GetUserServiceHistory(long userProfileId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_GetUserServiceHistory, new Dictionary<string, object>
                                                                                                          {
                                                                                                              {DataProcessResource.spparam_UserProfileId,userProfileId}
                                                                                                          });
        }

        /// <summary>
        /// Manages the service status.
        /// </summary>
        /// <param name="serviceRequstId">The service requst identifier.</param>
        /// <param name="serviceStatusTypeId">The service status type identifier.</param>
        /// <returns></returns>
        public DataSet ManageServiceStatus(long serviceRequstId, int serviceStatusTypeId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_ManageServiceStatus, new Dictionary<string, object>
                                                                                                        {
                                                                                                            {DataProcessResource.spparam_ServiceRequestId,serviceRequstId},
                                                                                                            {DataProcessResource.spparam_ServiceStatusTypeId,serviceStatusTypeId}
                                                                                                        });
        }

        /// <summary>
        /// Gets the pending for approval by dealer profile identifier.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        public DataSet GetServicePendingForApprovalByDealerProfileId(long dealerProfileId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_GetDealerPendingForApproval, new Dictionary<string, object>
                                                                                                               {
                                                                                                                   {DataProcessResource.spparam_DealerProfileId,dealerProfileId}
                                                                                                               });
        }

        /// <summary>
        /// Gets the service pending for action by dealer profile identifier.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        public DataSet GetServicePendingForActionByDealerProfileId(long dealerProfileId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_GetDealerPendingForAction, new Dictionary<string, object>
                                                                                                              {
                                                                                                                  {DataProcessResource.spparam_DealerProfileId,dealerProfileId}
                                                                                                              });
        }

        /// <summary>
        /// Gets the service pending for approval by user profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        public DataSet GetServicePendingForApprovalByUserProfileId(long userProfileId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_GetDealerPendingForApprovalByUserProfileId, new Dictionary<string, object>
                                                                                                              {
                                                                                                                  {DataProcessResource.spparam_UserProfileId,userProfileId}
                                                                                                              });
        }

        /// <summary>
        /// Gets the service pending for action by user profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        public DataSet GetServicePendingForActionByUserProfileId(long userProfileId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_GetDealerPendingForActionByUserProfileId, new Dictionary<string, object>
                                                                                                              {
                                                                                                                  {DataProcessResource.spparam_UserProfileId,userProfileId}
                                                                                                              });
        }

        /// <summary>
        /// Gets the active services by user profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        public DataSet GetActiveServicesByUserProfileId(long userProfileId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_GetActiveServicesByUserProfileId, new Dictionary<string, object>
                                                                                                                    {
                                                                                                                        {DataProcessResource.spparam_UserProfileId,userProfileId}
                                                                                                                    });
        }

        /// <summary>
        /// Cancels the service request by dealer.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <param name="cancelReason">The cancel reason.</param>
        /// <param name="serviceStatusTypeId">The service status type identifier.</param>
        /// <returns></returns>
        public DataSet CancelServiceRequestByDealer(long serviceRequestId, string cancelReason, int serviceStatusTypeId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_CancelServiceRequestByDealer, new Dictionary<string, object>
                                                                                                                 {
                                                                                                                     {DataProcessResource.spparam_ServiceRequestId,serviceRequestId},
                                                                                                                     {DataProcessResource.spparam_CancelReason,cancelReason},
                                                                                                                     {DataProcessResource.spparam_ServiceStatusTypeId,serviceStatusTypeId}
                                                                                                                 });
        }

        /// <summary>
        /// Gets the dealer service history.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        public DataSet GetDealerServiceHistory(long dealerProfileId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_DealerServiceHistory, new Dictionary<string, object>
                                                                                                        {
                                                                                                            {DataProcessResource.spparam_UserProfileId,dealerProfileId}
                                                                                                        });
        }

        #endregion

        #region Initailizers

        /// <summary>
        /// The _initialize data access
        /// </summary>
        private IDataAccess _initializeDataAccess;

        /// <summary>
        /// Gets the initialize data access.
        /// </summary>
        /// <value>
        /// The initialize data access.
        /// </value>
        private IDataAccess InitializeDataAccess
        {
            get { return _initializeDataAccess ?? (_initializeDataAccess = new DataAccess()); }
        }

        #endregion
    }
}
