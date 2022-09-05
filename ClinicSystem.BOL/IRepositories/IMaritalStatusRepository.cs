using ClinicSystem.DAL.Domains;
using ClinicSystem.Models.DTOS.MaritalStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IRepositories {
    public interface IMaritalStatusRepository {
        MaritalStatusDTO Create(MaritalStatusDTO maritalStatus);
        MaritalStatusDTO Update(int Id,MaritalStatusDTO maritalStatus);
        IEnumerable<MaritalStatusDTO> GetALL(int Pagesize = 4, int PageNumber = 1);
        IEnumerable<AllMaritalStatusDTO> GetALLByLang(string Lang = "en", int Pagesize = 4, int PageNumber = 1);
        MaritalStatusDTO Delete(int Id);
        MaritalStatusDTO FindById(int Id);
        IEnumerable<MaritalStatusDTO> FindByName(string Name);
    }
}
