using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloske.DAL._2._Entities
{
    public class UserContractInformation
    {
        public int Id { get; set; }
        public short Contract_type { get; set; }
        public short Employment_type { get; set; };
        public string Job_title { get; set; } = string.Empty;
        public date Organization_entry_date { get; set; } = string.Empty;
        public string Contract_start { get; set; } = string.Empty;
        public bool Probation_end_date { get; set; }
        public bool Contract_end { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Professional_category { get; set; } = string.Empty;
        public string Last_medical_checkup_date { get; set; } = string.Empty;
    }
}
