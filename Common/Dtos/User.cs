﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }                  
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
      
        //public virtual ICollection<ApartmentDto>ApartmentsOfUsers { get; set; }
    }
}
