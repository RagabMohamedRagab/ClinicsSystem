using ClinicSystem.Models.DTOS.Country;
using ClinicSystem.Models.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IServices {
    public interface ICountryService {
        ResponseObject Create(CountryCreateDTO country);
        ResponseObject Update(int Id, CountryCreateDTO country);
        ResponseObject Delete(int Id);
        ResponseObject GetAllByLang(string Lang = "en", int Pagesize = 4, int PageNumber = 1);
        ResponseObject GetAllWithoutLang(int Pagesize = 4, int PageNumber = 1);
        ResponseObject SearchByName(string Name);
        ResponseObject SearchById(int Id);
    }
}
