using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lloske.BLL._2._Models;


namespace Lloske.BLL._1._1_Interfaces
{
    public interface IUserPersonnalInformation
    {
        public IEnumerable<UserPersonnalInformation> GetAll();
        public UserPersonnalInformation? GetById(int id);
        public UserPersonnalInformation Create(UserPersonnalInformation userPersonnalInformation);
        //public bool Update(int id, UserPersonnalInformation userPersonnalInformation);
        public bool Delete(int id);
    }
}
