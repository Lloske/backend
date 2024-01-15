using System.ComponentModel.DataAnnotations;

namespace Lloske.API._2._DTOs
{
    public class UserPayrollDataDTO
    {
        public int Id { get; set; }
        public string? Work_time_measurement { get; set; }
        public short? Maximum_contract_hours { get; set; }
        public int Id_user_personnal_information { get; set; }
    }
    public class UserPayrollData_DataDTO
    {
        [Required]
        public int Id { get; set; }
        public string? Work_time_measurement { get; set; }
        public short? Maximum_contract_hours { get; set; }
        public int Id_user_personnal_information { get; set; }
    }
}
