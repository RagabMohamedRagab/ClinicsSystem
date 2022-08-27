using ClinicSystem.Models.DTOS.Department;
using ClinicSystem.Models.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IServices {
    public interface IDepartMentService {
        ResponseObject Create(DepartMentDTO departMentDTO);
        ResponseObject Update(int Id,DepartMentDTO dTO);
        ResponseObject Delete(int Id);
        ResponseObject GetALLDepart(string lang = "en", int Pagesize = 4, int Pagenumber = 1);
    }
}
