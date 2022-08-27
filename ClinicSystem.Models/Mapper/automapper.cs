using AutoMapper;
using ClinicSystem.DAL.Domains;
using ClinicSystem.Models.DTOS.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Models.Mapper {
    public class automapper : Profile {
        public automapper()
        {
            // CreateMap<DataType,Data>();

            #region Department
         CreateMap<DepartMent, DepartMentDTO>().ReverseMap();
            #endregion
        }
    }
}
