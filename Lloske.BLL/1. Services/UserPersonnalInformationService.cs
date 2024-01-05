using Lloske.BLL.Interfaces;
using Lloske.BLL.Mappers;
using Lloske.BLL.Models;
using Lloske.DAL.Interfaces;
using Lloske.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloske.BLL.Services
{
    public class UserPersonnalInformationService : IUserPersonnalInformation
    {
        private readonly IUserPersonnalInformationRepository _UserPersonnalInformationRepository;
        public UserPersonnalInformationService (IUserPersonnalInformationRepository userPersonnalInformationRepository)
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
        public bool Delete(int id)
        {
            bool deleted = _UserPersonnalInformationRepository.Delete(id);
            return deleted;
        }
    }
}
