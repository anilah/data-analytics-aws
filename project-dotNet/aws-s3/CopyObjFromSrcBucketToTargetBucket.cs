using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace project_dotNet.aws_s3
{
    public class CopyObjFromSrcBucketToTargetBucket
    {

        private const string srcBucketName = "bt-course-bucket-3";
        private const string targetBucketName = "bt-course-bucket-4";
        //private const string keyName = "test";
        private const string filePath = "C:\\projects\\2.course\\Data&Analytics\\Data Files\\data-01-06-2024.csv";
        // Specify your bucket region (an example region is shown).
        private static readonly Amazon.RegionEndpoint bucketRegion = RegionEndpoint.APSoutheast2;
        private static IAmazonS3 s3Client;

        public async Task CopyObjFromSrcToTargetBucket()
        {
            try
            {
                s3Client = new AmazonS3Client(bucketRegion);

                // List objects in the source bucket
                var listObjectsRequest = new ListObjectsV2Request
                {
                    BucketName = srcBucketName
                };

                var listObjectsResponse = s3Client.ListObjectsV2Async(listObjectsRequest).Result;

                if (listObjectsResponse.S3Objects.Count == 0)
                {
                    Console.WriteLine("No objects found in source bucket.");
                    return;
                }


                // Iterate through objects and copy them to the destination bucket
                foreach (var s3Object in listObjectsResponse.S3Objects)
                {
                    string sourceKey = s3Object.Key;
                    string destinationKey = sourceKey; // You can modify the key if you want to change the file name

                    var copyRequest = new CopyObjectRequest
                    {
                        SourceBucket = srcBucketName,
                        SourceKey = sourceKey,
                        DestinationBucket = targetBucketName,
                        DestinationKey = destinationKey
                    };

                    // Copy the object
                    var copyResponse = s3Client.CopyObjectAsync(copyRequest).Result;

                    if (copyResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Console.WriteLine($"Successfully copied {sourceKey} to {targetBucketName}/{destinationKey}");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to copy {sourceKey}. Status: {copyResponse.HttpStatusCode}");
                    }
                }



            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }

        }
    }
}