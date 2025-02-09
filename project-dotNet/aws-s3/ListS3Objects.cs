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
    public class ListS3Objects
    {
        private const string bucketName = "bt-course-bucket-4";
        private static readonly Amazon.RegionEndpoint bucketRegion = RegionEndpoint.APSoutheast2;
        private static IAmazonS3 s3Client;


        public async Task listObjects()
        {
            s3Client = new AmazonS3Client(bucketRegion);
            var result = new List<S3Object>();
            ListObjectsV2Request request = new ListObjectsV2Request()
                {
                    BucketName = bucketName
                };

            Task<ListObjectsV2Response> response;
            do
            {
                 response = s3Client.ListObjectsV2Async(request);
                foreach (S3Object entry in response.Result.S3Objects)
                {
                    Console.WriteLine($"File: {entry.Key}, Size: {entry.Size}");
                }
             } while(null!=response.Result.NextContinuationToken);


        }


    }
}
