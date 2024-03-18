using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using BookingServices.Core;
using BookingServices.External.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net;
using System.Web;
using static AppConfigurations;

namespace BookingServices.External.Services;

public class AwsS3Service : IAwsS3Services
{
    private readonly AWSS3Configurations _s3Config;
    private readonly IAmazonS3 _awsS3Client;

    public AwsS3Service(IOptions<AWSS3Configurations> options)
    {
        _s3Config = options.Value;
        _awsS3Client = new AmazonS3Client(_s3Config.AwsAccessKey, _s3Config.AwsSecretAccessKey, RegionEndpoint.GetBySystemName(_s3Config.Region));
    }
    public async Task<byte[]> DownloadFileAsync(string file)
    {
        MemoryStream ms = null;

        GetObjectRequest getObjectRequest = new GetObjectRequest
        {
            BucketName = _s3Config.BucketName,
            Key = file
        };

        using (var response = await _awsS3Client.GetObjectAsync(getObjectRequest))
        {
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                using (ms = new MemoryStream())
                {
                    await response.ResponseStream.CopyToAsync(ms);
                }
            }
        }

        if (ms is null || ms.ToArray().Length < 1)
            throw new FileNotFoundException(string.Format("The document '{0}' is not found", file));

        return ms.ToArray();
    }
    public async Task<string> UploadFileAsync(IFormFile file, string key = "")
    {
        using (var newMemoryStream = new MemoryStream())
        {
            file.CopyTo(newMemoryStream);

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = newMemoryStream,
                Key = string.IsNullOrEmpty(key) ? HttpUtility.UrlEncode(file.FileName) : HttpUtility.UrlEncode(key),
                BucketName = _s3Config.BucketName,
                ContentType = file.ContentType,
            };
            uploadRequest.Key = DateTimeOffset.Now.ToUnixTimeSeconds() + uploadRequest.Key;
            var fileTransferUtility = new TransferUtility(_awsS3Client);

            await fileTransferUtility.UploadAsync(uploadRequest);

            return uploadRequest.Key;
        }
    }
    public async Task DeleteFileAsync(string fileName, string versionId)
    {
        if (IsFileExists(fileName, versionId))
        {
            DeleteObjectRequest request = new DeleteObjectRequest
            {
                BucketName = _s3Config.BucketName,
                Key = fileName
            };

            if (!string.IsNullOrEmpty(versionId))
                request.VersionId = versionId;

            await _awsS3Client.DeleteObjectAsync(request);
        }
    }
    public bool IsFileExists(string fileName, string versionId)
    {
        try
        {
            GetObjectMetadataRequest request = new GetObjectMetadataRequest()
            {
                BucketName = _s3Config.BucketName,
                Key = fileName,
                VersionId = !string.IsNullOrEmpty(versionId) ? versionId : null
            };

            var response = _awsS3Client.GetObjectMetadataAsync(request).Result;

            return true;
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null && ex.InnerException is AmazonS3Exception awsEx)
            {
                if (string.Equals(awsEx.ErrorCode, "NoSuchBucket"))
                    return false;

                else if (string.Equals(awsEx.ErrorCode, "NotFound"))
                    return false;
            }

            throw;
        }
    }

}
