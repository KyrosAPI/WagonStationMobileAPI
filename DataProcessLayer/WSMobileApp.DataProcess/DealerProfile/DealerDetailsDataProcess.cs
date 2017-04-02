
using System;
using System.Collections.Generic;
using System.Data;
using WSMobileApp.DataAccessLayer;
using WSMobileApp.DataProcess.Resource;

namespace WSMobileApp.DataProcess.DealerProfile
{
    public sealed class DealerDetailsDataProcess : IDealerDetailsDataProcess
    {
        #region Implementation of IDealerDetailsDataProcess

        /// <summary>
        /// UserLandingPageDetails
        /// </summary>
        /// <param name="currentLatitude">currentLatitude</param>
        /// <param name="currentLongitude">currentLongitude</param>
        /// <param name="currentDate">currentDate</param>
        /// <returns>DataSet</returns>
        public DataSet UserLandingPageDetails(decimal currentLatitude, decimal currentLongitude, DateTime currentDate)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_UserLandingPageDetails, new Dictionary<string, object>
                                                                                                          {
                                                                                                              {DataProcessResource.spparam_CurrentLatitude,currentLatitude},
                                                                                                              {DataProcessResource.spparam_CurrentLongitude,currentLongitude},
                                                                                                              {DataProcessResource.spparam_CurrentDate,currentDate}
                                                                                                          });
        }

        /// <summary>
        /// UserLandingPageDetailsByDistance
        /// </summary>
        /// <param name="currentLatitude">currentLatitude</param>
        /// <param name="currentLongitude">currentLongitude</param>
        /// <param name="currentDate">currentDate</param>
        /// <param name="businessTypeId">businessTypeId</param>
        /// <returns>DataSet</returns>
        public DataSet UserLandingPageDetailsByBusinessType(decimal currentLatitude, decimal currentLongitude, DateTime currentDate, int businessTypeId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_UserLandingPageDetailsByBusinessType, new Dictionary<string, object>
                                                                                                          {
                                                                                                              {DataProcessResource.spparam_CurrentLatitude,currentLatitude},
                                                                                                              {DataProcessResource.spparam_CurrentLongitude,currentLongitude},
                                                                                                              {DataProcessResource.spparam_CurrentDate,currentDate},
                                                                                                              {DataProcessResource.spparam_BusinessTypeId,businessTypeId}
                                                                                                          });
        }

        /// <summary>
        /// GetDealerProfileById
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <param name="currentDate">currentDate</param>
        /// <returns>DataSet</returns>
        public DataSet GetDealerProfileById(long dealerProfileId, DateTime currentDate)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_GetDealerProfileById, new Dictionary<string, object>
                                                                                                        {
                                                                                                            {DataProcessResource.spparam_DealerProfileId,dealerProfileId},
                                                                                                            {DataProcessResource.spparam_CurrentDate,currentDate}
                                                                                                        });
        }

        /// <summary>
        /// SortDealerDetailsByDistance
        /// </summary>
        /// <param name="currentLatitude">currentLatitude</param>
        /// <param name="currentLongitude">currentLongitude</param>
        /// <param name="currentDate">currentDate</param>
        /// <returns>DataSet</returns>
        public DataSet SortDealerDetailsByDistance(decimal currentLatitude, decimal currentLongitude, DateTime currentDate)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_SortDealerDetailsByDistance, new Dictionary<string, object>
                                                                                                               {
                                                                                                                   {DataProcessResource.spparam_CurrentLatitude,currentLatitude},
                                                                                                                   {DataProcessResource.spparam_CurrentLongitude,currentLongitude},
                                                                                                                   {DataProcessResource.spparam_CurrentDate,currentDate}
                                                                                                               });
        }

        /// <summary>
        /// SortDealerDetailsByRatings
        /// </summary>
        /// <param name="currentDate">currentDate</param>
        /// <returns>DataSet</returns>
        public DataSet SortDealerDetailsByRatings(DateTime currentDate)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_SortDealerDetailsByRatings, new Dictionary<string, object>
                                                                                                               {
                                                                                                                   {DataProcessResource.spparam_CurrentDate,currentDate}
                                                                                                               });
        }

        /// <summary>
        /// Filters the dealer details.
        /// </summary>
        /// <param name="currentLatitude">The current latitude.</param>
        /// <param name="currentLongitude">The current longitude.</param>
        /// <param name="currentDate">The current date.</param>
        /// <param name="isCompanyOwned">if set to <c>true</c> [is company owned].</param>
        /// <param name="isMultiBrand">if set to <c>true</c> [is multi brand].</param>
        /// <param name="isPickupAndDrop">if set to <c>true</c> [is pickup and drop].</param>
        /// <param name="isHavingOffers">if set to <c>true</c> [is having offers].</param>
        /// <returns></returns>
        public DataSet FilterDealerDetails(decimal currentLatitude, decimal currentLongitude, DateTime currentDate, bool isCompanyOwned, bool isMultiBrand, bool isPickupAndDrop, bool isHavingOffers)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_FilterDealerDetails, new Dictionary<string, object>
            {
                {DataProcessResource.spparam_CurrentLatitude,currentLatitude },
                {DataProcessResource.spparam_CurrentLongitude,currentLongitude },
                {DataProcessResource.spparam_CurrentDate,currentDate },
                {DataProcessResource.spparam_IsCompanyOwned,isCompanyOwned },
                {DataProcessResource.spparam_IsMultiBrand,isMultiBrand },
                {DataProcessResource.spparam_IsPickupDropAvailable,isPickupAndDrop },
                {DataProcessResource.spparam_IsHavingOffers,isHavingOffers }
            });
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// _initializeDataAccess
        /// </summary>
        private IDataAccess _initializeDataAccess;

        /// <summary>
        /// InitializeDataAccess
        /// </summary>
        private IDataAccess InitializeDataAccess
        {
            get { return _initializeDataAccess ?? (_initializeDataAccess = new DataAccess()); }
        }

        #endregion
    }
}
