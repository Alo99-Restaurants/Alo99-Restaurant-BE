using Microsoft.AspNetCore.Http;

namespace BookingServices.Application.MediaR.Common.Storage.Upload;

public class UploadStorageCommand : IRequest<string>
{
    public IFormFile Files { get; set; }
    public string? Key { get; set; }
}
