using AutoMapper;
using ClinicSystem.BOL.IRepositories;
using ClinicSystem.DAL.Context;
using ClinicSystem.DAL.Domains;
using ClinicSystem.Models.DTOS.Gender;
using ClinicSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Repositories.Repostories {
    public class GenderRepository : GenericRepository<Gender>, IGenderRepository {
        private readonly IMapper _mapper;
        public GenderRepository(ClinicDbContext clinic, IMapper mapper) : base(clinic)
        {
            _mapper = mapper;
        }

        public GenderDTO Create(GenderDTO model)
        {
            try
            {
                var gender = _mapper.Map<Gender>(model);
                Create(gender);
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public GenderDTO Update(int Id, GenderDTO gender)
        {
            var entityDb = Find(Id);
            if (entityDb != null && !entityDb.IsDeleted)
            {
                if (gender.ArGender == null && gender.EnGender == null)
                {
                    return null;
                }
                else if (gender.ArGender != null && gender.EnGender == null)
                {
                    entityDb.ArGender = gender.ArGender;
                }
                else if (gender.ArGender == null && gender.EnGender != null)
                {
                    entityDb.EnGender = gender.EnGender;
                }
                else if (gender.ArGender != null && gender.EnGender != null)
                {
                    entityDb.ArGender = gender.ArGender;
                    entityDb.EnGender = gender.EnGender;
                }
                entityDb.ModifiedOn = DateTime.Now;
                return _mapper.Map<GenderDTO>(entityDb);
            }
            return null;
        }
        public GenderDTO Delete(int Id)
        {
            var entity = Find(Id);
            if (entity != null && !entity.IsDeleted)
            {
                entity.IsDeleted = true;
                entity.DeletedOn = DateTime.Now;
                return _mapper.Map<GenderDTO>(entity);
            }
            return null;
        }
        public IEnumerable<GenderDTO> GetAllGenders(int PageSize = 4, int PageNumber = 1)
        {
            var allGender = GetAll().Where(b => !b.IsDeleted);
            if (allGender.Any())
            {
                return _mapper.Map<IEnumerable<GenderDTO>>(allGender);
            }
            return null;
        }
        public IEnumerable<GenderByName> GetAllByLange(string Lang = "en", int PageSize = 4, int PageNumber = 1)
        {
            var allGender = GetAll().Where(b => !b.IsDeleted);
            if (allGender.Any())
            {
                if (Lang.ToLower() == "en")
                {
                    return _mapper.Map<IEnumerable<GenderByName>>(allGender.Select(b => new GenderByName() { Name = b.EnGender }));
                }
                else
                {
                    return _mapper.Map<IEnumerable<GenderByName>>(allGender.Select(b => new GenderByName() { Name = b.ArGender }));
                }
            }
            return null;
        }
        public IEnumerable<GenderDTO> FindByName(string Name)
        {
            var allGender = GetAll().Where(b => !b.IsDeleted);
            if (allGender.Any())
            {
                return _mapper.Map<IEnumerable<GenderDTO>>(allGender.Where(b => b.EnGender.ToLower().Contains(Name.ToLower()) || b.ArGender.ToLower().Contains(Name.ToLower())));
            }
            return null;
        }
        public GenderDTO FindById(int Id)
        {
            var entity = Find(Id);
            if (entity != null && !entity.IsDeleted)
            {
                return _mapper.Map<GenderDTO>(entity);
            }
            return null;

        }
    }
}


