using ClinicSystem.BOL.IRepositories;
using ClinicSystem.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicSystem.Repository {
    public class GenericRepository<EntityEntry> : IGenericRepository<EntityEntry> where EntityEntry : class {
        private readonly ClinicDbContext _clinic;
        private readonly DbSet<EntityEntry> dbSet;

        public GenericRepository(ClinicDbContext clinic)
        {
            _clinic = clinic;
            dbSet = _clinic.Set<EntityEntry>();
        }

        public EntityEntry<EntityEntry> Create(EntityEntry model)
        {
            return dbSet.Add(model);
        }

        public void Delete(EntityEntry model)
        {
            dbSet.Remove(model);
        }
        public IEnumerable<EntityEntry> GetAll()
        {
            return dbSet;
        }

        public EntityEntry Update(EntityEntry model)
        {
            dbSet.Update(model);
            return model;
        }
    }
}




