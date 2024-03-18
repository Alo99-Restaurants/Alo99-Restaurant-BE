using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities.Others;
using BookingServices.External.Interfaces;
using Microsoft.Extensions.Options;
using static AppConfigurations;

namespace BookingServices.Application.MediaR.Common.Storage.Upload;

public class UploadStorageCommandHandler : IRequestHandler<UploadStorageCommand, string>
{
    private readonly IAwsS3Services _awsS3Services;
    private readonly BookingDbContext _bookingDbContext;
    private readonly AWSS3Configurations _s3Config;

    public UploadStorageCommandHandler(IAwsS3Services awsS3Services, BookingDbContext bookingDbContext, IOptions<AWSS3Configurations> options)
    {
        _s3Config = options.Value;
        _awsS3Services = awsS3Services;
        _bookingDbContext = bookingDbContext;
    }

    public async Task<string> Handle(UploadStorageCommand request, CancellationToken cancellationToken)
    {
        var s3Key = await _awsS3Services.UploadFileAsync(request.Files, request.Key ?? "");

        var stogare = new Storages
        {
            Name = s3Key,
            Url = _s3Config.Url + '/' + _s3Config.BucketName + '/' + s3Key
        };

        _bookingDbContext.Add(stogare);
        _bookingDbContext.SaveChanges();

        return stogare.Url;
    }
}
