
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using WSMobileApp.BusinessLogic.EntityConverter.DataTableToEntity;
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;
using WSMobileApp.DataProcess.DealerProfile;

namespace WSMobileApp.Common.DealerProfile
{
    public sealed class DealerRatingsLogic : IDealerRatingsLogic
    {
        #region Implementation of IDealerRatingsLogic

        /// <summary>
        /// CreateDealerRatings
        /// </summary>
        /// <param name="dealerRatingsEntity">The dealer ratings entity.</param>
        /// <returns>
        /// DealerRatingsCollection
        /// </returns>
        public DealerRatingsCollection CreateDealerRatings(DealerRatingsEntity dealerRatingsEntity)
        {
            try
            {
                return ConvertDataSetToDealerProfileCollection(InitializeDealerRatingsDataProcess.CreateDealerRatings(dealerRatingsEntity.DealerProfileId, dealerRatingsEntity.Ratings, dealerRatingsEntity.UserProfileId, dealerRatingsEntity.RatingDescription,dealerRatingsEntity.ServiceRequestId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// DeleteDealerRatings
        /// </summary>
        /// <param name="dealerRatingsId">dealerRatingsId</param>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <returns>DealerRatingsCollection</returns>
        public DealerRatingsCollection DeleteDealerRatings(long dealerRatingsId, long dealerProfileId)
        {
            try
            {
                return ConvertDataSetToDealerProfileCollection(InitializeDealerRatingsDataProcess.DeleteDealerRatings(dealerProfileId, dealerProfileId));
            }
            catch (Exception)
            {
               throw;
            }
        }

        /// <summary>
        /// GetDealerRatingsByDealerProfileId
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <returns>DealerRatingsCollection</returns>
        public DealerRatingsCollection GetDealerRatingsByDealerProfileId(long dealerProfileId)
        {
            try
            {
                return ConvertDataSetToDealerProfileCollection(InitializeDealerRatingsDataProcess.GetDealerRatingsByDealerProfileId(dealerProfileId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Initializers

        /// <summary>
        /// _initializeDealerRatingsDataProcess
        /// </summary>
        private IDealerRatingsDataProcess _initializeDealerRatingsDataProcess;

        /// <summary>
        /// InitializeDealerRatingsDataProcess
        /// </summary>
        private IDealerRatingsDataProcess InitializeDealerRatingsDataProcess
        {
            get
            {
                return _initializeDealerRatingsDataProcess ?? (_initializeDealerRatingsDataProcess = new DealerRatingsDataProcess());
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// ConvertDataSetToDealerProfileCollection
        /// </summary>
        /// <param name="dataSet">dataSet</param>
        /// <returns>DealerRatingsCollection</returns>
        private static DealerRatingsCollection ConvertDataSetToDealerProfileCollection(DataSet dataSet)
        {
            return dataSet == null
                       ? null
                       : (dataSet.Tables[0] == null
                       ? null
                       : (dataSet.Tables[0].Rows.Count <= 0
                       ? null
                       : DealerRatingsDataTableToEntityConverter.ConvertDataTableToDealerRatingsCollection
                       ( dataSet.Tables[0])));
        }

        #endregion
    }
}
