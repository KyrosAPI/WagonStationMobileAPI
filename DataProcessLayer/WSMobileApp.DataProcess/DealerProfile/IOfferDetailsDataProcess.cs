
using System;
using System.Data;

namespace WSMobileApp.DataProcess.DealerProfile
{
    public interface IOfferDetailsDataProcess
    {
        /// <summary>
        /// DeleteOfferDetails
        /// </summary>
        /// <param name="offerDetailsId">offerDetailsId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>DataSet</returns>
        DataSet DeleteOfferDetails(long offerDetailsId, long userProfileId);

        /// <summary>
        /// GetOfferDetailsByDealerProfileId
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <param name="currentDate">The current date.</param>
        /// <returns>
        /// DataSet
        /// </returns>
        DataSet GetOfferDetailsByDealerProfileId(long dealerProfileId,DateTime currentDate);

        /// <summary>
        /// GetOfferDetailsById
        /// </summary>
        /// <param name="offerDetailsId">offerDetailsId</param>
        /// <returns>IDataReader</returns>
        DataSet GetOfferDetailsById(long offerDetailsId);

        /// <summary>
        /// GetOfferDetailsByUserProfileId
        /// </summary>
        /// <param name="userProfileId">UserProfileId</param>
        /// <returns>DataSet</returns>
        DataSet GetOfferDetailsByUserProfileId(long userProfileId);

        /// <summary>
        /// ManageOfferDetails
        /// </summary>
        /// <param name="offerDetailsId">offerDetailsId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="offerStartDate">offerStartDate</param>
        /// <param name="offerEndDate">offerEndDate</param>
        /// <param name="offerDescription">offerDescription</param>
        /// <returns>DataSet</returns>
        DataSet ManageOfferDetails(long offerDetailsId, long userProfileId, DateTime offerStartDate, DateTime offerEndDate, string offerDescription);
    }
}
