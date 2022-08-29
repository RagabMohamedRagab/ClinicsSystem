using AutoMapper;
using ClinicSystem.BOL.IRepositories;
using ClinicSystem.DAL.Context;
using ClinicSystem.DAL.Domains;
using ClinicSystem.Helpers.Enum;
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
                ArName = country.ArName,EnName = country.EnName,Logo = path
            };
            var entity=_mapper.Map<Country>(countrydto);
            if (entity != null)
            {
                Create(entity);
                countrydto.Logo = "/" + Folder.Countries.ToString() + "/" + path;
                return countrydto;
            }
            return null;
        }

        public CountryDTO Delete(int Id)
        {
            var result = Find(Id);
            if(result != null)
            {
                result.IsDeleted = true;
                result.DeletedOn = DateTime.Now;
            return   _mapper.Map<CountryDTO>(result);
            }
            return null;
        }

        public IEnumerable<CountryDTO> GetAllWithoutLang(int Pagesize = 4, int PageNumber = 1)
        {
            int skip = (PageNumber - 1) * Pagesize;
            var countries = GetAll().Where(b=>!b.IsDeleted);
            if (countries.Any())
            {
                countries = countries.Skip(skip).Take(Pagesize);
                return _mapper.Map<IEnumerable<CountryDTO>>(countries);
            }
            return null;
        }

        public IEnumerable<AllCountryDTO> GetAllByLang(string Lang = "en", int Pagesize = 4, int PageNumber = 1)
        {
            int skip = (PageNumber - 1) * Pagesize;
            var countries = GetAll().Where(b=>!b.IsDeleted);
            IEnumerable<AllCountryDTO> allCountries = null;
            if (countries.Any())
            {
                if (Lang.ToLower() == "en")
                {
                    allCountries = countries.Skip(skip).Take(Pagesize).Select(b => new AllCountryDTO() { Name = b.EnName, Logo = b.Logo });
                }
                else 
                {
                    allCountries = countries.Skip(skip).Take(Pagesize).Select(b => new AllCountryDTO() { Name = b.ArName, Logo = b.Logo });
                }
                return allCountries;
            }
            return null;
        }

     

        CountryDTO ICountryRepository.Find(int Id)
        {
            var country = Find(Id);
            if (country != null)
            {
                return _mapper.Map<CountryDTO>(country);
            }
            return null;
        }

        public CountryDTO Update(int Id, CountryCreateDTO country, string path)
        {
            throw new NotImplementedException();
        }
    }
}
