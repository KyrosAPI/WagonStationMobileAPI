using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using GoogleMaps.LocationServices;
using RestSharp.Extensions.MonoHttp;

namespace WSMobileApp.Common.GeoCodeGenerator
{
    public sealed class GeoCoder : IGeoCoder
    {
        /// <summary>
        /// The service URI
        /// </summary>
        private const string ServiceUri = "http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false";

        private const string ApiKey = "AIzaSyBPn76PhPY3Nz5Ub2gcRe1_j0ZPBHsa190";

        private const string BingMasterKey = "AqkwWWKFU-Cg7MZsD3VYMxnQAiC9jh1tfmsJYj-NpbmiqeSHE4lzKE3nO_WtDT6S";

        private const string BingQueryKey = "AmcOucTJ_0WF9Z2c4DfkZyk6TCqHf7uWpnxJEFdzOS4eOnrXZyRb7ultk3p3kpHB";


        #region Implementation of IGeoCoder

        /// <summary>
        /// Geoes the code.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">address</exception>
        public Coordinates GeoCode(string address)
        {
            try
            {

                //to Read the Stream
                StreamReader sr = null;

                var url = string.Format("https://maps.googleapis.com/maps/api/place/textsearch/xml?query=" + HttpContext.Current.Server.UrlEncode(address) + "&key=AIzaSyDn_WyEYdQsD55lI-4o0u_xM6SWHG0DnKU");

                //to Send the request to Web Client 
                using (var wc = new WebClient())
                {
                    try
                    {
                        sr = new StreamReader(wc.OpenRead(url));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("The Error Occured" + ex.Message);
                    }

                    try
                    {
                        XmlTextReader xmlReader = new XmlTextReader(sr);
                        bool latread = false;
                        bool longread = false;
                        double latitude = 0;
                        double longitude = 0;

                        while (xmlReader.Read())
                        {
                            xmlReader.MoveToElement();
                            switch (xmlReader.Name)
                            {
                                case "lat":

                                    if (!latread)
                                    {
                                        xmlReader.Read();
                                        latitude = Convert.ToDouble(xmlReader.Value.ToString(), CultureInfo.InvariantCulture);
                                        latread = true;

                                    }
                                    break;
                                case "lng":
                                    if (!longread)
                                    {
                                        xmlReader.Read();
                                        longitude = Convert.ToDouble(xmlReader.Value.ToString(), CultureInfo.InvariantCulture);
                                        longread = true;
                                    }

                                    break;
                            }
                        }

                        return new Coordinates(latitude, longitude);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("An Error Occured" + ex.Message);
                    }
                }



            }
            catch (WebException ex)
            {
                throw ex;

            }

            return null;
        }

        #endregion

        double ParseUS(string value)
        {
            return Double.Parse(value, new CultureInfo("en-US"));
        }


        /// <summary>
        /// Finds the latitude longitude.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        public Coordinates FindLatitudeLongitude(string address)
        {
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(address);

            return point != null ? new Coordinates(point.Latitude, point.Longitude) : null;
        }
    }


}
