
namespace WSMobileApp.Common.GeoCodeGenerator
{

    public interface IGeoCoder
    {
        /// <summary>
        /// Geoes the code.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        Coordinates GeoCode(string address);

        /// <summary>
        /// Finds the latitude longitude.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        Coordinates FindLatitudeLongitude(string address);
    }
}
