using ClinicSystem.Models.DTOS.Service;
using ClinicSystem.Models.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IServices {
    public interface IServiceService {
        ResponseObject Create(ServiceDTO service);
        ResponseObject Update(int Id,ServiceUpdateDTO service);
       ResponseObject FindById(int Id);
        ResponseObject Delete(int Id);
        ResponseObject GetAllLang(string lang="en",int PageSize = 4, int PageNumber = 1);
        ResponseObject FindByName(string Name);
        ResponseObject GetAllWithoutLang( int PageSize = 4, int PageNumber = 1);

    }
}
