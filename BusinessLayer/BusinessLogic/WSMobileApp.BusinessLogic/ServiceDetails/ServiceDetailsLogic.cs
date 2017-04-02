using System;
using System.Data;
using System.Globalization;
using System.Linq;
using WSMobileApp.BusinessLogic.EntityConverter.DataTableToEntity;
using WSMobileApp.BusinessLogic.EntityConverter.Resource;
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;
using WSMobileApp.Common.Enums;
using WSMobileApp.DataProcess.ServiceDetails;
using WSMobileApp.Notification.SmsNotification;

namespace WSMobileApp.BusinessLogic.ServiceDetails
{
    public sealed class ServiceDetailsLogic : IServiceDetailsLogic
    {
        #region Implementation of IServiceDetailsLogic

        /// <summary>
        /// Manages the service request.
        /// </summary>
        /// <param name="serviceRequestEntity">The service request entity.</param>
        /// <returns></returns>
        public ServiceRequestCollection ManageServiceRequest(ServiceRequestEntity serviceRequestEntity)
        {
            var appointmentDate = Convert.ToDateTime(serviceRequestEntity.AppointmentDateInString, CultureInfo.InvariantCulture);
            serviceRequestEntity.AppointmentTimeInString = serviceRequestEntity.AppointmentTimeInString.Replace("A.M", "AM").Replace("P.M", "PM");
            var appointmentTime = DateTime.ParseExact(serviceRequestEntity.AppointmentTimeInString, "hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay;

            serviceRequestEntity.AppointmentRequestDate = Convert.ToDateTime(serviceRequestEntity.AppointmentRequestDateInString, CultureInfo.InvariantCulture);

            ServiceDescriptionEntity inspectionServiceDescription = null;
            ServiceDescriptionEntity periodicMaintenanceDescription = null;
            ServiceDescriptionEntity specificationServiceDescription = null;

            if (serviceRequestEntity.ServiceDescriptions != null && serviceRequestEntity.ServiceDescriptions.Items != null && serviceRequestEntity.ServiceDescriptions.Items.Any())
            {
                inspectionServiceDescription = serviceRequestEntity.ServiceDescriptions.Items.FirstOrDefault(sr => sr.ServiceDescriptionTypeId == 1);

                periodicMaintenanceDescription = serviceRequestEntity.ServiceDescriptions.Items.FirstOrDefault(sr => sr.ServiceDescriptionTypeId == 2);

                specificationServiceDescription = serviceRequestEntity.ServiceDescriptions.Items.FirstOrDefault(sr => sr.ServiceDescriptionTypeId == 3);
            }

            return ConvertDataSetToServiceRequestCollection(InitializeServiceDetialsDataProcess.ManageServiceRequest(serviceRequestEntity.ServiceRequestId, serviceRequestEntity.DealerProfile.DealerProfileId, serviceRequestEntity.CarDetails.CarDetailsId, serviceRequestEntity.UserProfile.UserProfileId, appointmentDate, appointmentTime, Convert.ToDateTime(serviceRequestEntity.AppointmentRequestDateInString, CultureInfo.InvariantCulture), serviceRequestEntity.IsPickupDropAvailable, inspectionServiceDescription == null ? string.Empty : inspectionServiceDescription.ServiceDescription, periodicMaintenanceDescription == null ? string.Empty : periodicMaintenanceDescription.ServiceDescription, specificationServiceDescription == null ? string.Empty : specificationServiceDescription.ServiceDescription, ConvertListToDataTable(serviceRequestEntity.ServiceAttachments)));
        }

        /// <summary>
        /// Gets the user service history.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        public UserServiceHistoryEntity GetUserServiceHistory(long userProfileId)
        {
            try
            {
                return ConvertDataSetToUserServiceHistoryCollection(InitializeServiceDetialsDataProcess.GetUserServiceHistory(userProfileId));
            }
            catch (Exception exception)
            {
                return new UserServiceHistoryEntity { IsSuccess = false, Message = exception.Message == "SERVICE_ERROR_01" ? EntityConverterResource.SERVICE_ERROR_01 : exception.InnerException != null ? exception.InnerException.Message : exception.Message };
            }
        }

        /// <summary>
        /// Cancels the service request.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection CancelServiceRequest(long serviceRequestId)
        {
            var response = ConvertDataSetToServiceRequestCollection(InitializeServiceDetialsDataProcess.ManageServiceStatus(serviceRequestId, Convert.ToInt32(ServiceStatusType.CNL)));

            NotifyServiceStatusToUser(response, serviceRequestId, ServiceStatusType.CNL);

            return response;
        }

        /// <summary>
        /// Accepts the service request.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection AcceptServiceRequest(long serviceRequestId)
        {
            var response = ConvertDataSetToServiceRequestCollection(InitializeServiceDetialsDataProcess.ManageServiceStatus(serviceRequestId, Convert.ToInt32(ServiceStatusType.ACC)));

            NotifyServiceStatusToUser(response, serviceRequestId, ServiceStatusType.ACC);

            return response;
        }

        /// <summary>
        /// Rejects the service request.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection RejectServiceRequest(long serviceRequestId)
        {
            var response = ConvertDataSetToServiceRequestCollection(InitializeServiceDetialsDataProcess.ManageServiceStatus(serviceRequestId, Convert.ToInt32(ServiceStatusType.REJ)));
            NotifyServiceStatusToUser(response, serviceRequestId, ServiceStatusType.REJ);
            return response;
        }

        /// <summary>
        /// Updates the work in progress.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection UpdateWorkInProgress(long serviceRequestId)
        {
            var response = ConvertDataSetToServiceRequestCollection(InitializeServiceDetialsDataProcess.ManageServiceStatus(serviceRequestId, Convert.ToInt32(ServiceStatusType.WIP)));
            NotifyServiceStatusToUser(response, serviceRequestId, ServiceStatusType.WIP);
            return response;
        }

        /// <summary>
        /// Updates the ready for delivery.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection UpdateReadyForDelivery(long serviceRequestId)
        {
            var response = ConvertDataSetToServiceRequestCollection(InitializeServiceDetialsDataProcess.ManageServiceStatus(serviceRequestId, Convert.ToInt32(ServiceStatusType.RDEL)));
            NotifyServiceStatusToUser(response, serviceRequestId, ServiceStatusType.RDEL);
            return response;
        }

        /// <summary>
        /// Updates the delivered.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection UpdateDelivered(long serviceRequestId)
        {
            var response = ConvertDataSetToServiceRequestCollection(InitializeServiceDetialsDataProcess.ManageServiceStatus(serviceRequestId, Convert.ToInt32(ServiceStatusType.DEL)));
            NotifyServiceStatusToUser(response, serviceRequestId, ServiceStatusType.DEL);
            return response;
        }

        /// <summary>
        /// Gets the service pending for approval by dealer profile identifier.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        public DealerServiceEntity GetServicePendingForApprovalByDealerProfileId(long dealerProfileId)
        {
            return ConvertDataSetToDealerServiceEntity(InitializeServiceDetialsDataProcess.GetServicePendingForApprovalByDealerProfileId(dealerProfileId));
        }

        /// <summary>
        /// Gets the service pending for action by dealer profile identifier.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        public DealerServiceEntity GetServicePendingForActionByDealerProfileId(long dealerProfileId)
        {
            return ConvertDataSetToDealerServiceEntity(InitializeServiceDetialsDataProcess.GetServicePendingForActionByDealerProfileId(dealerProfileId));
        }

        /// <summary>
        /// Gets the service pending for approval by dealer profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        public DealerServiceEntity GetServicePendingForApprovalByUserProfileId(long userProfileId)
        {
            return ConvertDataSetToDealerServiceEntity(InitializeServiceDetialsDataProcess.GetServicePendingForApprovalByUserProfileId(userProfileId));
        }

        /// <summary>
        /// Gets the service pending for action by dealer profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        public DealerServiceEntity GetServicePendingForActionByUserProfileId(long userProfileId)
        {
            return ConvertDataSetToDealerServiceEntity(InitializeServiceDetialsDataProcess.GetServicePendingForActionByUserProfileId(userProfileId));
        }

        /// <summary>
        /// Gets the active services by user profile identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection GetActiveServicesByUserProfileId(long userProfileId)
        {
            return ConvertDataSetToServiceRequestCollection(InitializeServiceDetialsDataProcess.GetActiveServicesByUserProfileId(userProfileId));
        }

        /// <summary>
        /// Cancels the service request by dealer.
        /// </summary>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <param name="cancelReason">The cancel reason.</param>
        /// <returns></returns>
        public ServiceRequestCollection CancelServiceRequestByDealer(long serviceRequestId, string cancelReason)
        {
            var response = ConvertDataSetToServiceRequestCollection(InitializeServiceDetialsDataProcess.CancelServiceRequestByDealer(serviceRequestId, cancelReason, Convert.ToInt32(ServiceStatusType.DCNL)));
            NotifyServiceStatusToUser(response, serviceRequestId, ServiceStatusType.REJ);
            return response;
        }

        /// <summary>
        /// Gets the dealer service history.
        /// </summary>
        /// <param name="dealerProfileId">The dealer profile identifier.</param>
        /// <returns></returns>
        public ServiceRequestCollection GetDealerServiceHistory(long dealerProfileId)
        {
            return ConvertDataSetToServiceRequestCollection(InitializeServiceDetialsDataProcess.GetDealerServiceHistory(dealerProfileId));
        }

        #endregion

        #region Initializers

        /// <summary>
        /// The _initialize service details data process
        /// </summary>
        private IServiceDetailsDataProcess _initializeServiceDetailsDataProcess;

        /// <summary>
        /// Gets the initialize service detials data process.
        /// </summary>
        /// <value>
        /// The initialize service detials data process.
        /// </value>
        private IServiceDetailsDataProcess InitializeServiceDetialsDataProcess
        {
            get
            {
                return _initializeServiceDetailsDataProcess ?? (_initializeServiceDetailsDataProcess = new ServiceDetailsDataProcess());
            }
        }

        /// <summary>
        /// The initialize SMS notifier
        /// </summary>
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
        /// Notifies the service status to user.
        /// </summary>
        /// <param name="serviceRequestCollection">The service request collection.</param>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <param name="serviceStatusType">Type of the service status.</param>
        private void NotifyServiceStatusToUser(ServiceRequestCollection serviceRequestCollection, long serviceRequestId, ServiceStatusType serviceStatusType)
        {
            if (serviceRequestCollection == null || serviceRequestCollection.Items == null || !serviceRequestCollection.Items.Any())
            {
                return;
            }

            var serviceRequest = serviceRequestCollection.Items.FirstOrDefault(ser => ser.ServiceRequestId == serviceRequestId);
            if (serviceRequest == null)
            {
                return;
            }

            switch (serviceStatusType)
            {
                case ServiceStatusType.DEL:
                    InitializeSmsNotifier.NotifyDelivered(serviceRequest.DealerProfile.ShopName,
                                                         string.Concat(serviceRequest.CarDetails.CarName, " ", serviceRequest.CarDetails.CarModelName),
                                                          serviceRequest.UserProfile.UserName,
                                                          serviceRequest.UserProfile.UserMobileNumber,
                                                          serviceRequest.UserProfile.DeviceId,
                                                          serviceRequest.UserProfile.SenderId);
                    break;
                case ServiceStatusType.PA:
                    break;
                case ServiceStatusType.CNL:
                    InitializeSmsNotifier.NotifyUserCancelServiceRequest(serviceRequest.DealerProfile.ShopName,
                                                          serviceRequest.UserProfile.UserName,
                                                          serviceRequest.DealerProfile.UserProfile.UserMobileNumber,
                                                          serviceRequest.DealerProfile.UserProfile == null ? string.Empty : serviceRequest.DealerProfile.UserProfile.DeviceId,
                                                          serviceRequest.UserProfile.SenderId);
                    break;
                case ServiceStatusType.RDEL:
                    InitializeSmsNotifier.NotifyUpdateReadyForDelivery(serviceRequest.DealerProfile.ShopName,
                                                          string.Concat(serviceRequest.CarDetails.CarName, " ", serviceRequest.CarDetails.CarModelName),
                                                          serviceRequest.UserProfile.UserName,
                                                          serviceRequest.UserProfile.UserMobileNumber,
                                                          serviceRequest.UserProfile.DeviceId,
                                                          serviceRequest.UserProfile.SenderId);
                    break;
                case ServiceStatusType.REJ:
                    InitializeSmsNotifier.NotifyRejectServiceRequest(serviceRequest.DealerProfile.ShopName,
                                                          string.Concat(serviceRequest.CarDetails.CarName, " ", serviceRequest.CarDetails.CarModelName),
                                                          serviceRequest.UserProfile.UserName,
                                                          serviceRequest.UserProfile.UserMobileNumber,
                                                          serviceRequest.UserProfile.DeviceId,
                                                          serviceRequest.UserProfile.SenderId);
                    break;
                case ServiceStatusType.WIP:
                    InitializeSmsNotifier.NotifyUpdateWorkInProgress(serviceRequest.DealerProfile.ShopName,
                                                          string.Concat(serviceRequest.CarDetails.CarName, " ", serviceRequest.CarDetails.CarModelName),
                                                          serviceRequest.UserProfile.UserName,
                                                          serviceRequest.UserProfile.UserMobileNumber,
                                                          serviceRequest.UserProfile.DeviceId,
                                                          serviceRequest.UserProfile.SenderId);
                    break;
                case ServiceStatusType.ACC:
                    InitializeSmsNotifier.NotifyAcceptServiceRequest(serviceRequest.DealerProfile.ShopName, string.Concat(serviceRequest.CarDetails.CarName, " ", serviceRequest.CarDetails.CarModelName), serviceRequest.UserProfile.UserName, serviceRequest.UserProfile.UserMobileNumber, serviceRequest.UserProfile.DeviceId,
                                                          serviceRequest.UserProfile.SenderId);
                    break;
            }
        }

        /// <summary>
        /// Converts the data set to dealer service entity.
        /// </summary>
        /// <param name="dataSet">The data set.</param>
        /// <returns></returns>
        private static DealerServiceEntity ConvertDataSetToDealerServiceEntity(DataSet dataSet)
        {
            if (dataSet == null)
            {
                return null;
            }

            var response = new DealerServiceEntity
                               {
                                   ServiceRequests = ServiceRequestDataTableToEntityConverter.ConvertDataTableToServiceRequestCollection(dataSet.Tables[3])
                               };

            if (response.ServiceRequests != null && response.ServiceRequests.Items != null && response.ServiceRequests.Items.Any())
            {
                foreach (var serviceRequestEntity in response.ServiceRequests.Items)
                {
                    var userProfiles = UserProfileDataTableToEntityConverter.ConvertDataTableToUserProfileCollection(dataSet.Tables[0]);
                    if (userProfiles != null && userProfiles.Items != null && userProfiles.Items.Any())
                    {
                        serviceRequestEntity.UserProfile = userProfiles.Items.FirstOrDefault(up => up.UserProfileId == serviceRequestEntity.UserProfileId);
                    }

                    var dealerProfiles = DealerProfileDataTableToEntityConverter.ConvertDataTableToDealerProfileCollection(dataSet.Tables[1]);
                    if (dealerProfiles != null && dealerProfiles.Items != null && dealerProfiles.Items.Any())
                    {
                        serviceRequestEntity.DealerProfile = dealerProfiles.Items.FirstOrDefault(dp => dp.DealerProfileId == serviceRequestEntity.DealerProfileId);
                    }

                    var carDetails = CarDetailsDataTableToEntityConverter.ConvertDataTableToCarDetailsCollection(dataSet.Tables[2]);
                    if (carDetails != null && carDetails.Items != null && carDetails.Items.Any())
                    {
                        serviceRequestEntity.CarDetails = carDetails.Items.FirstOrDefault(cp => cp.CarDetailsId == serviceRequestEntity.CarDetailsId);
                    }

                    var serviceDescriptions = ServiceDescriptionDataTableToEntityConverter.ConvertDataTableToServiceDescriptionCollection(dataSet.Tables[4]);
                    if (serviceDescriptions != null && serviceDescriptions.Items != null && serviceDescriptions.Items.Any())
                    {
                        serviceRequestEntity.ServiceDescriptions = new ServiceDescriptionCollection { Items = serviceDescriptions.Items.Where(sd => sd.ServiceRequestId == serviceRequestEntity.ServiceRequestId).ToList() };
                    }

                    var serviceStatuses = ServiceStatusDataTableToEntityConverter.ConvertDataTableToServiceStatusCollection(dataSet.Tables[5]);
                    if (serviceStatuses != null && serviceStatuses.Items != null && serviceStatuses.Items.Any())
                    {
                        serviceRequestEntity.ServiceStatus = new ServiceStatusCollection { Items = serviceStatuses.Items.Where(ss => ss.ServiceRequestId == serviceRequestEntity.ServiceRequestId).ToList() };
                    }

                    var serviceAttachments = AttachmentDataTableToEntityConverter.ConvertDataTableToAttachmentCollection(dataSet.Tables[6], true);
                    if (serviceAttachments != null && serviceAttachments.Items != null && serviceAttachments.Items.Any())
                    {
                        serviceRequestEntity.ServiceAttachments = new AttachmentCollection { Items = serviceAttachments.Items.Where(sa => sa.ServiceRequestId == serviceRequestEntity.ServiceRequestId).ToList() };
                    }
                }
            }

            return response;
        }

        /// <summary>
        /// Converts the data set to service request collection.
        /// </summary>
        /// <param name="dataSet">The data set.</param>
        /// <returns></returns>
        private static ServiceRequestCollection ConvertDataSetToServiceRequestCollection(DataSet dataSet)
        {
            if (dataSet == null)
            {
                return null;
            }

            if (dataSet.Tables[0] == null)
            {
                return null;
            }

            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                return null;
            }


            var response = ServiceRequestDataTableToEntityConverter.ConvertDataTableToServiceRequestCollection(dataSet.Tables[3]);
            if (response == null || response.Items == null || !response.Items.Any())
            {
                return null;
            }

            foreach (var serviceRequestEntity in response.Items)
            {
                var userProfiles = UserProfileDataTableToEntityConverter.ConvertDataTableToUserProfileCollection(dataSet.Tables[0]);
                if (userProfiles != null && userProfiles.Items != null && userProfiles.Items.Any())
                {
                    serviceRequestEntity.UserProfile = userProfiles.Items.FirstOrDefault(up => up.UserProfileId == serviceRequestEntity.UserProfileId);
                }
                var dealerProfiles = DealerProfileDataTableToEntityConverter.ConvertDataTableToDealerProfileCollection(dataSet.Tables[1]);
                if (dealerProfiles != null && dealerProfiles.Items != null && dealerProfiles.Items.Any())
                {
                    serviceRequestEntity.DealerProfile = dealerProfiles.Items.FirstOrDefault(dp => dp.DealerProfileId == serviceRequestEntity.DealerProfileId);
                }
                var carDetails = CarDetailsDataTableToEntityConverter.ConvertDataTableToCarDetailsCollection(dataSet.Tables[2]);
                if (carDetails != null && carDetails.Items != null && carDetails.Items.Any())
                {
                    serviceRequestEntity.CarDetails = carDetails.Items.FirstOrDefault(cp => cp.CarDetailsId == serviceRequestEntity.CarDetailsId);
                }

                var serviceDescriptions = ServiceDescriptionDataTableToEntityConverter.ConvertDataTableToServiceDescriptionCollection(dataSet.Tables[4]);
                if (serviceDescriptions != null && serviceDescriptions.Items != null && serviceDescriptions.Items.Any())
                {
                    serviceRequestEntity.ServiceDescriptions = new ServiceDescriptionCollection { Items = serviceDescriptions.Items.Where(sd => sd.ServiceRequestId == serviceRequestEntity.ServiceRequestId).ToList() };
                }

                var serviceStatuses = ServiceStatusDataTableToEntityConverter.ConvertDataTableToServiceStatusCollection(dataSet.Tables[5]);
                if (serviceStatuses != null && serviceStatuses.Items != null && serviceStatuses.Items.Any())
                {
                    serviceRequestEntity.ServiceStatus = new ServiceStatusCollection { Items = serviceStatuses.Items.Where(ss => ss.ServiceRequestId == serviceRequestEntity.ServiceRequestId).ToList() };
                }

                var serviceAttachments = AttachmentDataTableToEntityConverter.ConvertDataTableToAttachmentCollection(dataSet.Tables[6], true);
                if (serviceAttachments != null && serviceAttachments.Items != null && serviceAttachments.Items.Any())
                {
                    serviceRequestEntity.ServiceAttachments = new AttachmentCollection { Items = serviceAttachments.Items.Where(sa => sa.ServiceRequestId == serviceRequestEntity.ServiceRequestId).ToList() };
                }
            }

            return response;
        }

        /// <summary>
        /// Converts the list to data table.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        /// <returns></returns>
        private static DataTable ConvertListToDataTable(AttachmentCollection attachments)
        {
            if (attachments == null || attachments.Items == null || !attachments.Items.Any())
            {
                return null;
            }

            using (var response = new DataTable())
            {
                response.Columns.Add("AttachmentId");
                foreach (var attachmentEntity in attachments.Items)
                {
                    response.Rows.Add(attachmentEntity.AttachmentId);
                }

                return response;
            }

        }

        /// <summary>
        /// Converts the data set to user service history collection.
        /// </summary>
        /// <param name="dataSet">The data set.</param>
        /// <returns></returns>
        private static UserServiceHistoryEntity ConvertDataSetToUserServiceHistoryCollection(DataSet dataSet)
        {
            if (dataSet == null)
            {
                return null;
            }

            if (dataSet.Tables[0] == null)
            {
                return null;
            }

            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                return null;
            }


            var response = new UserServiceHistoryEntity
                               {
                                   ServiceRequests = ServiceRequestDataTableToEntityConverter.ConvertDataTableToServiceRequestCollection(dataSet.Tables[3])
                               };
            if (response.ServiceRequests == null || response.ServiceRequests.Items == null || !response.ServiceRequests.Items.Any())
            {
                return null;
            }

            foreach (var serviceRequestEntity in response.ServiceRequests.Items)
            {
                var userProfiles = UserProfileDataTableToEntityConverter.ConvertDataTableToUserProfileCollection(dataSet.Tables[0]);
                if (userProfiles != null && userProfiles.Items != null && userProfiles.Items.Any())
                {
                    serviceRequestEntity.UserProfile = userProfiles.Items.FirstOrDefault(up => up.UserProfileId == serviceRequestEntity.UserProfileId);
                }
                var dealerProfiles = DealerProfileDataTableToEntityConverter.ConvertDataTableToDealerProfileCollection(dataSet.Tables[1]);
                if (dealerProfiles != null && dealerProfiles.Items != null && dealerProfiles.Items.Any())
                {
                    serviceRequestEntity.DealerProfile = dealerProfiles.Items.FirstOrDefault(dp => dp.DealerProfileId == serviceRequestEntity.DealerProfileId);
                }
                var carDetails = CarDetailsDataTableToEntityConverter.ConvertDataTableToCarDetailsCollection(dataSet.Tables[2]);
                if (carDetails != null && carDetails.Items != null && carDetails.Items.Any())
                {
                    serviceRequestEntity.CarDetails = carDetails.Items.FirstOrDefault(cp => cp.CarDetailsId == serviceRequestEntity.CarDetailsId);
                }

                var serviceDescriptions = ServiceDescriptionDataTableToEntityConverter.ConvertDataTableToServiceDescriptionCollection(dataSet.Tables[4]);
                if (serviceDescriptions != null && serviceDescriptions.Items != null && serviceDescriptions.Items.Any())
                {
                    serviceRequestEntity.ServiceDescriptions = new ServiceDescriptionCollection { Items = serviceDescriptions.Items.Where(sd => sd.ServiceRequestId == serviceRequestEntity.ServiceRequestId).ToList() };
                }

                var serviceStatuses = ServiceStatusDataTableToEntityConverter.ConvertDataTableToServiceStatusCollection(dataSet.Tables[5]);
                if (serviceStatuses != null && serviceStatuses.Items != null && serviceStatuses.Items.Any())
                {
                    serviceRequestEntity.ServiceStatus = new ServiceStatusCollection { Items = serviceStatuses.Items.Where(ss => ss.ServiceRequestId == serviceRequestEntity.ServiceRequestId).ToList() };
                }

                var serviceAttachments = AttachmentDataTableToEntityConverter.ConvertDataTableToAttachmentCollection(dataSet.Tables[6], true);
                if (serviceAttachments != null && serviceAttachments.Items != null && serviceAttachments.Items.Any())
                {
                    serviceRequestEntity.ServiceAttachments = new AttachmentCollection { Items = serviceAttachments.Items.Where(sa => sa.ServiceRequestId == serviceRequestEntity.ServiceRequestId).ToList() };
                }

            }

            return response;
        }

        #endregion
    }
}
