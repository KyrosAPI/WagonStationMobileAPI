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
    public sealed class AttachmentDataTableToEntityConverter
    {
        /// <summary>
        /// Converts the data table to attachment entity.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="isFromServiceAttachment">if set to <c>true</c> [is from service attachment].</param>
        /// <returns></returns>
        public static AttachmentEntity ConvertDataTableToAttachmentEntity(DataTable dataTable, bool isFromServiceAttachment = false)
        {
            if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }

            return (from DataRow dataRow in dataTable.Rows select ConvertDataRowToAttachmentEntity(dataRow, isFromServiceAttachment)).FirstOrDefault();
        }

        /// <summary>
        /// Converts the data table to attachment collection.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="isFromServiceAttachment">if set to <c>true</c> [is from service attachment].</param>
        /// <returns></returns>
        public static AttachmentCollection ConvertDataTableToAttachmentCollection(DataTable dataTable, bool isFromServiceAttachment = false)
        {
            if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }

            var response = new AttachmentCollection { Items = new List<AttachmentEntity>() };
            foreach (DataRow dataRow in dataTable.Rows)
            {
                response.Items.Add(ConvertDataRowToAttachmentEntity(dataRow, isFromServiceAttachment));
            }

            return response;
        }

        #region Private Methods

        /// <summary>
        /// Converts the data row to attachment collection.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <param name="isFromServiceAttachment">if set to <c>true</c> [is from service attachment].</param>
        /// <returns></returns>
        private static AttachmentEntity ConvertDataRowToAttachmentEntity(DataRow dataRow, bool isFromServiceAttachment)
        {
            var response = new AttachmentEntity
                 {
                     AttachmentId = dataRow[EntityConverterResource.AttachmentId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.AttachmentId], CultureInfo.InvariantCulture),
                     FileSource = dataRow[EntityConverterResource.FileSource] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.FileSource], CultureInfo.InvariantCulture),
                     FileUploadedOn = dataRow[EntityConverterResource.UploadedOn] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow[EntityConverterResource.UploadedOn], CultureInfo.InvariantCulture),
                     //FileBinary = dataRow[EntityConverterResource.FileBinary] == DBNull.Value ? null: (byte[]) dataRow[EntityConverterResource.FileBinary],
                     //FileBinaryInString = dataRow[EntityConverterResource.FileBinary] == DBNull.Value ? string.Empty : Encoding.ASCII.GetString((byte[])dataRow[EntityConverterResource.FileBinary]),
                     IsSuccess = true,
                 };

            if(isFromServiceAttachment)
            {
                response.ServiceRequestId = dataRow[EntityConverterResource.ServiceRequestId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.ServiceRequestId], CultureInfo.InvariantCulture);
            }

            return response;    
        }

        #endregion
    }
}
