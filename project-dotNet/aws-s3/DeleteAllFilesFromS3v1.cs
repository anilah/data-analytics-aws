using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace project_dotNet.aws_s3
{
    public class DeleteAllFilesFromS3v1
    {

        private const string bucketName = "bt-course-bucket-3";
        //private const string keyName = "data-01-06-2024.csv";
        private static readonly Amazon.RegionEndpoint bucketRegion = RegionEndpoint.APSoutheast2;
        private static IAmazonS3 s3Client;

        public async Task DeleteAllFiles()
        {
            try
            {
                s3Client = new AmazonS3Client(bucketRegion);
               
                    // List objects in the bucket
                    var listObjectsRequest = new ListObjectsV2Request
                    {
                        BucketName = bucketName
                    };

                    ListObjectsV2Response listObjectsResponse;

                    do
                    {
                        // Get the objects in the current page (S3 paginates results if there are too many objects)
                        listObjectsResponse = await s3Client.ListObjectsV2Async(listObjectsRequest);

                        // Delete the objects in the bucket
                        foreach (var s3Object in listObjectsResponse.S3Objects)
                        {
                            var deleteRequest = new DeleteObjectRequest
                            {
                                BucketName = bucketName,
                                Key = s3Object.Key
                            };

                            // Delete the object
                            var deleteResponse = await s3Client.DeleteObjectAsync(deleteRequest);

                            if (deleteResponse.HttpStatusCode == System.Net.HttpStatusCode.NoContent)
                            {
                                Console.WriteLine($"Successfully deleted: {s3Object.Key}");
                            }
                            else
                            {
                                Console.WriteLine($"Failed to delete: {s3Object.Key}");
                            }
                        }

                        // If there are more objects, continue to the next page
                        listObjectsRequest.ContinuationToken = listObjectsResponse.NextContinuationToken;

                    } while (listObjectsResponse.IsTruncated); // Continue listing if there are more objects

                }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when deleting an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when deleting an object", e.Message);
            }

        }
    }
}