using BookingServices.Entities.Entities;
using BookingServices.Entities.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Model.UserModels
{
    public class UserDTO : EntityAudit<Guid>, IHaveDeleted
    {
        public string Name { get; set; }
        public bool IsCustomer { get; set; }
        public Guid? CustomerId { get; set; }
        public bool IsDeleted { get; set ; }

        public Customers Customer { get; set; }
    }
}
