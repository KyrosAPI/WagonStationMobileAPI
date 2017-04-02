
using System;
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.Common.DealerProfile
{
    public interface IDealerProfileLogic
    {
        /// <summary>
        /// UserLandingPageDetails
        /// </summary>
        /// <param name="currentLatitude">currentLatitude</param>
        /// <param name="currentLongitude">currentLongitude</param>
        /// <param name="currentDate">currentDate</param>
        /// <returns>UserProfileCollection</returns>
        DealerProfileCollection UserLandingPageDetails(decimal currentLatitude, decimal currentLongitude, DateTime currentDate);

        /// <summary>
        /// UserLandingPageDetailsByBusinessType
        /// </summary>
        /// <param name="currentLatitude">currentLatitude</param>
        /// <param name="currentLongitude">currentLongitude</param>
        /// <param name="currentDate">currentDate</param>
        /// <param name="businessTypeId">businessTypeId</param>
        /// <returns>UserProfileCollection</returns>
        DealerProfileCollection UserLandingPageDetailsByBusinessType(decimal currentLatitude, decimal currentLongitude, DateTime currentDate, int businessTypeId);

        /// <summary>
        /// GetDealerProfileById
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <param name="currentDate">currentDate</param>
        /// <returns>UserProfileCollection</returns>
        DealerProfileCollection GetDealerProfileById(long dealerProfileId, DateTime currentDate);

        /// <summary>
        /// SortDealerDetailsByDistance
        /// </summary>
        /// <param name="currentLatitude">currentLatitude</param>
        /// <param name="currentLongitude">currentLongitude</param>
        /// <param name="currentDate">currentDate</param>
        /// <returns>UserProfileCollection</returns>
        DealerProfileCollection SortDealerDetailsByDistance(decimal currentLatitude, decimal currentLongitude, DateTime currentDate);

        /// <summary>
        /// SortDealerDetailsByRatings
        /// </summary>
        /// <param name="currentDate">currentDate</param>
        /// <returns>UserProfileCollection</returns>
        DealerProfileCollection SortDealerDetailsByRatings(DateTime currentDate);

        /// <summary>
        /// Filters the details.
        /// </summary>
        /// <param name="filterDealerCriteria">The filter dealer criteria.</param>
        /// <returns></returns>
        DealerProfileCollection FilterDetails(FilterDealerCriteria filterDealerCriteria);
    }
}
