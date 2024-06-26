﻿using BookingServices.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.User.Command.NewFolder
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Name { get; set; }
        public ERole Role { get; set; }
        public string ClientUrl { get; set; }
    }
}
