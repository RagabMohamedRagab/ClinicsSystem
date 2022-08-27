using ClinicSystem.DAL.Domains;
using ClinicSystem.Models.DTOS.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IRepositories {
    public interface IDepartmentRepository {
        DepartMentDTO Create(DepartMentDTO dTO);
        DepartMentDTO Update(int Id,DepartMentDTO dTO);
        DepartMentDTO Delete(int Id);
        IEnumerable<GetAllDepartDTOS> GetALLDepart(string lan = "en", int Pagesize = 4, int Pagenumber = 1);
    }
}
