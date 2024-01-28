using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Entities.Enum
{
    public enum EBookingStatus
    {
        New = 1,
        Confirm = 2,
        Using = 3,
        Completed = 4,
        Cancelled = 5,
    }
}
