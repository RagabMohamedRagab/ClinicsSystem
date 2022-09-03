using ClinicSystem.Models.DTOS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IRepositories {
    public interface IServiceRepository {
        ServiceCreateDTO Create(ServiceDTO service,string Path);
        ServiceCreateDTO Update(int Id,ServiceUpdateDTO service);
        ServiceCreateDTO FindById(int Id);
        string FindImag(int Id);
        ServiceCreateDTO Delete(int Id);
        IEnumerable<AllServices> GetAllWithLang(string lang="en",int PageSize=4,int PageNumber=1);
        IEnumerable<ServiceCreateDTO> FindByName(string Name);
        IEnumerable<ServiceCreateDTO> GetAllWithoutLang( int PageSize = 4, int PageNumber = 1);
    }
}
