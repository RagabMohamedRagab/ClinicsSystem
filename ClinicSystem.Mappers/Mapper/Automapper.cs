using AutoMapper;
using ClinicSystem.DAL.Domains;
using ClinicSystem.Models.DTOS.City;
using ClinicSystem.Models.DTOS.Country;
using ClinicSystem.Models.DTOS.Department;
using ClinicSystem.Models.DTOS.Gender;
using ClinicSystem.Models.DTOS.MaritalStatus;
using ClinicSystem.Models.DTOS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Mappers.Mapper {
    public class Automapper : Profile {
        public Automapper()
        {
            // CreateMap<DataType,Data>();

            #region Department
         CreateMap<DepartMent, DepartMentDTO>().ReverseMap();
            #endregion
            #region Country
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CountryCreateDTO>().ReverseMap();
            CreateMap<CountryDTO, CountryCreateDTO>().ReverseMap();
            #endregion
            #region City
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<City, CityUpdateDTO>().ReverseMap();
            CreateMap<City, allCitiesDTO>().ReverseMap();
            #endregion
            #region Services
            CreateMap<ServiceDTO, Service>().ReverseMap();
            CreateMap<ServiceUpdate, Service>().ReverseMap();
            CreateMap<ServiceCreateDTO, Service>().ReverseMap();
            #endregion
            #region Genders
            CreateMap<Gender, GenderDTO>().ReverseMap();
            CreateMap<Gender, GenderByName>().ReverseMap();
            #endregion
            #region MaritalStatus
            CreateMap<MaritalStatus, MaritalStatusDTO>().ReverseMap();
            CreateMap<MaritalStatus, AllMaritalStatusDTO>().ReverseMap();
            #endregion
        }
    }
}
