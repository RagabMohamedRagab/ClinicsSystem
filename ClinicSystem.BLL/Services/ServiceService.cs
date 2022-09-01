using ClinicSystem.BOL.IRepositories;
using ClinicSystem.BOL.IServices;
using ClinicSystem.Helpers.Enums;
using ClinicSystem.Models.DTOS.Service;
using ClinicSystem.Models.ResponseObjects;
using ClinicSystem.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BLL.Services {
    public class ServiceService : IServiceService {
        private readonly IServiceRepository _serviceRepository;
        private readonly IFileService _fileService;
        private readonly IUnitOfWorkPattern _unit;

        public ServiceService(IUnitOfWorkPattern unit, IServiceRepository serviceRepository, IFileService fileService)
        {
            _unit = unit;
            _serviceRepository = serviceRepository;
            _fileService = fileService;
        }

        public ResponseObject Create(ServiceDTO service)
        {
            ResponseObject response = new ResponseObject();
            string Path = String.Empty;
            if (service == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
            }
            if (service.File == null)
            {
                response.ErrorMessage = ErrorsCodes.ImageIsNotValid.ToString();
                return null;
            }

            Path = _fileService.Create(service.File, Folder.Services);
            if (Path == null)
            {
                response.ErrorMessage = ErrorsCodes.ImageIsNotValid.ToString();
                return null;
            }
            var result = _serviceRepository.Create(service, Path);
            if (result == null)
            {
                _fileService.Remove(Path, Folder.Services);
                response.ErrorMessage = ErrorsCodes.InvalidAdd.ToString();
                return response;
            }
            if (_unit.Commit() < 0)
            {
                _fileService.Remove(Path, Folder.Services);
                response.ErrorMessage = ErrorsCodes.InvalidAdd.ToString();
                return response;
            }
            response.ErrorMessage = ErrorsCodes.Success.ToString();
            response.Data = result;
            return response;

        }
    }
}
