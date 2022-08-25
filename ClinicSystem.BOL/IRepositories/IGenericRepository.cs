using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IRepositories {
    public interface IGenericRepository<EntityEntry> where EntityEntry : class {
        EntityEntry<EntityEntry> Create(EntityEntry model);
        EntityEntry Update(EntityEntry model);
       void Delete(EntityEntry model);
       IEnumerable<EntityEntry> GetAll();
    }
}
