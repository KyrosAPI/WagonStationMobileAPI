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
   public sealed class ServiceDescriptionDataTableToEntityConverter
    {
        /// <summary>
        /// Converts the data table to service description entity.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
       public static ServiceDescriptionEntity ConvertDataTableToServiceDescriptionEntity(DataTable dataTable)
       {
           return dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0 ? null : (from DataRow dataRow in dataTable.Rows select ConvertDataRowToServiceDescriptionEntity(dataRow)).FirstOrDefault();
       }

       /// <summary>
       /// Converts the data table to service description collection.
       /// </summary>
       /// <param name="dataTable">The data table.</param>
       /// <returns></returns>
       public static ServiceDescriptionCollection ConvertDataTableToServiceDescriptionCollection(DataTable dataTable)
       {
           if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0)
           {
               return null;
           }

           var response = new ServiceDescriptionCollection {Items = new List<ServiceDescriptionEntity>()};
           foreach (DataRow dataRow in dataTable.Rows)
           {
               response.Items.Add(ConvertDataRowToServiceDescriptionEntity(dataRow));
           }

           return response;
       }

        #region Private Methods

       /// <summary>
       /// Converts the data row to service description entity.
       /// </summary>
       /// <param name="dataRow">The data row.</param>
       /// <returns></returns>
       private static ServiceDescriptionEntity ConvertDataRowToServiceDescriptionEntity(DataRow dataRow)
       {
           return new ServiceDescriptionEntity
                      {
                          ServiceDescriptionId = Convert.ToInt64(dataRow[EntityConverterResource.ServiceDescriptionId], CultureInfo.InvariantCulture),
                          ServiceRequestId = Convert.ToInt64(dataRow[EntityConverterResource.ServiceRequestId],CultureInfo.InvariantCulture),
                          ServiceDescriptionTypeId = Convert.ToInt32(dataRow[EntityConverterResource.ServiceDescriptionTypeId], CultureInfo.InvariantCulture),
                          ServiceDescriptionTypeCode = Convert.ToString(dataRow[EntityConverterResource.ServiceDescriptionTypeCode], CultureInfo.InvariantCulture),
                          ServiceDescriptionType = Convert.ToString(dataRow[EntityConverterResource.ServiceDescriptionType], CultureInfo.InvariantCulture),
                          ServiceDescription = Convert.ToString(dataRow[EntityConverterResource.ServiceDescription], CultureInfo.InvariantCulture),
                          IsSuccess = true
                      };
       }

        #endregion
    }
}
