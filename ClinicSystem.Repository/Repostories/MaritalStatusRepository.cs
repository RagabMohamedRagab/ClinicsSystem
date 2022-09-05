using AutoMapper;
using ClinicSystem.BOL.IRepositories;
using ClinicSystem.DAL.Context;
using ClinicSystem.DAL.Domains;
using ClinicSystem.Models.DTOS.MaritalStatus;
using ClinicSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Repositories.Repostories {
    public class MaritalStatusRepository : GenericRepository<MaritalStatus>,IMaritalStatusRepository {
        private readonly IMapper _mapper;
        public MaritalStatusRepository(ClinicDbContext clinic, IMapper mapper) : base(clinic)
        {
            _mapper = mapper;
        }

        public MaritalStatusDTO Create(MaritalStatusDTO maritalStatus)
        {
            try
            {
                Create(_mapper.Map<MaritalStatus>(maritalStatus));
                return maritalStatus;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public MaritalStatusDTO Update(int Id, MaritalStatusDTO maritalStatus)
        {
            string EnName = maritalStatus.ArName,
                  ArName = maritalStatus.EnName;
            var marital = Find(Id);
            if (EnName != null && ArName == null)
            {
                marital.EnName = EnName;
            }else if (EnName == null && ArName != null)
            {
                marital.ArName = ArName;
            }else if (EnName != null && ArName != null)
            {
                marital.ArName = ArName;
                marital.EnName = EnName;
            }
            else
            {
                return null;
            }
            marital.ModifiedOn = DateTime.Now;
            return _mapper.Map<MaritalStatusDTO>(marital);
        }
        public IEnumerable<MaritalStatusDTO> GetALL(int Pagesize = 4, int PageNumber = 1)
        {
            var allmarital = GetAll().Where(b => !b.IsDeleted);
            if (allmarital.Any())
            {
                return _mapper.Map<IEnumerable<MaritalStatusDTO>>(allmarital);
            }
            return null;
        }
        public MaritalStatusDTO Delete(int Id)
        {
            var entity = Find(Id);
            if (entity != null && !entity.IsDeleted)
            {
                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                return _mapper.Map<MaritalStatusDTO>(entity);
            }
            return null;
        }
        public IEnumerable<AllMaritalStatusDTO> GetALLByLang(string Lang="en",int Pagesize = 4, int PageNumber = 1)
        {
            var allmarital = GetAll().Where(b => !b.IsDeleted);
            if (allmarital.Any())
            {
                if (Lang.ToLower() == "en")
                {
                    return _mapper.Map<IEnumerable<AllMaritalStatusDTO>>(allmarital.Select(b => new AllMaritalStatusDTO() { Name = b.EnName }));
                }
                else
                {
                    return _mapper.Map<IEnumerable<AllMaritalStatusDTO>>(allmarital.Select(b => new AllMaritalStatusDTO() { Name = b.ArName }));
                }
            }
            return null;
        }
    }
}
