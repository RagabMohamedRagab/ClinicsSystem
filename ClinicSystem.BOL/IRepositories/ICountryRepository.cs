using ClinicSystem.Models.DTOS.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IRepositories {
    public interface ICountryRepository {
        CountryDTO Create(CountryCreateDTO country,string path);
        CountryDTO Update(int Id,CountryCreateDTO country,string path);
        CountryDTO Delete(int Id);
        IEnumerable<AllCountryDTO> GetAllByLang(string Lang="en",int Pagesize=4,int PageNumber=1);
        IEnumerable<CountryDTO> GetAllWithoutLang(int Pagesize = 4, int PageNumber = 1);
        CountryDTO Find(int Id);
        IEnumerable<CountryDTO> SearchByName(string Name);

    }
}
