using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_dotNet.aws_s3
{
    public class ListS3ObjectAllVersion
    {
        private const string bucketName = "bt-course-bucket-4";
        private const string objectKey = "data-01-06-2024.csv";
        private static readonly Amazon.RegionEndpoint bucketRegion = RegionEndpoint.APSoutheast2;
        private static IAmazonS3 s3Client;


        public async Task listObjectAllVersion()
        {
            s3Client = new AmazonS3Client(bucketRegion);
            var result = new List<S3Object>();

            var request = new ListVersionsRequest
            {
                BucketName = bucketName,
                Prefix = objectKey
            };

            var response = await s3Client.ListVersionsAsync(request);

            if (response.Versions.Count > 0)
            {
                Console.WriteLine($"Versions of '{objectKey}':");
                foreach (var version in response.Versions)
                {
                    Console.WriteLine($"Version ID: {version.VersionId}, Last Modified: {version.LastModified}, Is Latest: {version.IsLatest}");
                }
            }
            else
            {
                Console.WriteLine($"No versions found for '{objectKey}' in bucket '{bucketName}'.");
            }


        }


    }
}
