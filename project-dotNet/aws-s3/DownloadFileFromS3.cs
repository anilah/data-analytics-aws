using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace project_dotNet.aws_s3
{
    public class DownloadFileFromS3
    {

        private const string bucketName = "bt-course-bucket-4";
        private const string objectKey = "data-01-06-2024.csv";
        private const string filePath = "C:\\users\\sange\\downloads\\ak-data-01-06-2024.csv";
        // Specify your bucket region (an example region is shown).
        private static readonly Amazon.RegionEndpoint bucketRegion = RegionEndpoint.APSoutheast2;
        private static IAmazonS3 s3Client;

        public async Task DownloadFileAsync()
        {
            try
            {
                s3Client = new AmazonS3Client(bucketRegion);
                var request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = objectKey
                };


                using (var response = await s3Client.GetObjectAsync(request))
                {
                    await using (var responseStream = response.ResponseStream)
                    await using (var fileStream = File.Create(filePath))
                    {
                        await responseStream.CopyToAsync(fileStream);
                    }

                    Console.WriteLine($"File '{objectKey}' downloaded successfully to '{filePath}'.");
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