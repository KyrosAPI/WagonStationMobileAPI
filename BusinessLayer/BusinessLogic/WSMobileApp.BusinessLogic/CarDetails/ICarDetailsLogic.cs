
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.Common.CarDetails
{
    public interface ICarDetailsLogic
    {
        /// <summary>
        /// ManageCarDetails
        /// </summary>
        /// <param name="carDetailsEntity">The car details entity.</param>
        /// <returns>
        /// CarDetailsCollection
        /// </returns>
        CarDetailsCollection ManageCarDetails(CarDetailsEntity carDetailsEntity);

        /// <summary>
        /// DeleteCarDetailsById
        /// </summary>
        /// <param name="carDetailsId">carDetailsId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>CarDetailsCollection</returns>
        CarDetailsCollection DeleteCarDetailsById(long carDetailsId, long userProfileId);

        /// <summary>
        /// GetCarDetailsById
        /// </summary>
        /// <param name="carDetailsId">carDetailsId</param>
        /// <returns>CarDetailsEntity</returns>
        CarDetailsEntity GetCarDetailsById(long carDetailsId);

        /// <summary>
        /// GetCarDetailsByUserProfileId
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>CarDetailsCollection</returns>
        CarDetailsCollection GetCarDetailsByUserProfileId(long userProfileId);
    }
}
