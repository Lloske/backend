using Lloske.API._2._DTOs;
using Lloske.BLL._2._Models;

namespace Lloske.API._3._Mappers
{
    public static class UserPersonnalInformationMapper
    {
        // Un Mapper Model (BLL) → DTO (API)
        public static UserPersonnalInformationDTO ToDTO(this UserPersonnalInformation model)
        {
            return new UserPersonnalInformationDTO
            {
                Id = model.Id,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Payroll_identity = model.Payroll_identity,
                Email = model.Email,
                Phone = model.Phone,
                Is_in_employee_registrer = model.Is_in_employee_registrer,
                Is_archived = model.Is_archived,
                Password_hash = model.Password_hash,
            };
        }
        // Un Mapper DTO (API) → Model (BLL)
        public static UserPersonnalInformation ToModel(this UserPersonnalInformationDataDTO DTO)
        {
            return new UserPersonnalInformation
            {
                Firstname = DTO.Firstname,
                Lastname = DTO.Lastname,
                Payroll_identity = DTO.Payroll_identity,
                Email = DTO.Email,
                Phone = DTO.Phone,
                Is_in_employee_registrer = DTO.Is_in_employee_registrer,
                Is_archived = DTO.Is_archived,
                Password_hash = DTO.Password_hash,
            };
        }

    }
}
