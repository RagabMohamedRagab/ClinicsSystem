using AutoMapper;
using ClinicSystem.DAL.Domains;
using ClinicSystem.Models.DTOS.Country;
using ClinicSystem.Models.DTOS.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Models.Mapper {
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
        }
    }
}
