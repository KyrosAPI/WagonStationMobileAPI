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
    public class DealerRatingsDataTableToEntityConverter
    {
        /// <summary>
        /// Converts the data table to dealer ratings entity.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static DealerRatingsEntity ConvertDataTableToDealerRatingsEntity(DataTable dataTable)
        {
            return dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0 ? null
                       : (from DataRow dataRow in dataTable.Rows select ConvertDataRowToDealerRatingsEntity(dataRow)).FirstOrDefault();
        }

        /// <summary>
        /// Converts the data table to dealer ratings collection.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static DealerRatingsCollection ConvertDataTableToDealerRatingsCollection(DataTable dataTable)
        {
            if (dataTable==null || dataTable.Rows == null || dataTable.Rows.Count <= 0 )
            {
                return null;
            }

            var response = new DealerRatingsCollection {Items = new List<DealerRatingsEntity>()};
            foreach (DataRow dataRow in dataTable.Rows)
            {
                response.Items.Add(ConvertDataRowToDealerRatingsEntity(dataRow));
            }

            return response;
        }

        #region Private Methods

        /// <summary>
        /// Converts the data row to dealer ratings entity.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <returns></returns>
        private static DealerRatingsEntity ConvertDataRowToDealerRatingsEntity(DataRow dataRow)
        {
            return new DealerRatingsEntity
                       {
                           DealerRatingsId = dataRow[EntityConverterResource.DealerRatingsId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.DealerRatingsId], CultureInfo.InvariantCulture),
                           DealerProfileId = dataRow[EntityConverterResource.DealerProfileId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.DealerProfileId], CultureInfo.InvariantCulture),
                           UserProfileId = dataRow[EntityConverterResource.RatedUserProfileId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.RatedUserProfileId], CultureInfo.InvariantCulture),
                           UserName = dataRow[EntityConverterResource.RatedUserName] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.RatedUserName],CultureInfo.InvariantCulture),
                           IsSuccess = true,
                           RatedOn = dataRow[EntityConverterResource.RatedOn] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow[EntityConverterResource.RatedOn], CultureInfo.InvariantCulture),
                           RatingDescription = dataRow[EntityConverterResource.RatingDescription] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.RatingDescription], CultureInfo.InvariantCulture),
                           Ratings = dataRow[EntityConverterResource.Rating] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[EntityConverterResource.Rating],CultureInfo.InvariantCulture)
                       };
        }

        #endregion
    }
}
