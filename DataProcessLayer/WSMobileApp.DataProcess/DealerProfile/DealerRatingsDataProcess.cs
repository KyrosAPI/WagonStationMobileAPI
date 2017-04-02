using System;
using System.Collections.Generic;
using System.Data;
using WSMobileApp.DataAccessLayer;
using WSMobileApp.DataProcess.Resource;

namespace WSMobileApp.DataProcess.DealerProfile
{
    public sealed class DealerRatingsDataProcess : IDealerRatingsDataProcess
    {
        #region Implementation of IDealerRatingsDataProcess

        /// <summary>
        /// CreateDealerRatings
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <param name="ratings">ratings</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="ratingDescription">ratingDescription</param>
        /// <param name="serviceRequestId">The service request identifier.</param>
        /// <returns>
        /// DataSet
        /// </returns>
        public DataSet CreateDealerRatings(long dealerProfileId, int ratings, long userProfileId, string ratingDescription, long serviceRequestId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_CreateDealerRatings, new Dictionary<string, object>
                                                                                                       {
                                                                                                           {DataProcessResource.spparam_DealerProfileId,dealerProfileId},
                                                                                                           {DataProcessResource.spparam_Rating,ratings},
                                                                                                           {DataProcessResource.spparam_UserProfileId,userProfileId},
                                                                                                           {DataProcessResource.spparam_RatingDescription,ratingDescription},
                                                                                                           {DataProcessResource.spparam_ServiceRequestId,serviceRequestId}
                                                                                                       });
        }

        /// <summary>
        /// DeleteDealerRatings
        /// </summary>
        /// <param name="dealerRatingsId">dealerRatingsId</param>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <returns>DataSet</returns>
        public DataSet DeleteDealerRatings(long dealerRatingsId, long dealerProfileId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_DeleteDealerRatings, new Dictionary<string, object>
                                                                                                        {
                                                                                                            {DataProcessResource.spparam_DealerRatingsId,dealerRatingsId},
                                                                                                            {DataProcessResource.spparam_DealerProfileId,dealerProfileId}
                                                                                                        });
        }

        /// <summary>
        /// GetDealerRatingsByDealerProfileId
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <returns>DataSet</returns>
        public DataSet GetDealerRatingsByDealerProfileId(long dealerProfileId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_GetDealerRatingByDealerProfileId, new Dictionary<string, object>
                                                                                                                    {
                                                                                                                        {DataProcessResource.spparam_DealerProfileId,dealerProfileId}
                                                                                                                    });
        }

        #endregion

        #region Initializers

        /// <summary>
        /// initialize data access
        /// </summary>
        private IDataAccess _initailizeDataAccess;

        /// <summary>
        /// initialize data access
        /// </summary>
        private IDataAccess InitializeDataAccess
        {
            get { return _initailizeDataAccess ?? (_initailizeDataAccess = new DataAccess()); }
        }

        #endregion
    }
}
