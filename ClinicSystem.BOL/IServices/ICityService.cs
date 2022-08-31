using ClinicSystem.Models.DTOS.City;
using ClinicSystem.Models.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IServices {
    public interface ICityService {
        ResponseObject Create(CityDTO cityDTO);
        ResponseObject Delete(int Id);
        ResponseObject Update(int Id, CityDTO city);
        ResponseObject  GetAll(int Pagesize = 4, int PageNumber = 1);
        ResponseObject GetAllByLang(string lang = "en", int Pagesize = 4, int PageNumber = 1);
        ResponseObject SearchByName(string Name);
        ResponseObject SearchById(int id);
        ResponseObject DropDownListCities(int Id);


    }
}
