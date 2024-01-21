using BookingServices.External.Interfaces;
using MediatR;

namespace BookingServices.Application.MediaR.Common.Email;

public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, bool>
{
    private readonly IEmailService _emailServices;

    public SendEmailCommandHandler(IEmailService emailServices)
    {
        _emailServices = emailServices;
    }

    public async Task<bool> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        await _emailServices.SendEmailAsync(request.To, request.Subject, request.HtmlContent);
        return true;
    }
}
