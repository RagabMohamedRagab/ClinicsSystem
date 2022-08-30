using AutoMapper;
using ClinicSystem.BOL.IRepositories;
using ClinicSystem.DAL.Context;
using ClinicSystem.DAL.Domains;
using ClinicSystem.Models.DTOS.City;
using ClinicSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Repositories.Repostories {
    public class CityRespostory : GenericRepository<City>, ICityRespostory {
        private readonly IMapper _mapper;
        public CityRespostory(ClinicDbContext clinic, IMapper mapper) : base(clinic)
        {
            _mapper = mapper;
        }

        public CityDTO Create(CityDTO city)
        {
            try
            {
                var entity = _mapper.Map<City>(city);
                Create(entity);
                return city;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public CityDTO Delete(int Id)
        {
            try
            {
                var entity = Find(Id);
                if (entity != null&&!entity.IsDeleted)
                {
                    entity.IsDeleted = true;
                    entity.DeletedOn = DateTime.Now;
                    return _mapper.Map<CityDTO>(entity);
                  }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public CityDTO Update(int Id, CityUpdateDTO city)
        {
            try
            {
                var entityDb = Find(Id);
                if(entityDb != null && !entityDb.IsDeleted)
                {
                    entityDb.EnName = city.EnName;
                    entityDb.ArName=city.ArName;
                    entityDb.ModifiedOn = DateTime.Now;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
            throw new NotImplementedException();
        }

        IEnumerable<CityDTO> ICityRespostory.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
