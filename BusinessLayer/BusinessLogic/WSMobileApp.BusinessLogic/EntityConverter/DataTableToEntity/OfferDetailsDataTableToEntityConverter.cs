using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using WSMobileApp.BusinessLogic.EntityConverter.Resource;
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.BusinessLogic.EntityConverter.DataTableToEntity
{
    public sealed class OfferDetailsDataTableToEntityConverter
    {
        /// <summary>
        /// Converts the data table to offer details entity.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static OfferDetailsEntity ConvertDataTableToOfferDetailsEntity(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }

            return (from DataRow dataRow in dataTable.Rows select ConvertDataRowToOfferDetailsEntity(dataRow)).FirstOrDefault();
        }

        /// <summary>
        /// Converts the data table to offer details collection.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static OfferDetailsCollection ConvertDataTableToOfferDetailsCollection(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }

            var response = new OfferDetailsCollection {Items = new List<OfferDetailsEntity>()};
            foreach (DataRow dataRow in dataTable.Rows)
            {
                response.Items.Add(ConvertDataRowToOfferDetailsEntity(dataRow));
            }

            return response;    
        }

        #region Private Methods
        
        private static OfferDetailsEntity ConvertDataRowToOfferDetailsEntity(DataRow dataRow)
        {
            return new OfferDetailsEntity
                       {
                           OfferDetailsId = dataRow[EntityConverterResource.OfferDetailsId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.OfferDetailsId], CultureInfo.InvariantCulture),
                           UserProfileId = dataRow[EntityConverterResource.UserProfileId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.UserProfileId], CultureInfo.InvariantCulture),
                           DealerProfileId = dataRow[EntityConverterResource.DealerProfileId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.DealerProfileId], CultureInfo.InvariantCulture),
                           IsSuccess = true,
                           OfferDescription = dataRow[EntityConverterResource.OfferDescription] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.OfferDescription], CultureInfo.InvariantCulture),
                           OfferStartDate = dataRow[EntityConverterResource.OfferStartDate] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow[EntityConverterResource.OfferStartDate], CultureInfo.InvariantCulture),
                           OfferEndDate = dataRow[EntityConverterResource.OfferEndDate] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow[EntityConverterResource.OfferEndDate], CultureInfo.InvariantCulture),
                           StartDate = dataRow[EntityConverterResource.OfferStartDate] == DBNull.Value ? string.Empty : Convert.ToDateTime(dataRow[EntityConverterResource.OfferStartDate], CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"),
                           EndDate = dataRow[EntityConverterResource.OfferEndDate] == DBNull.Value ? string.Empty : Convert.ToDateTime(dataRow[EntityConverterResource.OfferEndDate], CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                       };
        }

        #endregion
    }
}
