using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lloske.BLL._2._Models;

namespace Lloske.BLL._1._1_Interfaces
{
    public interface IUserHumanRessourcesInformation
    {
        public IEnumerable<UserHumanRessourcesInformation> GetAll();
        public UserHumanRessourcesInformation? GetById(int id);
        public UserHumanRessourcesInformation Create(UserHumanRessourcesInformation ingredient);
        public bool Delete(int id);
    }
}
