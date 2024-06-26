﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloske.BLL._2._Models
{
    public class UserPersonnalInformation
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string? Payroll_identity { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public bool? Is_in_employee_registrer { get; set; }
        public bool? Is_archived { get; set; }
        public string? Password_hash { get; set; }
    }
}
