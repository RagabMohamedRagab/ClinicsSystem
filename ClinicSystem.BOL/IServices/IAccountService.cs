using ClinicSystem.Models.DTOS.Accounts;

using ClinicSystem.Models.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IServices {
    public interface IAccountService {
     ResponseObject Create(RegisterVM model);
    }
}
