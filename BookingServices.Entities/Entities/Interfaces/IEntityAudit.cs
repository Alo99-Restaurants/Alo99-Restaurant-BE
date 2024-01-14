using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServices.Entities.Entities.Interfaces;

public interface IEntityAudit<T>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    T Id { get; set; }
    Guid CreatedBy { get; set; }
    DateTime CreatedDate { get; set; }
    Guid? ModifiedBy { get; set; }
    DateTime? ModifiedDate { get; set; }
}
public class EntityAudit<T> : IEntityAudit<T>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public T Id { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }


    [NotMapped]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public virtual Users? CreatedByUser { get; set; }

    [NotMapped]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public virtual Users? ModifiedByUser { get; set; }
}
