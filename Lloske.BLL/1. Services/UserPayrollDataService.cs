using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL = Lloske.BLL._1._1_Interfaces;
using MBLL = Lloske.BLL._2._Models;
using Lloske.BLL._3._Mappers;
using IDAL = Lloske.DAL._1._1_Interfaces;

namespace Lloske.BLL._1._Services
{
    public class UserPayrollDataService : IBLL.IUserPayrollData
    {
        private readonly IDAL.IUserPayrollDataRepository _UserPayrollDataRepository;

        public UserPayrollDataService(IDAL.IUserPayrollDataRepository userPayrollDataRepository) 
        {
            _UserPayrollDataRepository = userPayrollDataRepository;
        }
        public IEnumerable<MBLL.UserPayrollData> GetAll()
        {
            return _UserPayrollDataRepository.GetAll().Select(i => i.ToModel());
        }
        public MBLL.UserPayrollData? GetById(int id)
        {
            return _UserPayrollDataRepository.GetById(id)?.ToModel();
        }
        public MBLL.UserPayrollData Create(MBLL.UserPayrollData userPayrollData)
        {
            return _UserPayrollDataRepository.Create(userPayrollData.ToEntity()).ToModel();
        }
        public bool Update(int id, MBLL.UserPayrollData userPayrollData)
        {
            bool updated = _UserPayrollDataRepository.Update(id, userPayrollData.ToEntity());
            return updated;
        }
        public bool Delete(int id)
        {
            bool deleted = _UserPayrollDataRepository.Delete(id);
            return deleted;
        }
    }
}
