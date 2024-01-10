using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloske.BLL._2._Models
{
    public class UserContractInformation
    {
        public int Id { get; set; }
        public short? Contract_type { get; set; }
        public short? Employment_type { get; set; }
        public string? Job_title { get; set; }
        public DateTime? Organization_entry_date { get; set; }
        public DateTime? Contract_start { get; set; }
        public DateTime? Probation_end_date { get; set; }
        public DateTime? Contract_end { get; set; }
        public short? Status { get; set; }
        public short? Professional_category { get; set; }
        public DateTime? Last_medical_checkup_date { get; set; }
    }
}
