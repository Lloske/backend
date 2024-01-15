using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloske.BLL._2._Models
{
    public class UserPayrollData
    {
        public int Id { get; set; }
        public string? Work_time_measurement { get; set; }
        public short? Maximum_contract_hours { get; set; }
        public int Id_user_personnal_information { get; set; }
    }

    public enum Work_time_measurement
    {
        Standard = 1,
        DailyRate = 2
    }
}
