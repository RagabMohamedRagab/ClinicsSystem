using ClinicSystem.Models.DTOS.MaritalStatus;
using ClinicSystem.Models.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IServices {
    public interface IMaritalStatusService {
     ResponseObject Create(MaritalStatusDTO maritalStatus);
        ResponseObject Update(int Id, MaritalStatusDTO maritalStatus);
        ResponseObject GetALL(int Pagesize = 4, int PageNumber = 1);
        ResponseObject Delete(int Id);
        ResponseObject GetALLByLang(string Lang = "en", int Pagesize = 4, int PageNumber = 1);
        ResponseObject FindById(int Id);
        ResponseObject FindByName(string Name);
    }
}
