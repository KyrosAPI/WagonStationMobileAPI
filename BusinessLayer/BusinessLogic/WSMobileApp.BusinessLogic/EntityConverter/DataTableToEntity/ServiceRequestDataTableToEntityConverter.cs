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
    public sealed class ServiceRequestDataTableToEntityConverter
    {
        /// <summary>
        /// Converts the data table to service request entity.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static ServiceRequestEntity ConvertDataTableToServiceRequestEntity(DataTable dataTable)
        {
            return dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0 ? null : (from DataRow dataRow in dataTable.Rows select ConvertDataRowToServiceRequestEntity(dataRow)).FirstOrDefault();
        }

        /// <summary>
        /// Converts the data table to service request collection.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static ServiceRequestCollection ConvertDataTableToServiceRequestCollection(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }

            var response = new ServiceRequestCollection { Items = new List<ServiceRequestEntity>() };
            foreach (DataRow dataRow in dataTable.Rows)
            {
                response.Items.Add(ConvertDataRowToServiceRequestEntity(dataRow));
            }

            return response;
        }

        #region Private Methods

        /// <summary>
        /// Converts the data row to service request entity.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <returns></returns>
        private static ServiceRequestEntity ConvertDataRowToServiceRequestEntity(DataRow dataRow)
        {
            return new ServiceRequestEntity
                               {
                                   ServiceRequestId = Convert.ToInt64(dataRow[EntityConverterResource.ServiceRequestId], CultureInfo.InvariantCulture),
                                   UserProfileId = Convert.ToInt64(dataRow[EntityConverterResource.UserProfileId], CultureInfo.InvariantCulture),
                                   DealerProfileId = Convert.ToInt64(dataRow[EntityConverterResource.DealerProfileId], CultureInfo.InvariantCulture),
                                   CarDetailsId = Convert.ToInt64(dataRow[EntityConverterResource.CarDetailsid], CultureInfo.InvariantCulture),
                                   ServiceRequestNo = dataRow[EntityConverterResource.ServiceRequestNo] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.ServiceRequestNo], CultureInfo.InvariantCulture),
                                   AppointmentDate = dataRow[EntityConverterResource.AppointmentDate] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow[EntityConverterResource.AppointmentDate], CultureInfo.InvariantCulture),
                                   AppointmentDateInString = dataRow[EntityConverterResource.AppointmentDate] == DBNull.Value ? string.Empty : Convert.ToDateTime(dataRow[EntityConverterResource.AppointmentDate], CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"),
                                   AppointmentTime = dataRow[EntityConverterResource.AppointmentTime] == DBNull.Value ? TimeSpan.MinValue : (TimeSpan)(dataRow[EntityConverterResource.AppointmentTime]),
                                   AppointmentTimeInString = dataRow[EntityConverterResource.AppointmentTime] == DBNull.Value ? string.Empty : new DateTime().Add((TimeSpan)(dataRow[EntityConverterResource.AppointmentTime])).ToString("hh:mm tt"),
                                   AppointmentAcceptedOn = dataRow[EntityConverterResource.AppointmentAcceptedOn] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow[EntityConverterResource.AppointmentAcceptedOn], CultureInfo.InvariantCulture),
                                   ServiceDeliveredOn = dataRow[EntityConverterResource.ServiceDeliveredOn] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow[EntityConverterResource.ServiceDeliveredOn], CultureInfo.InvariantCulture),
                                   IsPickupDropAvailable = dataRow[EntityConverterResource.IsPickupDropAvailable] != DBNull.Value && Convert.ToBoolean(dataRow[EntityConverterResource.IsPickupDropAvailable], CultureInfo.InvariantCulture),
                                   IsSuccess = true,
                                   IsReviewSubmitted = dataRow[EntityConverterResource.IsReviewSubmitted] != DBNull.Value && Convert.ToBoolean(dataRow[EntityConverterResource.IsReviewSubmitted], CultureInfo.InvariantCulture),
                                   CancelReason = dataRow[EntityConverterResource.CancelReason] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.CancelReason], CultureInfo.InvariantCulture)
                               };
        }

        #endregion
    }
}
