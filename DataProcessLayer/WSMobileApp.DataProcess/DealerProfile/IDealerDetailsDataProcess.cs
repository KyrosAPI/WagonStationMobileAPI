
using System;
using System.Data;

namespace WSMobileApp.DataProcess.DealerProfile
{
    public interface IDealerDetailsDataProcess
    {
        /// <summary>
        /// UserLandingPageDetails
        /// </summary>
        /// <param name="currentLatitude">currentLatitude</param>
        /// <param name="currentLongitude">currentLongitude</param>
        /// <param name="currentDate">currentDate</param>
        /// <returns>DataSet</returns>
        DataSet UserLandingPageDetails(decimal currentLatitude, decimal currentLongitude, DateTime currentDate);

        /// <summary>
        /// UserLandingPageDetailsByBusinessType
        /// </summary>
        /// <param name="currentLatitude">currentLatitude</param>
        /// <param name="currentLongitude">currentLongitude</param>
        /// <param name="currentDate">currentDate</param>
        /// <param name="businessTypeId">businessTypeId</param>
        /// <returns>DataSet</returns>
        DataSet UserLandingPageDetailsByBusinessType(decimal currentLatitude, decimal currentLongitude, DateTime currentDate, int businessTypeId);

        /// <summary>
        /// GetDealerProfileById
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <param name="currentDate">currentDate</param>
        /// <returns>DataSet</returns>
        DataSet GetDealerProfileById(long dealerProfileId, DateTime currentDate);

        /// <summary>
        /// SortDealerDetailsByDistance
        /// </summary>
        /// <param name="currentLatitude">currentLatitude</param>
        /// <param name="currentLongitude">currentLongitude</param>
        /// <param name="currentDate">currentDate</param>
        /// <returns>DataSet</returns>
        DataSet SortDealerDetailsByDistance(decimal currentLatitude, decimal currentLongitude, DateTime currentDate);

        /// <summary>
        /// SortDealerDetailsByRatings
        /// </summary>
        /// <param name="currentDate">currentDate</param>
        /// <returns>DataSet</returns>
        DataSet SortDealerDetailsByRatings(DateTime currentDate);

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
        DataSet FilterDealerDetails(decimal currentLatitude, decimal currentLongitude, DateTime currentDate, bool isCompanyOwned, bool isMultiBrand, bool isPickupAndDrop, bool isHavingOffers);
    }
}
