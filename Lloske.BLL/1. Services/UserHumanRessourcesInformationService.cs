using IBLL = Lloske.BLL._1._1_Interfaces;
using MBLL = Lloske.BLL._2._Models;
using Lloske.BLL._3._Mappers;
using IDAL = Lloske.DAL._1._1_Interfaces;
using Lloske.DAL._1._Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lloske.DAL._1._1_Interfaces;

namespace Lloske.BLL._1._Services
{
    public class UserHumanRessourcesInformationService : IBLL.IUserHumanRessourcesInformation
    {
        private readonly IDAL.IUserHumanRessourcesInformationRepository _UserHumanRessourcesInformationRepository;

        public UserHumanRessourcesInformationService(IDAL.IUserHumanRessourcesInformationRepository userHumanRessourcesInformationRepository)
        {
            _UserHumanRessourcesInformationRepository = userHumanRessourcesInformationRepository;
        }
        public IEnumerable<MBLL.UserHumanRessourcesInformation> GetAll()
        {
            return _UserHumanRessourcesInformationRepository.GetAll().Select(i => i.ToModel());
        }
        public MBLL.UserHumanRessourcesInformation? GetById(int id)
        {
            return _UserHumanRessourcesInformationRepository.GetById(id)?.ToModel();
        }
        public MBLL.UserHumanRessourcesInformation Create(MBLL.UserHumanRessourcesInformation userHumanRessourcesInformation)
        {
            return _UserHumanRessourcesInformationRepository.Create(userHumanRessourcesInformation.ToEntity()).ToModel();
        }
        public bool Update(int id, MBLL.UserHumanRessourcesInformation userHumanRessourcesInformation)
        {
            bool updated = _UserHumanRessourcesInformationRepository.Update(id, userHumanRessourcesInformation.ToEntity());
            return updated;
        }
        public bool Delete(int id)
        {
            bool deleted = _UserHumanRessourcesInformationRepository.Delete(id);
            return deleted;
        }




    }
}
