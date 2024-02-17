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
    public static class UserContractInformationMapper
    {
        // Utilisez le modificateur static pour déclarer un membre statique, qui appartient au type lui-même plutôt qu’à un objet spécifique.
        public static Models.UserContractInformation ToModel(this Entities.UserContractInformation entity)
        {
            return new Models.UserContractInformation
            {
                Id = entity.Id,
                Contract_type = entity.Contract_type.HasValue ? Enum.GetName(typeof(Models.Contract_type), entity.Contract_type.Value) : null,
                Employment_type = entity.Employment_type.HasValue ? Enum.GetName(typeof(Models.Employment_type), entity.Employment_type.Value) : null,
                Job_title = entity.Job_title,
                Organization_entry_date = entity.Organization_entry_date,
                Contract_start = entity.Contract_start,
                Probation_end_date = entity.Probation_end_date,
                Contract_end = entity.Contract_end,
                Status = entity.Status.HasValue ? Enum.GetName(typeof(Models.Status), entity.Status.Value) : null,
                Professional_category = entity.Professional_category.HasValue ? Enum.GetName(typeof(Models.Professional_category), entity.Professional_category.Value) : null,
                Last_medical_checkup_date = entity.Last_medical_checkup_date,
                FK_id_user_personnal_information = entity.FK_id_user_personnal_information,
            };
        }
        // Utilisez le modificateur static pour déclarer un membre statique, qui appartient au type lui-même plutôt qu’à un objet spécifique.
        public static Entities.UserContractInformation ToEntity(this Models.UserContractInformation model)
        {
            return new Entities.UserContractInformation
            {
                Id = model.Id,
                Contract_type = model.Contract_type != null ? (short)Enum.Parse(typeof(Models.Contract_type), model.Contract_type) : (short?)null,
                Employment_type = model.Employment_type != null ? (short)Enum.Parse(typeof(Models.Employment_type), model.Employment_type) : (short?)null,
                Job_title = model.Job_title,
                Organization_entry_date = model.Organization_entry_date,
                Contract_start = model.Contract_start,
                Probation_end_date = model.Probation_end_date,
                Contract_end = model.Contract_end,
                Status = model.Status != null ? (short)Enum.Parse(typeof(Models.Status), model.Status) : (short?)null,
                Professional_category = model.Professional_category != null ? (short)Enum.Parse(typeof(Models.Professional_category), model.Professional_category) : (short?)null,
                Last_medical_checkup_date = model.Last_medical_checkup_date,
                FK_id_user_personnal_information = model.FK_id_user_personnal_information,
            };
        }
    }
}
