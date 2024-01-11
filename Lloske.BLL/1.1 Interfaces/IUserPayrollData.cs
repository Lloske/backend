using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lloske.BLL._2._Models;

namespace Lloske.BLL._1._1_Interfaces
{
    public interface IUserPayrollData
    {
        public IEnumerable<UserPayrollData> GetAll();
        public UserPayrollData? GetById(int id);
        public UserPayrollData Create(UserPayrollData userPayrollData);
        public bool Update(int id, UserPayrollData userPayrollData);
        public bool Delete(int id);
    }
}
