using Amazon.S3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3.Transfer;
using System.IO;
using project_dotNet.aws_s3;

namespace WindowsService
{
    public static class Program
    {
        static void Main()
        {
            
            // 1. Example How to upload Files to S3
            UploadFileToS3 fileupload=new UploadFileToS3();
            fileupload.UploadFileAsync().Wait();

            // 2. Example How to List Files from S3 bucket
           // ListS3Objects listObject = new ListS3Objects();
            //listObject.listObjects();

            // 3. Example How to delete Files from S3 bucket
            DeleteFileFromS3 fileDelete = new DeleteFileFromS3();
            //fileDelete.DeleteFileAsync().Wait();


            // 4. Example How to Generate pre-signed url for S3 Objects
            //PreSignedUrlforFiles url = new PreSignedUrlforFiles();
            //url.GetPreSignedUrlForS3Objects().Wait();


            // 5. Example How to copy Files from S3 source bucket to Destination Bucket
                  // This Approach may not be right fit if Number of objects are large
                 
            //CopyObjFromSrcBucketToTargetBucket copy = new CopyObjFromSrcBucketToTargetBucket();
            //copy.CopyObjFromSrcToTargetBucket().Wait();


            // 6. Example How to delete all files from S3 bucket
            // This Approach may not be right fit if Number of objects count is high

            //DeleteAllFilesFromS3v1 delAll = new DeleteAllFilesFromS3v1();
            //delAll.DeleteAllFiles().Wait();

            // 7. Example How to check does S3 bucket exists
          
            //DoesS3BucketExist checkExistence = new DoesS3BucketExist();
            //checkExistence.DoesBucketExists().Wait();

            // 8. Example How to check does S3 Object exists

            //DoesObjectExistInS3 checkObjExistence = new DoesObjectExistInS3();
            //checkObjExistence.DoesObjectExist().Wait();


            // 9. List S3 Object all Versions 

            ListS3ObjectAllVersion listObjAllVersions = new ListS3ObjectAllVersion();
            listObjAllVersions.listObjectAllVersion().Wait();

            // 10. download file from s3

           // DownloadFileFromS3 fileDownload = new DownloadFileFromS3();
            //fileDownload.DownloadFileAsync().Wait();



        }
    }
}
