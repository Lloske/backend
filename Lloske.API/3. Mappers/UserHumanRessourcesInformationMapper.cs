using Lloske.API._2._DTOs;
using Lloske.BLL._2._Models;
using System.Reflection;

namespace Lloske.API._3._Mappers
{
    public static class UserHumanRessourcesInformationMapper
    {
        public static UserHumanRessourcesInformationDTO ToDTO(this UserHumanRessourcesInformation model)
        {
            return new UserHumanRessourcesInformationDTO
            {
                Id = model.Id,
                Birthdate = model.Birthdate,
                Birthplace = model.Birthplace,
                Birthland = model.Birthland,
                Nationality = model.Nationality,
                Gender = model.Gender,
                Address_street = model.Address_street,
                Adress_postal_code = model.Adress_postal_code,
                Adress_city = model.Adress_city,
                Adress_country = model.Nationality,
                Iban = model.Iban,
                Bic = model.Bic,
                Social_security_number = model.Social_security_number,
                User_note = model.User_note,
            };
        }
        // Un Mapper DTO (API) → Model (BLL)
        public static UserHumanRessourcesInformation ToModel(this UserHumanRessourcesInformationDTO DTO)
        {
            return new UserHumanRessourcesInformation
            {
                Id = DTO.Id,
                Birthdate = DTO.Birthdate,
                Birthplace = DTO.Birthplace,
                Birthland = DTO.Birthland,
                Nationality = DTO.Nationality,
                Gender = DTO.Gender,
                Address_street = DTO.Address_street,
                Adress_postal_code = DTO.Adress_postal_code,
                Adress_city = DTO.Adress_city,
                Adress_country = DTO.Nationality,
                Iban = DTO.Iban,
                Bic = DTO.Bic,
                Social_security_number = DTO.Social_security_number,
                User_note = DTO.User_note,
            };
        }
    }
}
