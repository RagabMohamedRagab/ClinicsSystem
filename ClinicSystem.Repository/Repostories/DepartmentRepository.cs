using AutoMapper;
using ClinicSystem.BOL.IRepositories;
using ClinicSystem.DAL.Context;
using ClinicSystem.DAL.Domains;
using ClinicSystem.Models.DTOS.Department;
using ClinicSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Repositories.Repostories {
    public class DepartmentRepository : GenericRepository<DepartMent>, IDepartmentRepository {
        private readonly IMapper _mapper;
        public DepartmentRepository(ClinicDbContext clinic, IMapper mapper) : base(clinic)
        {
            _mapper = mapper;
        }
        public DepartMentDTO Create(DepartMentDTO dTO)
        {
            var departMent = _mapper.Map<DepartMent>(dTO);
            if (departMent != null)
            {
                Create(departMent);
                departMent.Order = Count() + 1;
                return dTO;
            }
            return null;
        }

        public DepartMentDTO Delete(int Id)
        {
            DepartMent departMent = Find(Id);
            if (departMent != null)
            {
                departMent.IsDeleted = true;
                return _mapper.Map<DepartMentDTO>(departMent);
            }
            return null;
        }

        public IEnumerable<GetAllDepartDTOS> GetALLDepart(string lan="en",int Pagesize=4,int Pagenumber=1)
        {
            int skip= (Pagenumber - 1) * Pagesize;
            IEnumerable<DepartMent> departMents = GetAll();
            IEnumerable<DepartMentDTO> departMentDTOs = null;
            IEnumerable<GetAllDepartDTOS> allDepartDTOS = null;
            if (departMents.Any())
            {
                departMentDTOs = _mapper.Map<IEnumerable<DepartMentDTO>>(departMents).Skip(skip).Take(Pagesize);
                if (lan == "en")
                {
                    allDepartDTOS = departMentDTOs.Select(b => new GetAllDepartDTOS() { Name = b.EnName });
                }
                else
                {
                    allDepartDTOS = departMentDTOs.Select(b => new GetAllDepartDTOS() { Name = b.ArName });
                }
                return allDepartDTOS;
            }
           
            return null;
        }

        public DepartMentDTO Update(int Id,DepartMentDTO dTO)
        {
          var depart=Find(Id);
            if (depart != null)
            {
                depart.ArName = dTO.ArName;
                depart.EnName = dTO.EnName;
                depart.ModifiedOn = DateTime.Now;
                return dTO;
            }
            return null;
        }
    }
}
