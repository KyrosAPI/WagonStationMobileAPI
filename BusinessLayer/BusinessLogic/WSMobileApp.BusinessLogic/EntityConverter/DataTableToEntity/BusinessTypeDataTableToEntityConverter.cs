using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using WSMobileApp.BusinessLogic.EntityConverter.Resource;
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.BusinessLogic.EntityConverter.DataTableToEntity
{
    public sealed class BusinessTypeDataTableToEntityConverter
    {
        /// <summary>
        /// Converts the data table to business type collection.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static BusinessTypeCollection ConvertDataTableToBusinessTypeCollection(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }
            var response = new BusinessTypeCollection { Items = new List<BusinessTypeEntity>() };
            foreach (DataRow dataRow in dataTable.Rows)
            {
                response.Items.Add(ConvertDataRowToBusinessTypeEntity(dataRow));
            }

            return response;
        }

        #region Private Methods

        /// <summary>
        /// Converts the data row to business type entity.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <returns></returns>
        private static BusinessTypeEntity ConvertDataRowToBusinessTypeEntity(DataRow dataRow)
        {
            return new BusinessTypeEntity
                       {
                           IsSuccess = true,
                           BusinessTypeId = dataRow[EntityConverterResource.BusinessTypeId] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[EntityConverterResource.BusinessTypeId], CultureInfo.InvariantCulture),
                           BusinessTypeCode = dataRow[EntityConverterResource.BusinessTypeCode] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.BusinessTypeCode], CultureInfo.InvariantCulture),
                           BusinessTypeDescription = dataRow[EntityConverterResource.BusinessTypeDescription] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.BusinessTypeDescription], CultureInfo.InvariantCulture)
                       };
        }

        #endregion
    }
}
