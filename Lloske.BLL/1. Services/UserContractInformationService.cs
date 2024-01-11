using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelBLL = Lloske.BLL._2._Models;
using RepositoriesDAL = Lloske.DAL._1._Repositories;
using EntitiesDAL = Lloske.DAL._2._Entities;
using Lloske.DAL._1._Repositories;
using Lloske.BLL._2._Models;
using Lloske.BLL._1._1_Interfaces;
using Lloske.DAL._1._1_Interfaces;
using Lloske.BLL._3._Mappers;

namespace Lloske.BLL._1._Services
{
    public class UserContractInformationService : IUserContractInformation
    {
        private readonly IUserContractInformationRepository _UserContractInformationRepository;
        public UserContractInformationService(IUserContractInformationRepository userContractInformationRepository)
        {
            _UserContractInformationRepository = userContractInformationRepository;
        }
        public IEnumerable<UserContractInformation> GetAll()
        {
            return _UserContractInformationRepository.GetAll().Select(i => i.ToModel());
        }
        public UserContractInformation? GetById(int id)
        {
            return _UserContractInformationRepository.GetById(id)?.ToModel();
        }
        public UserContractInformation Create(UserContractInformation userContractInformation)
        {
            return _UserContractInformationRepository.Create(userContractInformation.ToEntity()).ToModel();
        }
        public bool Update(int id, UserContractInformation userContractInformation)
        {
            bool updated = _UserContractInformationRepository.Update(id, userContractInformation.ToEntity());
            return updated;
        }
        public bool Delete(int id)
        {
            bool deleted = _UserContractInformationRepository.Delete(id);
            return deleted;
        }
    }
}
