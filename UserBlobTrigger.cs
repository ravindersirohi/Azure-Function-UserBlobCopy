using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class UserBlobTrigger
    {
        [FunctionName("UserBlobTrigger")]
        public static void Run(
            [BlobTrigger("user-workitems/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob,
            [Blob("Outputuser-workitems/{name}", FileAccess.Write, Connection = "AzureWebJobsStorage")]Stream outputBlob, 
            string name, ILogger log)
        {
            var fileLength = myBlob.Length;
            myBlob.CopyTo(outputBlob);
        }
    }
}
