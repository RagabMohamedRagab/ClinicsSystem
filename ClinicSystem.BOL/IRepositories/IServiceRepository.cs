using ClinicSystem.Models.DTOS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IRepositories {
    public interface IServiceRepository {
        ServiceCreateDTO Create(ServiceDTO service,string Path);
        ServiceCreateDTO Update(ServiceUpdateDTO service,string path);
        ServiceCreateDTO FindById(int Id);
    }
}
