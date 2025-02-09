using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace project_dotNet.aws_s3
{
    public class UploadFileToS3
    {

        private const string bucketName = "bt-course-bucket-4";
        //private const string keyName = "test";
        private const string filePath = "C:\\projects\\2.course\\Data&Analytics\\Data Files\\data-01-06-2024.csv";
        // Specify your bucket region (an example region is shown).
        private static readonly Amazon.RegionEndpoint bucketRegion = RegionEndpoint.APSoutheast2;
        private static IAmazonS3 s3Client;

        public async Task UploadFileAsync()
        {
            try
            {
                s3Client = new AmazonS3Client(bucketRegion);
                var fileTransferUtility = new TransferUtility(s3Client);

                // Option 1. Upload a file. The file name is used as the object key name.
                await fileTransferUtility.UploadAsync(filePath, bucketName);
                Console.WriteLine("Upload 1 completed");


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