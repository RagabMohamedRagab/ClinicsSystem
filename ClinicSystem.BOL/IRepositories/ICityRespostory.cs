using ClinicSystem.Models.DTOS.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IRepositories {
    public interface ICityRespostory {
        CityDTO Create(CityDTO city);
        CityDTO Update(int Id, CityUpdateDTO city);
        CityDTO Delete(int Id);
        IEnumerable<CityDTO> GetAll(int Pagesize=4,int PageNumber=1);
        IEnumerable<allCitiesDTO> GetAllByLang(string lang="en",int Pagesize = 4, int PageNumber = 1);
        IEnumerable<CityDTO> SearchByName(string Name);
     CityDTO SearchById(int id);
    }
}
