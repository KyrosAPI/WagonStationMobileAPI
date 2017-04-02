using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.UI;
using WSMobileApp.BusinessModel.Entities;

namespace WSMobileApp.UnitTest.ManageProfilePicture
{
    public partial class Test : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            try
            {
                byte[] fileToSend = null;
                string name = "";

                if (fuTest.HasFile)
                {
                    name = fuTest.FileName;
                    Stream stream = fuTest.FileContent;
                    stream.Seek(0, SeekOrigin.Begin);
                    fileToSend = new byte[stream.Length];
                    int count = 0;
                    while (count < stream.Length)
                    {
                        fileToSend[count++] = Convert.ToByte(stream.ReadByte());
                    }

                }
                //Here provide your service location url in below line. You need to host your service on server(IIS or which one you prefer)
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create
                               ("http://wsmobileapplication.azurewebsites.net//WagonStationService.svc/ManageShopPictureStream?fileName=" + fuTest.PostedFile.FileName);

                req.Method = "POST";
                req.ContentType = "application/octet-stream";
                req.ContentLength = fileToSend.Length;
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(fileToSend, 0, fileToSend.Length);
                reqStream.Close();

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                StreamReader reader = new StreamReader(resp.GetResponseStream());

                string result = reader.ReadToEnd();
            }
            catch (Exception ex)
            {

                throw ex;
            }  
        }
    }
}