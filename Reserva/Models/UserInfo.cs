﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Models
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string nombreUsuario { get; set; }
        public int edad { get; set; }
        public bool isAdmin { get; set; }
    }
}
