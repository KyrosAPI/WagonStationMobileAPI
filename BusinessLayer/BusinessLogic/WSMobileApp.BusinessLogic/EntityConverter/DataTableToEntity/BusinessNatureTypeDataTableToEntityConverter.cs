using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using WSMobileApp.BusinessLogic.EntityConverter.Resource;
using WSMobileApp.BusinessModel.Collections;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.BusinessLogic.EntityConverter.DataTableToEntity
{
    public sealed class BusinessNatureTypeDataTableToEntityConverter
    {
        /// <summary>
        /// Converts the data table to business type collection.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static BusinessNatureTypeCollection ConvertDataTableToBusinessTypeCollection(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }
            var response = new BusinessNatureTypeCollection { Items = new List<BusinessNatureTypeEntity>() };
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
        private static BusinessNatureTypeEntity ConvertDataRowToBusinessTypeEntity(DataRow dataRow)
        {
            return new BusinessNatureTypeEntity
            {
                IsSuccess = true,
                BusinessNatureTypeId = dataRow[EntityConverterResource.BusinessNatureTypeId] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[EntityConverterResource.BusinessNatureTypeId], CultureInfo.InvariantCulture),
                BusinessNatureTypeCode = dataRow[EntityConverterResource.BusinessNatureTypeCode] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.BusinessNatureTypeCode], CultureInfo.InvariantCulture),
                BusinessNatureTypeDescription = dataRow[EntityConverterResource.BusinessNatureTypeDescription] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.BusinessNatureTypeDescription], CultureInfo.InvariantCulture)
            };
        }

        #endregion
    }
}
