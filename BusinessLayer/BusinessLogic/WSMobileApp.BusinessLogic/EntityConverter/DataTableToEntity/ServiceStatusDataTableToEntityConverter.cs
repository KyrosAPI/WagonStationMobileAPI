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
    public sealed class ServiceStatusDataTableToEntityConverter
    {
        /// <summary>
        /// Converts the data table to service status entity.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static ServiceStatusEntity ConvertDataTableToServiceStatusEntity(DataTable dataTable)
        {
            return dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0 ? null : (from DataRow dataRow in dataTable.Rows select ConvertDataRowToServiceStatusEntity(dataRow)).FirstOrDefault();
        }

        /// <summary>
        /// Converts the data table to service status collection.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static ServiceStatusCollection ConvertDataTableToServiceStatusCollection(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }

            var response = new ServiceStatusCollection {Items = new List<ServiceStatusEntity>()};
            foreach (DataRow dataRow in dataTable.Rows)
            {
                response.Items.Add(ConvertDataRowToServiceStatusEntity(dataRow));
            }

            return response;    
        }

        #region Private Methods

        /// <summary>
        /// Converts the data row to service status entity.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <returns></returns>
        private static ServiceStatusEntity ConvertDataRowToServiceStatusEntity(DataRow dataRow)
        {
            return new ServiceStatusEntity
                                          {
                                              ServiceRequestId = dataRow[EntityConverterResource.ServiceRequestId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.ServiceRequestId], CultureInfo.InvariantCulture),
                                              ServiceStatusId = dataRow[EntityConverterResource.ServiceStatusId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.ServiceStatusId], CultureInfo.InvariantCulture),
                                              ServiceStatusTypeCode = dataRow[EntityConverterResource.ServiceStatusTypeCode] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.ServiceStatusTypeCode], CultureInfo.InvariantCulture),
                                              ServiceStatusTypeDescription = dataRow[EntityConverterResource.ServiceStatusTypeDescription] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.ServiceStatusTypeDescription], CultureInfo.InvariantCulture),
                                              ServiceStatusTypeId = dataRow[EntityConverterResource.ServiceStatusTypeId] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[EntityConverterResource.ServiceStatusTypeId], CultureInfo.InvariantCulture),
                                              IsSuccess = true,
                                              StatusUpdatedOn = dataRow[EntityConverterResource.StatusUpdatedOn] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow[EntityConverterResource.StatusUpdatedOn], CultureInfo.InvariantCulture)
                                          };
        }

        #endregion
    }
}
