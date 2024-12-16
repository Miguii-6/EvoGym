﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoGym.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Somatotype { get; set; }
        public int FitnessLevel { get; set; }
        public int Points { get; set; }
        public List<Achievement> Achievements { get; set; }
    }
}
