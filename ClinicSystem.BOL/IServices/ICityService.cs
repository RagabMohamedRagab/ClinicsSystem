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
        ResponseObject Update(int Id, CityUpdateDTO city);
    }
}
