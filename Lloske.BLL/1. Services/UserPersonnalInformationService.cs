﻿using Lloske.BLL._1._1_Interfaces;
using Lloske.BLL._3._Mappers;
using Lloske.BLL._2._Models;
using Lloske.DAL._1._1_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloske.BLL._1._Services
{
    public class UserPersonnalInformationService : _1_Interfaces.IUserPersonnalInformation
    {
        private readonly DAL._1._1_Interfaces.IUserPersonnalInformationRepository _UserPersonnalInformationRepository;
        public UserPersonnalInformationService(DAL._1._1_Interfaces.IUserPersonnalInformationRepository userPersonnalInformationRepository)
        {
            _UserPersonnalInformationRepository = userPersonnalInformationRepository;
        }

        public IEnumerable<UserPersonnalInformation> GetAll()
        {
            return _UserPersonnalInformationRepository.GetAll().Select(i => i.ToModel());
        }

        public UserPersonnalInformation? GetById(int id)
        {
            return _UserPersonnalInformationRepository.GetById(id)?.ToModel();
        }

        public UserPersonnalInformation Create(UserPersonnalInformation userPersonnalInformation)
        {
            return _UserPersonnalInformationRepository.Create(userPersonnalInformation.ToEntity()).ToModel();
        }
        public bool Update(int userId, UserPersonnalInformation userPersonnalInformation)
        {
            bool updated = _UserPersonnalInformationRepository.Update(userId, userPersonnalInformation.ToEntity());
            return updated;
        }
        public bool Delete(int id)
        {
            bool deleted = _UserPersonnalInformationRepository.Delete(id);
            return deleted;
        }


    }
}