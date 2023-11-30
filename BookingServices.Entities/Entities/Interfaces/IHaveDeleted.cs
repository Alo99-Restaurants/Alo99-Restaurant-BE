using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Entities.Entities.Interfaces
{
    public interface IHaveDeleted
    {
        bool IsDeleted { get; set; }
    }
}
