using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace project_dotNet.aws_s3
{
    public class DeleteFileFromS3
    {

        private const string bucketName = "bt-course-bucket-4";
        private const string keyName = "data-01-06-2024.csv";
        private static readonly Amazon.RegionEndpoint bucketRegion = RegionEndpoint.APSoutheast2;
        private static IAmazonS3 s3Client;

        public async Task DeleteFileAsync()
        {
            try
            {
                s3Client = new AmazonS3Client(bucketRegion);
                var fileTransferUtility = new TransferUtility(s3Client);

                
                    var deleteObjectRequest = new DeleteObjectRequest
                    {
                        BucketName = bucketName,
                        Key = keyName
                    };

                    Console.WriteLine("Deleting an object");
               DeleteObjectResponse del= await s3Client.DeleteObjectAsync(deleteObjectRequest);
               Console.WriteLine("Deleted successfully.....?"+del.DeleteMarker);
              




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