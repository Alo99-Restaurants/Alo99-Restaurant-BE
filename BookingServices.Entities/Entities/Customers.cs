using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Entities.Entities
{
    public class Customers : EntityAudit<Guid>, IHaveDeleted
    {
        [EmailAddress]
        public string Email { get; set; }
        private string? _name;

        public string Name
        {
            get { return string.IsNullOrEmpty(_name)? this.Email:_name; }
            set { _name = value; }
        }

        public EGender Gender { get; set; } = EGender.Male;
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsDeleted { get; set; }
    }
   
}
