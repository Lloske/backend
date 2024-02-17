using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Models = Lloske.BLL._2._Models;
using Entities = Lloske.DAL._2._Entities;

namespace Lloske.BLL._3._Mappers
{
    public static class UserHumanRessourcesInformationMapper
    {
        // Utilisez le modificateur static pour déclarer un membre statique, qui appartient au type lui-même plutôt qu’à un objet spécifique.
        public static Models.UserHumanRessourcesInformation ToModel(this Entities.UserHumanRessourcesInformation entity)
        {
            return new Models.UserHumanRessourcesInformation
            {
                Id = entity.Id,
                Birthdate = entity.Birthdate,
                Birthplace = entity.Birthplace,
                Birthland = entity.Birthland,
                Nationality = entity.Nationality,
                Gender = entity.Gender.HasValue ? Enum.GetName(typeof(Models.Gender), entity.Gender.Value) : null,
                Address_street = entity.Address_street,
                Adress_postal_code = entity.Adress_postal_code,
                Adress_city = entity.Adress_city,
                Adress_country = entity.Adress_country,
                Iban = entity.Iban,
                Bic = entity.Bic,
                Social_security_number = entity.Social_security_number,
                User_note = entity.User_note,
            };
        }
        // Utilisez le modificateur static pour déclarer un membre statique, qui appartient au type lui-même plutôt qu’à un objet spécifique.
        public static Entities.UserHumanRessourcesInformation ToEntity(this Models.UserHumanRessourcesInformation model)
        {
            return new Entities.UserHumanRessourcesInformation
            {
                Id = model.Id,
                Birthdate = model.Birthdate,
                Birthplace = model.Birthplace,
                Birthland = model.Birthland,
                Nationality = model.Nationality,
                Gender = model.Gender != null ? (short)Enum.Parse(typeof(Models.Gender), model.Gender) : null,
                Address_street = model.Address_street,
                Adress_postal_code = model.Adress_postal_code,
                Adress_city = model.Adress_city,
                Adress_country = model.Adress_country,
                Iban = model.Iban,
                Bic = model.Bic,
                Social_security_number = model.Social_security_number,
                User_note = model.User_note,
            };
        }
    }
}
