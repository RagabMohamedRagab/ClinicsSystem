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
                return response;
            }
            if (service.File == null)
            {
                response.ErrorMessage = ErrorsCodes.ImageIsNotValid.ToString();
                return response;
            }

            Path = _fileService.Create(service.File, Folder.Services);
            if (Path == null)
            {
                response.ErrorMessage = ErrorsCodes.ImageIsNotValid.ToString();
                return response;
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

        public ResponseObject Update(int Id,ServiceUpdateDTO service)
        {
            ResponseObject response = new ResponseObject();
            if (Id <= 0)
            {
                response.ErrorMessage = ErrorsCodes.IDNotValid.ToString();
                return response;
            }
            if (service == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                return response;
            }
            if (string.IsNullOrEmpty(service.Note))
            {
                response.ErrorMessage=ErrorsCodes.ParameteresNotCorrect.ToString();
                return response;
            }
            if (service.File == null)
            {
                _serviceRepository.Update(service,null);
            }
            else
            {

               if(_serviceRepository.Update(service, service.File.FileName) != null)
                {

                }
            }
            return null;
        }
        public ResponseObject FindById(int Id)
        {
            ResponseObject response = new ResponseObject();
            if (Id <= 0)
            {
                response.ErrorMessage = ErrorsCodes.IDNotValid.ToString();
                return response;
            }
            var entity= _serviceRepository.FindById(Id);
            if (entity == null)
            {
                response.ErrorMessage=ErrorsCodes.NotFound.ToString();
                return null;
            }
            response.ErrorMessage = ErrorsCodes.Success.ToString();
            response.Data = entity;
            return response;
        }
    }
}
