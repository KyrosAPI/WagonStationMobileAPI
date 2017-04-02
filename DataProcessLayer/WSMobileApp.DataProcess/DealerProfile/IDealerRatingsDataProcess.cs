
using System.Data;

namespace WSMobileApp.DataProcess.DealerProfile
{
    public interface IDealerRatingsDataProcess
    {
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
        DataSet CreateDealerRatings(long dealerProfileId, int ratings, long userProfileId, string ratingDescription, long serviceRequestId);

        /// <summary>
        /// DeleteDealerRatings
        /// </summary>
        /// <param name="dealerRatingsId">dealerRatingsId</param>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <returns>DataSet</returns>
        DataSet DeleteDealerRatings(long dealerRatingsId, long dealerProfileId);

        /// <summary>
        /// GetDealerRatingsByDealerProfileId
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <returns>DataSet</returns>
        DataSet GetDealerRatingsByDealerProfileId(long dealerProfileId);
    }
}
