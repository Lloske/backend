using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloske.DAL._2._Entities
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
        public string? Password_salt { get; set; } = string.Empty; // Vérifier comment gérer le salt. Si je le met pas à empty j'ai une erreur
        public int FK_id_user_personnal_information { get; set; }
    }
}
