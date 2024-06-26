﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Models = Lloske.BLL._2._Models;
using Entities = Lloske.DAL._2._Entities;

namespace Lloske.BLL._3._Mappers
{
    public static class UserPayrollDataMapper
    {
        // Utilisez le modificateur static pour déclarer un membre statique, qui appartient au type lui-même plutôt qu’à un objet spécifique.
        public static Models.UserPayrollData ToModel(this Entities.UserPayrollData entity)
        {
            return new Models.UserPayrollData
            {
                Id = entity.Id,
                Work_time_measurement = entity.Work_time_measurement.HasValue ? Enum.GetName(typeof(Models.Work_time_measurement), entity.Work_time_measurement.Value) : null,
                Maximum_contract_hours = entity.Maximum_contract_hours,
                Id_user_personnal_information = entity.Id_user_personnal_information,
            };
        }
        // Utilisez le modificateur static pour déclarer un membre statique, qui appartient au type lui-même plutôt qu’à un objet spécifique.
        public static Entities.UserPayrollData ToEntity(this Models.UserPayrollData model)
        {
            return new Entities.UserPayrollData
            {
                Id = model.Id,
                Work_time_measurement = model.Work_time_measurement != null ? (short)Enum.Parse(typeof(Models.Work_time_measurement), model.Work_time_measurement) : (short?)null,
                Maximum_contract_hours = model.Maximum_contract_hours,
                Id_user_personnal_information = model.Id_user_personnal_information,
            };
        }
    }
}
