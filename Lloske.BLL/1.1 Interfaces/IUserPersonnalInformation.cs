using Lloske.BLL._2._Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloske.BLL._1._1_Interfaces
{
    public interface IUserPersonnalInformation
    {
        public IEnumerable<UserPersonnalInformation> GetAll();
        public UserPersonnalInformation? GetById(int id);
        public UserPersonnalInformation Create(UserPersonnalInformation ingredient);
        public bool Delete(int id);
    }
}
