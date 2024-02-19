using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Model.UserModels
{
    public class GoogleUserInfor
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Picture { get; set; }
        public string Locale { get; set; }
        public string Hd { get; set; }
    }
}
