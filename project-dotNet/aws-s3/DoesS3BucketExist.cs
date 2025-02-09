using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace project_dotNet.aws_s3
{
    public class DoesS3BucketExist
    {

        private const string bucketName = "bt-course-bucket-4";
        //private const string keyName = "test";
        //private const string filePath = "C:\\projects\\2.course\\Data&Analytics\\Data Files\\data-01-06-2024.csv";
        // Specify your bucket region (an example region is shown).
        private static readonly Amazon.RegionEndpoint bucketRegion = RegionEndpoint.APSoutheast2;
        private static IAmazonS3 s3Client;

        public async Task DoesBucketExists()
        {
            try
            {
                s3Client = new AmazonS3Client(bucketRegion);
                var bucketLocReq = new GetBucketLocationRequest
                {
                    BucketName = bucketName
                };
                var bucketExist = await s3Client.GetBucketLocationAsync(bucketLocReq);

                if (System.Net.HttpStatusCode.OK == bucketExist.HttpStatusCode)
                {
                    Console.WriteLine("Bucket Exists");
                }

                
            }
            catch (AmazonS3Exception e)
            {
                if (System.Net.HttpStatusCode.NotFound == e.StatusCode)
                {
                    Console.WriteLine("Bucket Does not Exist");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }

        }
    }
}