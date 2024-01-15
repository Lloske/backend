using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloske.DAL._2._Entities
{
    public class UserPayrollData
    {
        public int Id { get; set; }
        public short? Work_time_measurement { get; set; }
        public short? Maximum_contract_hours { get; set; }
        public int Id_user_personnal_information { get; set; }
    }
}
