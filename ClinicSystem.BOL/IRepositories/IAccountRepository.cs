using ClinicSystem.Models.DTOS.Accounts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IRepositories {
    public interface IAccountRepository {
      Task<RegisterVM> Create(RegisterVM model,string Path);
    }
}
