using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;

namespace AzureConstructionsProgressTracker.Features.ProgressTracking
{
    public class FilesStorageService
    {
        private const string ContainerName = "constructionprogressfiles";
        
        public async Task<string> UploadFile(string fileName, HttpPostedFileBase file)
        {
            // TODO: 
            // https://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-how-to-use-blobs/#programmatically-access-blob-storage
            // - Add proper nuget
            // - Connect to storage
            // - create container
            // - upload blob
            // - return URL

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse( ConfigurationManager.AppSettings["StorageConnectionString"]);

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");


            CloudBlockBlob blockBlob = container.GetBlockBlobReference("myblob");

            // Create or overwrite the "myblob" blob with contents from a local file.

             blockBlob.UploadFromStream(file.InputStream);
  


            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse( 
            //    CloudConfigurationManager.GetSetting("DefaultEndpointsProtocol=https;AccountName=fpstorage1;AccountKey=ZDEh3F4G5zI/M7QWn5yhXP6cGNqjFJ823OF1S7ML0+hZxy7KZhuAxX1vTA65v0Q4pDF/9UrNigKpp5POttBGrg=="));
        }
    }
}