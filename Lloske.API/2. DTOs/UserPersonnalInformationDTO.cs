using System.ComponentModel.DataAnnotations;

namespace Lloske.API.DTOs
{
    public class UserPersonnalInformationDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public int Payroll_identity { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool Is_in_employee_registrer { get; set; }
        public bool Is_archived { get; set; }
        public string Password_hash { get; set; } = string.Empty;
    }

    // UserPersonnalInformation
    public class UserPersonnalInformationDataDTO
    {
        [Required]
        [MaxLength(100)]
        public string Firstname { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Lastname { get; set; } = string.Empty;
        public int Payroll_identity { get; set; }
        [MaxLength(125)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(30)]
        public string Phone { get; set; } = string.Empty;
        public bool Is_in_employee_registrer { get; set; }
        public bool Is_archived { get; set; }
        public string Password_hash { get; set; } = string.Empty;
    }
}
