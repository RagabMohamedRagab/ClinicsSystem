using ClinicSystem.Models.DTOS.Gender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IRepositories {
    public interface IGenderRepository {
        GenderDTO Create(GenderDTO gender);
        GenderDTO Update(int Id,GenderDTO gender);
        GenderDTO Delete(int Id);
        IEnumerable<GenderDTO> GetAllGenders(int PageSize = 4,int PageNumber=1);
        IEnumerable<GenderByName> GetAllByLange(string Lang="en",int PageSize = 4,int PageNumber=1);
        IEnumerable<GenderDTO> FindByName(string Name);
        GenderDTO FindById(int Id);

    }
}
