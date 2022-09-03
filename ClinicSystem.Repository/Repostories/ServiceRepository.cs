using AutoMapper;
using ClinicSystem.BOL.IRepositories;
using ClinicSystem.DAL.Context;
using ClinicSystem.DAL.Domains;
using ClinicSystem.Helpers.Enums;
using ClinicSystem.Models.DTOS.Service;
using ClinicSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Repositories.Repostories {
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository {
        private readonly IMapper _mapper;
        public ServiceRepository(ClinicDbContext clinic, IMapper mapper) : base(clinic)
        {
            _mapper = mapper;
        }

        public ServiceCreateDTO Create(ServiceDTO service, string Path)
        {
            try
            {
                ServiceCreateDTO createDTO = new ServiceCreateDTO()
                {
                    ArName = service.ArName,
                    EnName = service.EnName,
                    Price = service.Price,
                    ImageUrl = Path,
                    Notes = service.Note
                };
                var Newservice = _mapper.Map<Service>(createDTO);
                Create(Newservice);
                createDTO.ImageUrl = "/" + Folder.Services.ToString() + "/" + Path;
                return createDTO;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ServiceCreateDTO Update(int Id, ServiceUpdateDTO service)
        {
            string Note = service.Note,
                     Path = service.File.FileName;
            decimal price = service.Price;
            var entitDb = Find(Id);
            if (Note != null && Path == null && price <= 0)
            {
                entitDb.Notes = Note;
            }
            else if (Note == null && Path != null && price <= 0)
            {
                entitDb.ImageUrl = Path;
            }
            else if (Note == null && Path == null && price > 0)
            {
                entitDb.Price = price;
            }
            else if (Note != null && Path != null && price <= 0)
            {
                entitDb.ImageUrl = Path;
                entitDb.Notes = Note;
            }
            else if (Note == null && Path != null && price > 0)
            {
                entitDb.ImageUrl = Path;
                entitDb.Price = price;
            }
            else if (Note != null && Path == null && price > 0)
            {
                entitDb.ImageUrl = Path;
                entitDb.Notes = Note;
            }
            else if (Note != null && Path != null && price > 0)
            {
                entitDb.ImageUrl = Path;
                entitDb.Price = price;
                entitDb.Notes = Note;
            }
            else
            {
                return null;
            }
            entitDb.ModifiedOn = DateTime.Now;


            ServiceCreateDTO createDTO = new ServiceCreateDTO()
            {
                ArName = entitDb.ArName,
                EnName = entitDb.EnName,
                ImageUrl = "/" + Folder.Services.ToString() + "/" + entitDb.ImageUrl,
                Notes = entitDb.Notes,
                Price = entitDb.Price
            };
            return createDTO;
        }
        public ServiceCreateDTO FindById(int Id)
        {
            var entity = Find(Id);
            if (entity != null && !entity.IsDeleted)
            {
                var data = _mapper.Map<ServiceCreateDTO>(entity);
                data.ImageUrl = "/" + Folder.Services.ToString() + "/" + entity.ImageUrl;
                return data;
            }
            return null;
        }
        public string FindImag(int Id)
        {
            var data = Find(Id);
            if (data != null && !data.IsDeleted)
            {
                return data.ImageUrl;
            }
            return null;
        }
        public ServiceCreateDTO Delete(int Id)
        {
            var entityDb = Find(Id);
            if (entityDb != null && !entityDb.IsDeleted)
            {
                entityDb.IsDeleted = true;
                entityDb.ModifiedOn = DateTime.Now;
                return _mapper.Map<ServiceCreateDTO>(entityDb);
            }
            return null;
        }
        public IEnumerable<AllServices> GetAllWithLang(string lang = "en", int PageSize = 4, int PageNumber = 1)
        {
            int skip = (PageNumber - 1) * PageSize;
            var Data = GetAll().Where(b => !b.IsDeleted).Skip(skip).Take(PageSize);
            if (Data.Any())
            {
                if (lang.ToLower() == "en")
                {
                    return Data.Select(b => new AllServices()
                    {
                        Name = b.EnName,
                        Price = b.Price,
                        Notes = b.Notes,
                        ImageUrl = "/" + Folder.Services.ToString() + "/" + b.ImageUrl,
                    });
                }
                else
                {
                    return Data.Select(b => new AllServices()
                    {
                        Name = b.ArName,
                        Price = b.Price,
                        Notes = b.Notes,
                        ImageUrl = "/" + Folder.Services.ToString() + "/" + b.ImageUrl,
                    });
                }
            }
            return null;
        }
        public IEnumerable<ServiceCreateDTO> GetAllWithoutLang(int PageSize = 4, int PageNumber = 1)
        {
            int skip = (PageNumber - 1) * PageSize;
            var Data = GetAll().Where(b => !b.IsDeleted).Skip(skip).Take(PageSize);
            if (Data.Any())
            {
                return Data.Select(b => new ServiceCreateDTO()
                {
                    ArName = b.ArName,
                    EnName = b.EnName,
                    Price = b.Price,
                    Notes = b.Notes,
                    ImageUrl = "/" + Folder.Services.ToString() + "/" + b.ImageUrl,
                });
            }
            return null;
        }

        public IEnumerable<ServiceCreateDTO> FindByName(string Name)
        {
            var Data = GetAll().Where(b => !b.IsDeleted);
            if (Data.Any())
            {
                return Data.Where(b => b.ArName.ToLower().Contains(Name.ToLower()) || b.EnName.ToLower().Contains(Name.ToLower()))
                    .Select(a => new ServiceCreateDTO
                    {
                        ArName = a.ArName,
                        EnName = a.EnName,
                        Price = a.Price,
                        Notes = a.Notes,
                        ImageUrl = "/" + Folder.Services.ToString() + "/" + a.ImageUrl,
                    });
            }
            return null;
        }
    }
}




