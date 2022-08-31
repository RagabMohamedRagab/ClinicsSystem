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
                if (entity != null && !entity.IsDeleted)
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

        public CityDTO Update(int Id, CityDTO city)
        {
            try
            {
                string EName = city.EnName,
                    ArName = city.ArName;
                int?    CountryId = city.CountryID;
                var EntityDb = Find(Id);
                if (EntityDb != null && !EntityDb.IsDeleted)
                {
                    if (EName == null && ArName != null && CountryId != null)
                    {
                        EntityDb.ArName = ArName;
                        EntityDb.CountryID = CountryId;
                        EntityDb.ModifiedOn = DateTime.Now;

                    }
                    else if (ArName == null && EName != null && CountryId != null)
                    {
                        EntityDb.EnName = EName;
                        EntityDb.CountryID = CountryId;
                        EntityDb.ModifiedOn = DateTime.Now;

                    }
                    else if (CountryId == null && EName != null && ArName != null)
                    {
                        EntityDb.ArName = ArName;
                        EntityDb.EnName = EName;
                        EntityDb.ModifiedOn = DateTime.Now;
                    }
                    else if (CountryId == null && EName == null && ArName != null)
                    {
                        EntityDb.ArName = ArName;
                        EntityDb.ModifiedOn = DateTime.Now;

                    }
                    else if (CountryId != null && EName == null && ArName == null)
                    {
                        EntityDb.CountryID = CountryId;
                        EntityDb.ModifiedOn = DateTime.Now;

                    }
                    else if (CountryId == null && EName != null && ArName == null)
                    {
                        EntityDb.EnName = EName;
                        EntityDb.ModifiedOn = DateTime.Now;

                    }
                    else if (CountryId != null && EName != null && ArName != null)
                    {
                        EntityDb.EnName = EName;
                        EntityDb.ArName = ArName;
                        EntityDb.CountryID = CountryId;
                        EntityDb.ModifiedOn = DateTime.Now;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
                return _mapper.Map<CityDTO>(city);
            }
            catch (Exception)
            {

                return null;
            }

        }

        IEnumerable<CityDTO> ICityRespostory.GetAll(int Pagesize = 4, int PageNumber = 1)
        {
            try
            {
                var allcities = GetAll().Where(c => !c.IsDeleted);
                int skip = (PageNumber - 1) * Pagesize;
                if (allcities.Count() > 0)
                {
                    return _mapper.Map<IEnumerable<CityDTO>>(allcities.Skip(skip).Take(Pagesize));
                }
                return null;
            }
            catch (Exception)
            {
                return null;

            }


        }
        public IEnumerable<allCitiesDTO> GetAllByLang(string lang = "en", int Pagesize = 4, int PageNumber = 1)
        {
            try
            {
                var alldata = GetAll().Where(b => !b.IsDeleted);
                IEnumerable<allCitiesDTO> allCities = null;
                if (alldata.Any())
                {
                    if (lang == "en")
                    {
                        allCities = alldata.Select(c => new allCitiesDTO { Name = c.EnName, CountryID = c.CountryID });
                    }
                    else
                    {
                        allCities = alldata.Select(c => new allCitiesDTO { Name = c.ArName, CountryID = c.CountryID });
                    }
                    return allCities;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public IEnumerable<CityDTO> SearchByName(string Name)
        {
            try
            {
                var alldata = GetAll().Where(b => !b.IsDeleted);
                if (alldata.Count() > 0)
                {
                    var cities = alldata.Where(b => b.ArName.ToLower().Contains(Name.ToLower()) || b.EnName.ToLower().Contains(Name.ToLower()));
                    return _mapper.Map<IEnumerable<CityDTO>>(cities);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public CityDTO SearchById(int id)
        {
            try
            {
                var city = Find(id);
                if (city != null&!city.IsDeleted)
                {
                    return _mapper.Map<CityDTO>(city);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public IEnumerable<CityUpdateDTO> DropDownListCities(int Id)
        {
            throw new NotImplementedException();
        }
    }
}




