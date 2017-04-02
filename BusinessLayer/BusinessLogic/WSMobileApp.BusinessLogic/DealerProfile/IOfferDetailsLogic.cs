
using System;
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.Common.DealerProfile
{
    public interface IOfferDetailsLogic
    {
        /// <summary>
        /// DeleteOfferDetails
        /// </summary>
        /// <param name="offerDetailsId">OfferDetailsId</param>
        /// <param name="userProfileId">UserProfileId</param>
        /// <returns>OfferDetailsCollection</returns>
        OfferDetailsCollection DeleteOfferDetails(long offerDetailsId, long userProfileId);

        /// <summary>
        /// GetOfferDetailsByDealerProfileId
        /// </summary>
        /// <param name="dealerProfileId">DealerProfileId</param>
        /// <param name="currentDate">The current date.</param>
        /// <returns>
        /// OfferDetailsCollection
        /// </returns>
        OfferDetailsCollection GetOfferDetailsByDealerProfileId(long dealerProfileId,DateTime currentDate);

        /// <summary>
        /// GetOfferDetailsById
        /// </summary>
        /// <param name="offerDetailsId">offerDetailsId</param>
        /// <returns>OfferDetailsEntity</returns>
        OfferDetailsEntity GetOfferDetailsById(long offerDetailsId);

        /// <summary>
        /// GetOfferDetailsByUserProfileId
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>OfferDetailsEntity</returns>
        OfferDetailsCollection GetOfferDetailsByUserProfileId(long userProfileId);

        /// <summary>
        /// ManageOfferDetails
        /// </summary>
        /// <param name="offerDetailsEntity">The offer details entity.</param>
        /// <returns>
        /// OfferDetailsCollection
        /// </returns>
        OfferDetailsCollection ManageOfferDetails(OfferDetailsEntity offerDetailsEntity);
    }
}
