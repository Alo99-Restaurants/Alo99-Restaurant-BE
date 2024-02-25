global using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookingServices.Application.MediaR.BookingMenus.Command;

public class CreatesOrUpdatesBookingMenuCommand : IRequest<bool>
{
    [Required]
    public Guid BookingId { get; set; }
    public List<MenuRequest> MenuRequests { get; set; }
}
public class MenuRequest
{
    public Guid? Id { get; set; }
    public Guid MenuId { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public string? SpecialRequest { get; set; }
    public bool IsRemove { get; set; } = false;
}
