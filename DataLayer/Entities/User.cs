﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class User: BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string  Role { get; set; }
        public string Token { get; set; }
    }
}
