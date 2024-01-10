using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Lloske.BLL._2._Models;

namespace Lloske.BLL._1._1_Interfaces
{
    public interface IUserContractInformation
    {
        public IEnumerable<UserContractInformation> GetAll();
        public UserContractInformation? GetById(int id);
        public UserContractInformation Create(UserContractInformation userContractInformation);
        public bool Update(int id, UserContractInformation userContractInformation);
        public bool Delete(int id);
    }
}
