﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingServices.Entities.Entities.Others;

public class EntityHistories
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string? RequestId { get; set; }
    public string EntityName { get; set; }
    public string? EntityId { get; set; }
    public string EntityChangeData { get; set; }
    public string Action { get; set; }
    public string ActionBy { get; set; }
    public DateTime ActionDate { get; set; } = DateTime.Now;
}
