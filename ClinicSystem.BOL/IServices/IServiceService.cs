using ClinicSystem.Models.DTOS.Service;
using ClinicSystem.Models.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IServices {
    public interface IServiceService {
        ResponseObject Create(ServiceDTO service);
        ResponseObject Update(int Id,ServiceUpdateDTO service);
       ResponseObject FindById(int Id);
        ResponseObject Delete(int Id);

    }
}
