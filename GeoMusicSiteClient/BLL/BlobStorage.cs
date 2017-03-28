using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types

namespace GeoMusicSiteClient.BLL
{
    public class BlobStorage
    {

        public string StorageImageCategory(HttpPostedFileBase image)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("categoryimages");

            // Create the container if it doesn't already exist.
            container.CreateIfNotExists();

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(image.FileName);

            blockBlob.UploadFromStream(image.InputStream);
            return blockBlob.Uri.ToString();
        }
        public string StorageImageRecord(HttpPostedFileBase image)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("recordimages");

            // Create the container if it doesn't already exist.
            container.CreateIfNotExists();

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(image.FileName);

            blockBlob.UploadFromStream(image.InputStream);
            return blockBlob.Uri.ToString();
        }

        public string StorageImagePlaylist(HttpPostedFileBase image)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("playlistimages");

            // Create the container if it doesn't already exist.
            container.CreateIfNotExists();

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(image.FileName);

            blockBlob.UploadFromStream(image.InputStream);
            return blockBlob.Uri.ToString();
        }



    }
}