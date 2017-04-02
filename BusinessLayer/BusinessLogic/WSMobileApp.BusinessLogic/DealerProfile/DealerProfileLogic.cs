
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using WSMobileApp.BusinessLogic.EntityConverter.DataTableToEntity;
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;
using WSMobileApp.DataProcess.DealerProfile;

namespace WSMobileApp.Common.DealerProfile
{
    public sealed class DealerProfileLogic : IDealerProfileLogic
    {
        #region Implementation of IDealerProfileLogic

        /// <summary>
        /// UserLandingPageDetails
        /// </summary>
        /// <param name="currentLatitude">currentLatitude</param>
        /// <param name="currentLongitude">currentLongitude</param>
        /// <param name="currentDate">currentDate</param>
        /// <returns>UserProfileCollection</returns>
        public DealerProfileCollection UserLandingPageDetails(decimal currentLatitude, decimal currentLongitude, DateTime currentDate)
        {
            var response = InitializeDealerDetailsDataProcess.UserLandingPageDetails(currentLatitude, currentLongitude, currentDate);
            return response == null ? null : response.Tables[0] == null ? null : response.Tables[0].Rows.Count <= 0 ? null : ConvertDataTableToUserProfileCollection(response.Tables[0]);
        }

        /// <summary>
        /// UserLandingPageDetailsByBusinessType
        /// </summary>
        /// <param name="currentLatitude">currentLatitude</param>
        /// <param name="currentLongitude">currentLongitude</param>
        /// <param name="currentDate">currentDate</param>
        /// <param name="businessTypeId">businessTypeId</param>
        /// <returns>UserProfileCollection</returns>
        public DealerProfileCollection UserLandingPageDetailsByBusinessType(decimal currentLatitude, decimal currentLongitude, DateTime currentDate, int businessTypeId)
        {
            var response = InitializeDealerDetailsDataProcess.UserLandingPageDetailsByBusinessType(currentLatitude, currentLongitude, currentDate, businessTypeId);
            return response == null ? null : response.Tables[0] == null ? null : response.Tables[0].Rows.Count <= 0 ? null : ConvertDataTableToUserProfileCollection(response.Tables[0]);
        }

        /// <summary>
        /// GetDealerProfileById
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <param name="currentDate">currentDate</param>
        /// <returns>UserProfileCollection</returns>
        public DealerProfileCollection GetDealerProfileById(long dealerProfileId, DateTime currentDate)
        {
            var response = InitializeDealerDetailsDataProcess.GetDealerProfileById(dealerProfileId, currentDate);
            var res = response == null ? null : response.Tables[0] == null ? null : response.Tables[0].Rows.Count <= 0 ? null : ConvertDataTableToUserProfileCollection(response.Tables[0]);
            if (dealerProfileId > 0 && res != null && response.Tables[1] != null && response.Tables[2] != null)
            {
                var dealerProfiles = new List<DealerProfileEntity>();
                foreach (var dealerProfileEntity in res.Items)
                {
                    dealerProfileEntity.OfferDetails = OfferDetailsDataTableToEntityConverter.ConvertDataTableToOfferDetailsCollection(response.Tables[1]);
                    dealerProfileEntity.DealerRatings = DealerRatingsDataTableToEntityConverter.ConvertDataTableToDealerRatingsCollection(response.Tables[2]);
                    dealerProfiles.Add(dealerProfileEntity);
                }
                return new DealerProfileCollection { Items = dealerProfiles };
            }

            return res;
        }

        /// <summary>
        /// SortDealerDetailsByDistance
        /// </summary>
        /// <param name="currentLatitude">currentLatitude</param>
        /// <param name="currentLongitude">currentLongitude</param>
        /// <param name="currentDate">currentDate</param>
        /// <returns>UserProfileCollection</returns>
        public DealerProfileCollection SortDealerDetailsByDistance(decimal currentLatitude, decimal currentLongitude, DateTime currentDate)
        {
            var response = InitializeDealerDetailsDataProcess.SortDealerDetailsByDistance(currentLatitude, currentLongitude, currentDate);
            return response == null ? null : response.Tables[0] == null ? null : response.Tables[0].Rows.Count <= 0 ? null : ConvertDataTableToUserProfileCollection(response.Tables[0]);
        }

        /// <summary>
        /// SortDealerDetailsByRatings
        /// </summary>
        /// <param name="currentDate">currentDate</param>
        /// <returns>UserProfileCollection</returns>
        public DealerProfileCollection SortDealerDetailsByRatings(DateTime currentDate)
        {
            var response = InitializeDealerDetailsDataProcess.SortDealerDetailsByRatings(currentDate);
            return response == null ? null : response.Tables[0] == null ? null : response.Tables[0].Rows.Count <= 0 ? null : ConvertDataTableToUserProfileCollection(response.Tables[0]);
        }


        /// <summary>
        /// Filters the details.
        /// </summary>
        /// <param name="filterDealerCriteria">The filter dealer criteria.</param>
        /// <returns></returns>
        public DealerProfileCollection FilterDetails(FilterDealerCriteria filterDealerCriteria)
        {
            var response = InitializeDealerDetailsDataProcess.FilterDealerDetails(filterDealerCriteria.CurrentLatitude, filterDealerCriteria.CurrentLongitude, Convert.ToDateTime(filterDealerCriteria.CurrentDate, CultureInfo.InvariantCulture), filterDealerCriteria.IsCompanyOwned, filterDealerCriteria.IsMultiBrand, filterDealerCriteria.IsPickupDropAvailable, filterDealerCriteria.IsHavingOffers);
            var dealerProfiles = response == null ? null : response.Tables[0] == null ? null : response.Tables[0].Rows.Count <= 0 ? null : ConvertDataTableToUserProfileCollection(response.Tables[0]);

            if (dealerProfiles == null)
            {
                return null;
            }

            var dealerProfileList = dealerProfiles.Items;

            if (filterDealerCriteria.IsCompanyOwned)
            {
                dealerProfileList = dealerProfileList.Where(dp => string.Equals(dp.AuthorizedDealershipName, filterDealerCriteria.AuthorizedDealerShipName, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }

            if (filterDealerCriteria.IsPickupDropAvailable)
            {
                dealerProfileList = dealerProfileList.Where(dp => dp.IsPickupDropFacilityAvailable).ToList();
            }

            if (filterDealerCriteria.IsHavingOffers)
            {
                dealerProfileList = dealerProfileList.Where(dp => dp.OfferCount > 0).ToList();
            }

            return new DealerProfileCollection { Items = dealerProfileList };
        }


        #endregion

        #region Initializers

        /// <summary>
        /// _initializeDealerDetailsDataProcess
        /// </summary>
        private IDealerDetailsDataProcess _initializeDealerDetailsDataProcess;

        /// <summary>
        /// InitializeDealerDetailsDataProcess
        /// </summary>
        private IDealerDetailsDataProcess InitializeDealerDetailsDataProcess
        {
            get
            {
                return _initializeDealerDetailsDataProcess ?? (_initializeDealerDetailsDataProcess = new DealerDetailsDataProcess());
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// ConvertDataTableToUserProfileCollection
        /// </summary>
        /// <param name="dataTable">dataTable</param>
        /// <returns>UserProfileCollection</returns>
        private static DealerProfileCollection ConvertDataTableToUserProfileCollection(DataTable dataTable)
        {
            return dataTable == null
                       ? null
                       : (dataTable.Rows.Count <= 0
                       ? null
                       : DealerProfileDataTableToEntityConverter.ConvertDataTableToDealerProfileCollection(dataTable, true));
        }

        #endregion
    }
}
