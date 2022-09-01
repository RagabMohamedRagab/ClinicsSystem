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
    public class ServiceRepository :GenericRepository<Service>, IServiceRepository {
        private readonly IMapper _mapper;
        public ServiceRepository(ClinicDbContext clinic, IMapper mapper) : base(clinic)
        {
            _mapper = mapper;
        }

        public ServiceCreateDTO  Create(ServiceDTO service,string Path)
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
    }
}
