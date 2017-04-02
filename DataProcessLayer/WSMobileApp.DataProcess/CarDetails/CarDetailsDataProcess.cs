
using System.Collections.Generic;
using System.Data;
using WSMobileApp.DataAccessLayer;
using WSMobileApp.DataProcess.Resource;

namespace WSMobileApp.DataProcess.CarDetails
{
    public sealed class CarDetailsDataProcess : ICarDetailsDataProcess
    {
        #region Implementation of ICarDetailsDataProcess

        /// <summary>
        /// ManageCarDetails
        /// </summary>
        /// <param name="carDetailsId">carDetailsId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <param name="carName">carName</param>
        /// <param name="carMakeYear">carMakeYear</param>
        /// <param name="carNumber">carNumber</param>
        /// <param name="attachmentId">attachmentId</param>
        /// <param name="carModelName">carModelName</param>
        /// <param name="carDisplayName">Display name of the car.</param>
        /// <param name="trackingId">The tracking identifier.</param>
        /// <returns>
        /// DataSet
        /// </returns>
        public DataSet ManageCarDetails(long carDetailsId, long userProfileId, string carName, int carMakeYear, string carNumber, long attachmentId, string carModelName, string carDisplayName, string trackingId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_ManageCarDetails, new Dictionary<string, object>
                                                                                                     {
                                                                                                         {DataProcessResource.spparam_cardetailsid,carDetailsId},
                                                                                                         {DataProcessResource.spparam_UserProfileId,userProfileId},
                                                                                                         {DataProcessResource.spparam_carname,carName},
                                                                                                         {DataProcessResource.spparam_carmakeyear,carMakeYear},
                                                                                                         {DataProcessResource.spparam_carnumber,carNumber},
                                                                                                         {DataProcessResource.spparam_AttachmentId,attachmentId},
                                                                                                         {DataProcessResource.spparam_CarModelName,carModelName},
                                                                                                         {DataProcessResource.spparam_CarDisplayName,carDisplayName},
                                                                                                         {DataProcessResource.spparam_CarTrackingId,trackingId}
                                                                                                     });
        }

        /// <summary>
        /// DeleteCarDetailsById
        /// </summary>
        /// <param name="carDetailsId">carDetailsId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>DataSet</returns>
        public DataSet DeleteCarDetailsById(long carDetailsId, long userProfileId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_DeleteCardetailsbyId, new Dictionary<string, object>
                                                                                                         {
                                                                                                             {DataProcessResource.spparam_cardetailsid,carDetailsId},
                                                                                                             {DataProcessResource.spparam_UserProfileId,userProfileId}                  
                                                                                                         });
        }

        /// <summary>
        /// GetCarDetailsById
        /// </summary>
        /// <param name="carDetailsId">carDetailsId</param>
        /// <returns>DataSet</returns>
        public DataSet GetCarDetailsById(long carDetailsId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_GetCarDetailsbyId, new Dictionary<string, object>
                                                                                                      {
                                                                                                          {DataProcessResource.spparam_cardetailsid,carDetailsId}   
                                                                                                      });
        }

        /// <summary>
        /// GetCarDetailsByUserProfileId
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>DataSet</returns>
        public DataSet GetCarDetailsByUserProfileId(long userProfileId)
        {
            return InitializeDataAccess.ExecuteDataSet(DataProcessResource.usp_GetCarDetailsbyUserprofileId, new Dictionary<string, object>
                                                                                                                {
                                                                                                                    {DataProcessResource.spparam_UserProfileId,userProfileId}
                                                                                                                });
        }

        #endregion

        #region Initializers

        /// <summary>
        /// _initializeDataAccess
        /// </summary>
        private IDataAccess _initializeDataAccess;

        /// <summary>
        /// InitializeDataAccess
        /// </summary>
        private IDataAccess InitializeDataAccess
        {
            get { return _initializeDataAccess ?? (_initializeDataAccess = new DataAccess()); }
        }

        #endregion
    }
}
