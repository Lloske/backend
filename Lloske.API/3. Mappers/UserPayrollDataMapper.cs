using Lloske.API._2._DTOs;
using Lloske.BLL._2._Models;
using System.Reflection;

namespace Lloske.API._3._Mappers
{
    public static class UserPayrollDataMapper
    {
        public static UserPayrollDataDTO ToDTO(this UserPayrollData model)
        {
            return new UserPayrollDataDTO
            {
                Id = model.Id,
                Work_time_measurement = model.Work_time_measurement,
                Maximum_contract_hours = model.Maximum_contract_hours,
                Id_user_personnal_information = model.Id_user_personnal_information
            };
        }
        public static UserPayrollData ToModel(this UserPayrollData_DataDTO DTO)
        {
            return new UserPayrollData
            {
                Id = DTO.Id,
                Work_time_measurement = DTO.Work_time_measurement,
                Maximum_contract_hours = DTO.Maximum_contract_hours,
                Id_user_personnal_information = DTO.Id_user_personnal_information
            };
        }
    }
}
