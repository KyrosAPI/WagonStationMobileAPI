using System;
using System.Configuration;
using System.IO;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;


namespace WSMobileApp.Web.UI.BlobStorage
{
    public partial class BlobStorage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTest_OnClick(object sender, EventArgs e)
        {

            if (fuBlob.HasFile)
            {
                const int userProfileId = 100001;


                var cloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

                var blobClient = cloudStorageAccount.CreateCloudBlobClient();

                var profilePictureContainer = blobClient.GetContainerReference("");
                profilePictureContainer.CreateIfNotExists();

                profilePictureContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

                var shopPictureContainer = blobClient.GetContainerReference("shoppicture");
                shopPictureContainer.CreateIfNotExists();
                shopPictureContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

                var carPictureContainer = blobClient.GetContainerReference("carpicture");
                carPictureContainer.CreateIfNotExists();
                carPictureContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

                var servicePictureContainer = blobClient.GetContainerReference("servicepicture");
                servicePictureContainer.CreateIfNotExists();
                servicePictureContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

                var cloudBlockBlob = profilePictureContainer.GetBlockBlobReference(string.Format("{0}_{1}", userProfileId, fuBlob.PostedFile.FileName));

                var fileStream = fuBlob.FileContent;
                cloudBlockBlob.UploadFromStream(fileStream);
            }

        }

        protected void btnDownload_OnClick(object sender, EventArgs e)
        {
            const int userProfileId = 100025;

            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("profilepicture");

            // Retrieve reference to a blob named "myblob.txt"
            CloudBlockBlob blockBlob2 = container.GetBlockBlobReference(string.Format("{0}_{1}", userProfileId, "abc.png"));

            try
            {
                string text;
                using (var memoryStream = new MemoryStream())
                {
                    blockBlob2.DownloadToStream(memoryStream);
                    text = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void btnList_OnClick(object sender, EventArgs e)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("profilepicture");

            // Loop over items within the container and output the length and URI.
            foreach (IListBlobItem item in container.ListBlobs(null, false))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;

                    Console.WriteLine("Block blob of length {0}: {1}", blob.Properties.Length, blob.Uri);

                }
                else if (item.GetType() == typeof(CloudPageBlob))
                {
                    CloudPageBlob pageBlob = (CloudPageBlob)item;

                    Console.WriteLine("Page blob of length {0}: {1}", pageBlob.Properties.Length, pageBlob.Uri);

                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory directory = (CloudBlobDirectory)item;

                    Console.WriteLine("Directory: {0}", directory.Uri);
                }
            }

        }
    }
}