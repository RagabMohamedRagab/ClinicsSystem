using ClinicSystem.Models.DTOS.Gender;
using ClinicSystem.Models.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IServices {
    public interface IGenderService {
        ResponseObject Create(GenderDTO gender);
        ResponseObject Update(int Id, GenderDTO gender);
        ResponseObject Delete(int Id);
        ResponseObject GetAllGender(int PageSize = 4, int PageNumber = 1);
        ResponseObject GetAllByLange(string Lang = "en", int PageSize = 4, int PageNumber = 1);
        ResponseObject FindByName(string Name);
        ResponseObject FindById(int Id);
    }
}
