﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyboardSimulator
{
    public class UserRegistration
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordTwo { get; set; }

        public string Gender { get; set; }

        public DateTime DateofBirth { get; set; }
    }
}
