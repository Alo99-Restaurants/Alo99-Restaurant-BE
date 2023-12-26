using Microsoft.AspNetCore.Http;
namespace BookingServices.External.Interfaces;

public interface IAwsS3Services
{
    Task<byte[]> DownloadFileAsync(string file);

    Task<string> UploadFileAsync(IFormFile file, string key = "");

    Task DeleteFileAsync(string fileName, string versionId = "");
}