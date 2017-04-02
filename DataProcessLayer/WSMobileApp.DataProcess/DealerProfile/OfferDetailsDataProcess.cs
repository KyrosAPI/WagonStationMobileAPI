
using System;
using System.Collections.Generic;
using System.Data;
using WSMobileApp.DataAccessLayer;
using WSMobileApp.DataProcess.Resource;

namespace WSMobileApp.DataProcess.DealerProfile
{
    public sealed class OfferDetailsDataProcess : IOfferDetailsDataProcess
    {
        /// <summary>
        /// DeleteOfferDetails
        /// </summary>
        /// <param name="offerDetailsId">offerDetailsId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>DataSet</returns>
        public DataSet DeleteOfferDetails(long offerDetailsId, long userProfileId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_DeleteOfferDetails, new Dictionary<string, object>
                                                                                                      {
                                                                                                          {DataProcessResource.spparam_OfferDetailsId,offerDetailsId},
                                                                                                          {DataProcessResource.spparam_UserProfileId,userProfileId}
                                                                                                      });
        }

        /// <summary>
        /// GetOfferDetailsByDealerProfileId
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <param name="currentDate">The current date.</param>
        /// <returns>
        /// DataSet
        /// </returns>
        public DataSet GetOfferDetailsByDealerProfileId(long dealerProfileId,DateTime currentDate)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_GetOfferDetailsByDealerProfileId, new Dictionary<string, object>
                                                                                                                    {
                                                                                                                        {DataProcessResource.spparam_DealerProfileId,dealerProfileId},
                                                                                                                        {DataProcessResource.spparam_CurrentDate,currentDate }
                                                                                                                    });
        }

        /// <summary>
        /// GetOfferDetailsById
        /// </summary>
        /// <param name="offerDetailsId">offerDetailsId</param>
        /// <returns>DataSet</returns>
        public DataSet GetOfferDetailsById(long offerDetailsId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_GetOfferDetailsById,new Dictionary<string, object>
                                                                                                       {
                                                                                                           {DataProcessResource.spparam_OfferDetailsId,offerDetailsId}
                                                                                                       });
        }

        /// <summary>
        /// GetOfferDetailsByUserProfileId
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>DataSet</returns>
        public DataSet GetOfferDetailsByUserProfileId(long userProfileId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_GetOfferDetailsByUserProfileId, new Dictionary<string, object>
                                                                                                                  {
                                                                                                                      {DataProcessResource.spparam_UserProfileId,userProfileId}
                                                                                                                  });
        }

        /// <summary>
        /// ManageOfferDetails
        /// </summary>
        /// <param name="offerDetailsId">offerDetailsId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="offerStartDate">offerStartDate</param>
        /// <param name="offerEndDate">offerEndDate</param>
        /// <param name="offerDescription">offerDescription</param>
        /// <returns></returns>
        public DataSet ManageOfferDetails(long offerDetailsId, long userProfileId, DateTime offerStartDate, DateTime offerEndDate, string offerDescription)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_ManageOfferDetails, new Dictionary<string, object>
                                                                                                       {
                                                                                                           {DataProcessResource.spparam_OfferDetailsId,offerDetailsId},
                                                                                                           {DataProcessResource.spparam_UserProfileId,userProfileId},
                                                                                                           {DataProcessResource.spparam_OfferStartDate,offerStartDate},
                                                                                                           {DataProcessResource.spparam_OfferEndDate,offerEndDate},
                                                                                                           {DataProcessResource.spparam_OfferDescription,offerDescription}
                                                                                                       });
        }

        #region Initializers

        /// <summary>
        /// Initialize Data Access
        /// </summary>
        private IDataAccess _initializeDataAccess;

        /// <summary>
        /// Initialize Data Access
        /// </summary>
        private IDataAccess InitializeDataAccess
        {
            get { return _initializeDataAccess ?? (_initializeDataAccess = new DataAccess()); }
        }

        #endregion
    }
}
