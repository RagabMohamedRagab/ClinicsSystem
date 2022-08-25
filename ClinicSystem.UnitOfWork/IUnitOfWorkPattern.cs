using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.UnitOfWork {
    public  interface IUnitOfWorkPattern : IDisposable {
        int Commit();
    }
}
