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
    public sealed class CarDetailsDataTableToEntityConverter
    {
        /// <summary>
        /// Converts the data table to car details entity.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static CarDetailsEntity ConvertDataTableToCarDetailsEntity(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }

            return (from DataRow dataRow in dataTable.Rows select ConvertDataRowToCarDetailsEntity(dataRow)).FirstOrDefault();
        }

        /// <summary>
        /// Converts the data table to car details collection.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public static CarDetailsCollection ConvertDataTableToCarDetailsCollection(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }

            var response = new CarDetailsCollection {Items = new List<CarDetailsEntity>()};
            foreach (DataRow dataRow in dataTable.Rows)
            {
                response.Items.Add(ConvertDataRowToCarDetailsEntity(dataRow));
            }

            return response;    
        }

        #region Private Methods

        /// <summary>
        /// Converts the data row to car details entity.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <returns></returns>
        private static CarDetailsEntity ConvertDataRowToCarDetailsEntity(DataRow dataRow)
        {
            return new CarDetailsEntity
                       {
                           IsSuccess = true,
                           CarDetailsId = dataRow[EntityConverterResource.CarDetailsid] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.CarDetailsid],CultureInfo.InvariantCulture),
                           CarName =  dataRow[EntityConverterResource.carname] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.carname],CultureInfo.InvariantCulture),
                           CarModelName = dataRow[EntityConverterResource.CarModelName] == DBNull.Value ?string.Empty : Convert.ToString(dataRow[EntityConverterResource.CarModelName],CultureInfo.InvariantCulture),
                           NumberPlate = dataRow[EntityConverterResource.NumberPlate] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.NumberPlate],CultureInfo.InvariantCulture),
                           CarMakeYear = dataRow[EntityConverterResource.carmakeyear] == DBNull.Value ? 0 : Convert.ToInt32(dataRow[EntityConverterResource.carmakeyear],CultureInfo.InvariantCulture),
                           CarPicture = new AttachmentEntity
                                            {
                                                IsSuccess = true,
                                                AttachmentId = dataRow[EntityConverterResource.CarPictureAttachmentId] == DBNull.Value ? 0 : Convert.ToInt64(dataRow[EntityConverterResource.CarPictureAttachmentId],CultureInfo.InvariantCulture),
                                                FileSource = dataRow[EntityConverterResource.CarPictureFileSource] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.CarPictureFileSource],CultureInfo.InvariantCulture),
                                                FileUploadedOn = dataRow[EntityConverterResource.CarPictureUploadedOn] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow[EntityConverterResource.CarPictureUploadedOn],CultureInfo.InvariantCulture),
                                                FileName = dataRow[EntityConverterResource.CarPictureFileName] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.CarPictureFileName],CultureInfo.InvariantCulture),
                                                ContentType = dataRow[EntityConverterResource.CarPictureContentType] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.CarPictureContentType], CultureInfo.InvariantCulture),
                                                //FileBinary = dataRow[EntityConverterResource.CarPictureFileBinary] == DBNull.Value ? null : (byte[])(dataRow[EntityConverterResource.CarPictureFileBinary]),
                                                //FileBinaryInString = dataRow[EntityConverterResource.CarPictureFileBinary] == DBNull.Value ? string.Empty : Encoding.ASCII.GetString((byte[])dataRow[EntityConverterResource.CarPictureFileBinary]),
                                            },
                          CarDisplayName = dataRow[EntityConverterResource.CarDisplayName] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.CarDisplayName],CultureInfo.InvariantCulture),
                          TrackingId = dataRow[EntityConverterResource.CarTrackingId] == DBNull.Value ? string.Empty : Convert.ToString(dataRow[EntityConverterResource.CarTrackingId],CultureInfo.InvariantCulture)
                       };
        }

        #endregion
    }
}
