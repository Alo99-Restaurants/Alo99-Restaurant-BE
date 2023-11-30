using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Entities.Entities
{
    [Index("Username", IsUnique = true)]
    public class Users : EntityAudit<Guid>, IHaveDeleted
    {
        public string Username { get;set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool IsCustomer { get; set; }
        public Guid? CustomerId { get; set; }
        public ERole Role { get; set; } = ERole.Staff;
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customers? Customer { get; set; }
    }
}
