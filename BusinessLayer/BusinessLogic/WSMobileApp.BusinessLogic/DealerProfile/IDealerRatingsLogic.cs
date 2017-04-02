
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.Common.DealerProfile
{
    public interface IDealerRatingsLogic
    {

        /// <summary>
        /// CreateDealerRatings
        /// </summary>
        /// <param name="dealerRatingsEntity">The dealer ratings entity.</param>
        /// <returns>
        /// DealerRatingsCollection
        /// </returns>
        DealerRatingsCollection CreateDealerRatings(DealerRatingsEntity dealerRatingsEntity);

        /// <summary>
        /// DeleteDealerRatings
        /// </summary>
        /// <param name="dealerRatingsId"></param>
        /// <param name="dealerProfileId"></param>
        /// <returns></returns>
        DealerRatingsCollection DeleteDealerRatings(long dealerRatingsId, long dealerProfileId);

        /// <summary>
        /// GetDealerRatingsByDealerProfileId
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <returns>DealerRatingsCollection</returns>
        DealerRatingsCollection GetDealerRatingsByDealerProfileId(long dealerProfileId);
    }
}
