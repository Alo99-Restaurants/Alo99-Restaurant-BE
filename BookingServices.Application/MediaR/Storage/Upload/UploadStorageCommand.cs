using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.Storage.Upload;

public class UploadStorageCommand : IRequest<string>
{
    public IFormFile Files { get; set; }
    public string? Key { get; set; }
}
