using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WSMobileApp.BusinessLogic.EntityConverter.DataTableToEntity;
using WSMobileApp.BusinessLogic.EntityConverter.Resource;
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;
using WSMobileApp.Common.CarDetails;
using WSMobileApp.DataProcess.CarDetails;

namespace WSMobileApp.BusinessLogic.CarDetails
{
    public sealed class CarDetailsLogic : ICarDetailsLogic
    {
        #region Implementation of ICarDetailsLogic

        /// <summary>
        /// ManageCarDetails
        /// </summary>
        /// <param name="carDetailsEntity">The car details entity.</param>
        /// <returns>
        /// CarDetailsCollection
        /// </returns>
        public CarDetailsCollection ManageCarDetails(CarDetailsEntity carDetailsEntity)
        {
            try
            {
                return ConvertDataSetToCarDetailsCollection(InitializeCarDetailsDataProcess.ManageCarDetails(carDetailsEntity.CarDetailsId, carDetailsEntity.UserProfileId, carDetailsEntity.CarName, carDetailsEntity.CarMakeYear, carDetailsEntity.NumberPlate, carDetailsEntity.CarPicture == null ? 0 : carDetailsEntity.CarPicture.AttachmentId, carDetailsEntity.CarModelName, carDetailsEntity.CarDisplayName, carDetailsEntity.TrackingId));
            }
            catch (Exception exception)
            {
                return new CarDetailsCollection { Items = new List<CarDetailsEntity> { new CarDetailsEntity { IsSuccess = false, Message = exception.Message == "SQL_VALIDATION_ERROR_008" ? EntityConverterResource.SQL_VALIDATION_ERROR_008 : exception.InnerException != null ? exception.InnerException.Message : exception.Message } } };
            }
        }

        /// <summary>
        /// DeleteCarDetailsById
        /// </summary>
        /// <param name="carDetailsId">carDetailsId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>CarDetailsCollection</returns>
        public CarDetailsCollection DeleteCarDetailsById(long carDetailsId, long userProfileId)
        {
            try
            {
                return ConvertDataSetToCarDetailsCollection(InitializeCarDetailsDataProcess.DeleteCarDetailsById(carDetailsId, userProfileId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// GetCarDetailsById
        /// </summary>
        /// <param name="carDetailsId">carDetailsId</param>
        /// <returns>CarDetailsEntity</returns>
        public CarDetailsEntity GetCarDetailsById(long carDetailsId)
        {
            try
            {
                var response = ConvertDataSetToCarDetailsCollection(InitializeCarDetailsDataProcess.GetCarDetailsById(carDetailsId));
                return response == null ? null : response.Items == null ? null : response.Items.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// GetCarDetailsByUserProfileId
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>CarDetailsCollection</returns>
        public CarDetailsCollection GetCarDetailsByUserProfileId(long userProfileId)
        {
            try
            {
                return ConvertDataSetToCarDetailsCollection(InitializeCarDetailsDataProcess.GetCarDetailsByUserProfileId(userProfileId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Initializers

        /// <summary>
        /// The _initialize car details converter
        /// </summary>
        private CarDetailsDataTableToEntityConverter _initializeCarDetailsConverter;

        /// <summary>
        /// Gets the initialize car details converter.
        /// </summary>
        /// <value>
        /// The initialize car details converter.
        /// </value>
        private CarDetailsDataTableToEntityConverter InitializeCarDetailsConverter
        {
            get
            {
                return _initializeCarDetailsConverter ?? (_initializeCarDetailsConverter = new CarDetailsDataTableToEntityConverter());
            }
        }


        /// <summary>
        /// _initailizeCarDetailsDataProcess
        /// </summary>
        private ICarDetailsDataProcess _initailizeCarDetailsDataProcess;

        /// <summary>
        /// InitializeCarDetailsDataProcess
        /// </summary>
        private ICarDetailsDataProcess InitializeCarDetailsDataProcess
        {
            get
            {
                return _initailizeCarDetailsDataProcess ?? (_initailizeCarDetailsDataProcess = new CarDetailsDataProcess());
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// ConvertDataSetToCarDetailsCollection
        /// </summary>
        /// <param name="dataSet">dataSet</param>
        /// <returns>CarDetailsCollection</returns>
        private CarDetailsCollection ConvertDataSetToCarDetailsCollection(DataSet dataSet)
        {
            return dataSet == null ? null : (dataSet.Tables[0] == null ? null : (dataSet.Tables[0].Rows.Count <= 0 ? null : CarDetailsDataTableToEntityConverter.ConvertDataTableToCarDetailsCollection(dataSet.Tables[0])));
        }

        #endregion
    }
}
