using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace project_dotNet.aws_s3
{
    public class PreSignedUrlforFiles
    {

        private const string bucketName = "bt-course-bucket-4";
        private const string keyName = "data-01-06-2024.csv";
        double timeoutDuration = 1;
        // Specify your bucket region (an example region is shown).
        private static readonly Amazon.RegionEndpoint bucketRegion = RegionEndpoint.APSoutheast2;
        private static IAmazonS3 s3Client;

        public async Task GetPreSignedUrlForS3Objects()
        {
            try
            {
                s3Client = new AmazonS3Client(bucketRegion);

                var request = new GetPreSignedUrlRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                    Expires = DateTime.UtcNow.AddMinutes(timeoutDuration)
                };

                string presignedUrl = s3Client.GetPreSignedURL(request);

                Console.WriteLine("Pre-Signed URL: " + presignedUrl);
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