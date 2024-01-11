using Lloske.API._2._DTOs;
using Lloske.BLL._2._Models;
using System.Reflection;

namespace Lloske.API._3._Mappers
{
    public static class UserContractInformationMapper
    {
        public static UserContractInformationDTO ToDTO(this UserContractInformation model)
        {
            return new UserContractInformationDTO
            {
                Id = model.Id,
                Contract_type = model.Contract_type,
                Employment_type = model.Employment_type,
                Job_title = model.Job_title,
                Organization_entry_date = model.Organization_entry_date,
                Contract_start = model.Contract_start,
                Probation_end_date = model.Probation_end_date,
                Contract_end = model.Contract_end,
                Status = model.Status,
                Professional_category = model.Professional_category,
                Last_medical_checkup_date = model.Last_medical_checkup_date,
            };
        }
        // Un Mapper DTO (API) → Model (BLL)
        public static UserContractInformation ToModel(this UserContractInformationDataDTO DTO)
        {
            return new UserContractInformation
            {
                Id = DTO.Id,
                Contract_type = DTO.Contract_type,
                Employment_type = DTO.Employment_type,
                Job_title = DTO.Job_title,
                Organization_entry_date = DTO.Organization_entry_date,
                Contract_start = DTO.Contract_start,
                Probation_end_date = DTO.Probation_end_date,
                Contract_end = DTO.Contract_end,
                Status = DTO.Status,
                Professional_category = DTO.Professional_category,
                Last_medical_checkup_date = DTO.Last_medical_checkup_date,
            };
        }
    }
}
