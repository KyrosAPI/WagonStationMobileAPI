
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using WSMobileApp.BusinessLogic.EntityConverter.DataTableToEntity;
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;
using WSMobileApp.DataProcess.DealerProfile;

namespace WSMobileApp.Common.DealerProfile
{
    public sealed class OfferDetailsLogic : IOfferDetailsLogic
    {
        /// <summary>
        /// DeleteOfferDetails
        /// </summary>
        /// <param name="offerDetailsId">offerDetailsId</param>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>OfferDetailsCollection</returns>
        public OfferDetailsCollection DeleteOfferDetails(long offerDetailsId, long userProfileId)
        {
            return ConvertDataSetToOfferDetailsCollection(InitializeOfferDetailsDataProcess.DeleteOfferDetails(offerDetailsId, userProfileId));
        }

        /// <summary>
        /// GetOfferDetailsByDealerProfileId
        /// </summary>
        /// <param name="dealerProfileId">dealerProfileId</param>
        /// <param name="currentDate">The current date.</param>
        /// <returns>
        /// OfferDetailsCollection
        /// </returns>
        public OfferDetailsCollection GetOfferDetailsByDealerProfileId(long dealerProfileId,DateTime currentDate)
        {
            return ConvertDataSetToOfferDetailsCollection(InitializeOfferDetailsDataProcess.GetOfferDetailsByDealerProfileId(dealerProfileId,currentDate));
        }

        /// <summary>
        /// GetOfferDetailsById
        /// </summary>
        /// <param name="offerDetailsId">offerDetailsId</param>
        /// <returns>OfferDetailsEntity</returns>
        public OfferDetailsEntity GetOfferDetailsById(long offerDetailsId)
        {
            try
            {
                var response = ConvertDataSetToOfferDetailsCollection(InitializeOfferDetailsDataProcess.GetOfferDetailsById(offerDetailsId));

                return response == null ? null : response.Items.FirstOrDefault();
            }
            catch (Exception exception)
            {
                return ConvertExceptionToOfferDeailsEntity(exception);
            }
        }

        /// <summary>
        /// GetOfferDetailsByUserProfileId
        /// </summary>
        /// <param name="userProfileId">userProfileId</param>
        /// <returns>OfferDetailsCollection</returns>
        public OfferDetailsCollection GetOfferDetailsByUserProfileId(long userProfileId)
        {
            return ConvertDataSetToOfferDetailsCollection(InitializeOfferDetailsDataProcess.GetOfferDetailsByUserProfileId(userProfileId));
        }

        /// <summary>
        /// ManageOfferDetails
        /// </summary>
        /// <param name="offerDetailsEntity">The offer details entity.</param>
        /// <returns>
        /// OfferDetailsCollection
        /// </returns>
        public OfferDetailsCollection ManageOfferDetails(OfferDetailsEntity offerDetailsEntity)
        {
            return ConvertDataSetToOfferDetailsCollection(InitializeOfferDetailsDataProcess.ManageOfferDetails(offerDetailsEntity.OfferDetailsId, offerDetailsEntity.UserProfileId, Convert.ToDateTime(offerDetailsEntity.StartDate, CultureInfo.InvariantCulture), Convert.ToDateTime(offerDetailsEntity.EndDate, CultureInfo.InvariantCulture), offerDetailsEntity.OfferDescription));
        }

        #region Initializers

        /// <summary>
        /// initialize offer details data process
        /// </summary>
        private IOfferDetailsDataProcess _initializeOfferDetailsDataProcess;

        /// <summary>
        /// initialize offer details data process
        /// </summary>
        private IOfferDetailsDataProcess InitializeOfferDetailsDataProcess
        {
            get
            {
                return _initializeOfferDetailsDataProcess ?? (_initializeOfferDetailsDataProcess = new OfferDetailsDataProcess());
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// ConvertDataSetToOfferDetailsCollection
        /// </summary>
        /// <param name="dataSet">dataSet</param>
        /// <returns>OfferDetailsCollection</returns>
        private static OfferDetailsCollection ConvertDataSetToOfferDetailsCollection(DataSet dataSet)
        {
            return dataSet == null
                       ? null
                       : (dataSet.Tables[0] == null
                       ? null
                       : (dataSet.Tables[0].Rows.Count <= 0
                       ? null
                       : OfferDetailsDataTableToEntityConverter.ConvertDataTableToOfferDetailsCollection(dataSet.Tables[0])));
        }

        /// <summary>
        /// ConvertExceptionToOfferDeailsEntity
        /// </summary>
        /// <param name="exception">exception</param>
        /// <returns>OfferDetailsEntity</returns>
        private static OfferDetailsEntity ConvertExceptionToOfferDeailsEntity(Exception exception)
        {
            return exception.InnerException == null ? new OfferDetailsEntity { IsSuccess = false, Message = exception.Message } : new OfferDetailsEntity { IsSuccess = false, Message = exception.InnerException.Message };
        }

        #endregion

    }
}
