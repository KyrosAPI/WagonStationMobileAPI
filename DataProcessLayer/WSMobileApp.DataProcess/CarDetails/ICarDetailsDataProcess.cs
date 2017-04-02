
using System.Data;

namespace WSMobileApp.DataProcess.CarDetails
{
    public interface ICarDetailsDataProcess
    {
        /// <summary>
        /// ManageCarDetails
        /// </summary>
        /// <param name="carDetailsId">carDetailsId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="carName">carName</param>
        /// <param name="carMakeYear">carMakeYear</param>
        /// <param name="carNumber">carNumber</param>
        /// <param name="attachmentId">attachmentId</param>
        /// <param name="carModelName">CarModelName</param>
        /// <param name="carDisplayName">Display name of the car.</param>
        /// <param name="trackingId">The tracking identifier.</param>
        /// <returns>
        /// DataSet
        /// </returns>
        DataSet ManageCarDetails(long carDetailsId, long userProfileId, string carName, int carMakeYear, string carNumber, long attachmentId,string carModelName, string carDisplayName, string trackingId);

        /// <summary>
        /// DeleteCarDetailsById
        /// </summary>
        /// <param name="carDetailsId">carDetailsId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>DataSet</returns>
        DataSet DeleteCarDetailsById(long carDetailsId, long userProfileId);

        /// <summary>
        /// GetCarDetailsById
        /// </summary>
        /// <param name="carDetailsId">carDetailsId</param>
        /// <returns>DataSet</returns>
        DataSet GetCarDetailsById(long carDetailsId);

        /// <summary>
        /// GetCarDetailsByUserProfileId
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>DataSet</returns>
        DataSet GetCarDetailsByUserProfileId(long userProfileId);
    }
}
