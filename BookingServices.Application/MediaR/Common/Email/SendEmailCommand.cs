using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookingServices.Application.MediaR.Common.Email;

public class SendEmailCommand : IRequest<bool>
{
    [EmailAddress]
    public string To { get; set; }
    [Required]
    public string Subject { get; set; }
    [Required]
    public string HtmlContent { get; set; }
}
