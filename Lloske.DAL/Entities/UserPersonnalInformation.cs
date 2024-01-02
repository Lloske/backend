using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloske.DAL.Entities
{
    public class User_personnal_information
    {
        public int Id { get; set; }
        public int Firstname { get; set; }
        public int Lastname { get; set; }
        public int Payroll_identity { get; set; }
        public int Email { get; set; }
        public int Phone { get; set; }
        public int Is_in_employee_registrer { get; set; }
        public int Is_archived { get; set; }
        public int Password_hash { get; set; }
        public int Password_salt { get; set; }
    }
}
