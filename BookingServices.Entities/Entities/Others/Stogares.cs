using BookingServices.Entities.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Entities.Entities.Others
{
    public class Stogares : EntityAudit<Guid>
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
