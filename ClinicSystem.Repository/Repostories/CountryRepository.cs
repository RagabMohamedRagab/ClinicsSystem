using AutoMapper;
using ClinicSystem.BOL.IRepositories;
using ClinicSystem.DAL.Context;
using ClinicSystem.DAL.Domains;
using ClinicSystem.Helpers.Enums;
using ClinicSystem.Models.DTOS.Country;
using ClinicSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Repositories.Repostories {
    public class CountryRepository : GenericRepository<Country>, ICountryRepository {
        private readonly IMapper _mapper;
        public CountryRepository(ClinicDbContext clinic, IMapper mapper) : base(clinic)
        {
            _mapper = mapper;
        }
        public CountryDTO Create(CountryCreateDTO country, string path)
        {
            CountryDTO countrydto = new CountryDTO()
            {
                ArName = country.ArName, EnName = country.EnName, Logo = path
            };
            var entity = _mapper.Map<Country>(countrydto);
            if (entity != null)
            {
                Create(entity);
                countrydto.Logo ="/Countries/"+  path;
                return countrydto;
            }
            return null;
        }

        public CountryDTO Delete(int Id)
        {
            var result = Find(Id);
            if (result != null && !result.IsDeleted) 
            {
                result.IsDeleted = true;
                result.DeletedOn = DateTime.Now;
                return _mapper.Map<CountryDTO>(result);
            }
            return null;
        }

        public IEnumerable<CountryDTO> GetAllWithoutLang(int Pagesize = 4, int PageNumber = 1)
        {
            int skip = (PageNumber - 1) * Pagesize;
            var countries = GetAll().Where(b => !b.IsDeleted);
            if (countries.Any())
            {
                countries = countries.Skip(skip).Take(Pagesize);
               
              var allcountries=_mapper.Map<IEnumerable<CountryDTO>>(countries);
                foreach (var item in allcountries)
                {
                    item.Logo = "/Countries/"+  item.Logo;
                }
                return allcountries;
            }
            return null;
        }

        public IEnumerable<AllCountryDTO> GetAllByLang(string Lang = "en", int Pagesize = 4, int PageNumber = 1)
        {
            int skip = (PageNumber - 1) * Pagesize;
            var countries = GetAll().Where(b => !b.IsDeleted);
            IEnumerable<AllCountryDTO> allCountries = null;
            if (countries.Any())
            {
                if (Lang.ToLower() == "en")
                {
                    allCountries = countries.Skip(skip).Take(Pagesize).Select(b => new AllCountryDTO() { Name = b.EnName, Logo = "/" + Folder.Countries.ToString() + "/" + b.Logo});
                }
                else
                {
                    allCountries = countries.Skip(skip).Take(Pagesize).Select(b => new AllCountryDTO() { Name = b.ArName, Logo  = "/" + Folder.Countries.ToString() + "/" + b.Logo });
                }
                return allCountries;
            }
            return null;
        }



        CountryDTO ICountryRepository.Find(int Id)
        {
            var country = Find(Id);
            if (country != null && !country.IsDeleted) 
            {
               var countrydto=_mapper.Map<CountryDTO>(country);
                countrydto.Logo =  countrydto.Logo;
                return countrydto;
            }
            return null;
        }

        public CountryDTO Update(int Id, CountryCreateDTO country, string path)
        {
            string EName = country.EnName,
                          ArName = country.ArName,
                          PathUrl = path;
            var EntityDb = Find(Id);
            if (!EntityDb.IsDeleted&&EntityDb!=null)
            {

                if (EName == null && ArName != null && PathUrl != null)
                {
                    EntityDb.ArName = ArName;
                    EntityDb.Logo = PathUrl;
                    EntityDb.ModifiedOn = DateTime.Now;

                }
                else if (ArName == null && EName != null && PathUrl != null)
                {
                    EntityDb.EnName = EName;
                    EntityDb.Logo = PathUrl;
                    EntityDb.ModifiedOn = DateTime.Now;

                }
                else if (PathUrl == null && EName != null && ArName != null)
                {
                    EntityDb.ArName = ArName;
                    EntityDb.EnName = EName;
                    EntityDb.ModifiedOn = DateTime.Now;
                }
                else if (PathUrl == null && EName == null && ArName != null)
                {
                    EntityDb.ArName = ArName;
                    EntityDb.ModifiedOn = DateTime.Now;

                }
                else if (PathUrl != null && EName == null && ArName == null)
                {
                    EntityDb.Logo = PathUrl;
                    EntityDb.ModifiedOn = DateTime.Now;

                }
                else if (PathUrl == null && EName != null && ArName == null)
                {
                    EntityDb.EnName = EName;
                    EntityDb.ModifiedOn = DateTime.Now;

                }
                else if (PathUrl != null && EName != null && ArName != null)
                {
                    EntityDb.EnName = EName;
                    EntityDb.ArName = ArName;
                    EntityDb.Logo = PathUrl;
                    EntityDb.ModifiedOn = DateTime.Now;
                }
                else
                {
                    return null;
                }

                CountryDTO dTO = new CountryDTO()
                {
                    ArName = EntityDb.ArName,
                    EnName = EntityDb.EnName,
                    Logo = "/Countries/" + EntityDb.Logo,
                };
                return dTO;
            }
            return null;
        }
        public IEnumerable<CountryDTO> SearchByName(string Name)
        {
            var result = GetAll().Where(b => !b.IsDeleted ).Where(b=>b.EnName.ToLower().Contains(Name.ToLower())|| b.ArName.ToLower().Contains(Name.ToLower()));
            if (result.Count()>0)
            {
                return result.Select(b => new CountryDTO() { ArName = b.ArName, EnName = b.EnName, Logo = "/" + Folder.Countries.ToString() + "/" + b.Logo, });
            }
            return null;
        }
    }
}

