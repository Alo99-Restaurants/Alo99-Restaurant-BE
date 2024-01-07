using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Model.UserModels;

public class LoginResponseModel 
{
    public UserDTO UserInfor { get; set; }
    public string JwtToken { get; set; }
}
