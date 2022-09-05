using ClinicSystem.BOL.IRepositories;
using ClinicSystem.BOL.IServices;
using ClinicSystem.Helpers.Enums;
using ClinicSystem.Models.DTOS.MaritalStatus;
using ClinicSystem.Models.ResponseObjects;
using ClinicSystem.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BLL.Services {
    public class MaritalStatusService : IMaritalStatusService {
        private readonly IMaritalStatusRepository _statusRepository;
        private readonly IUnitOfWorkPattern _unit;
        public MaritalStatusService(IMaritalStatusRepository statusRepository, IUnitOfWorkPattern unit)
        {
            _statusRepository = statusRepository;
            _unit = unit;
        }

        public ResponseObject Create(MaritalStatusDTO maritalStatus)
        {
            ResponseObject response = new ResponseObject();
            if (maritalStatus == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                return response;
            }
            if (String.IsNullOrEmpty(maritalStatus.ArName) || String.IsNullOrEmpty(maritalStatus.EnName))
            {
                response.ErrorMessage = ErrorsCodes.NamesAreNull.ToString();
                return response;
            }
            try
            {
                var result = _statusRepository.Create(maritalStatus);
                if (result == null)
                {
                    response.ErrorMessage = ErrorsCodes.InvalidAdd.ToString();
                    return response;
                }
                if (_unit.Commit() > 0)
                {
                    response.ErrorMessage = ErrorsCodes.Success.ToString();
                    response.Data = result;
                    return response;
                }
                response.ErrorMessage = ErrorsCodes.NotSaveChangesInDatabase.ToString();
                return response;
            }
            catch (Exception)
            {
                response.ErrorMessage = ErrorsCodes.ThrowException.ToString();
                return response;
            }
        }
        public ResponseObject Update(int Id, MaritalStatusDTO maritalStatus)
        {
            ResponseObject response = new ResponseObject();
            if (Id <= 0)
            {
                response.ErrorMessage = ErrorsCodes.IDNotValid.ToString();
                return response;
            }
            if (maritalStatus == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                return response;
            }
            try
            {
                var entity = _statusRepository.Update(Id, maritalStatus);
                if (entity == null)
                {
                    response.ErrorMessage = ErrorsCodes.InvalidAdd.ToString();
                    return response;
                }
                if (_unit.Commit() > 0)
                {
                    response.ErrorMessage = ErrorsCodes.Success.ToString();
                    response.Data = entity;
                    return response;
                }
                response.ErrorMessage = ErrorsCodes.NotSaveChangesInDatabase.ToString();
                return response;
            }
            catch (Exception)
            {
                response.ErrorMessage = ErrorsCodes.ThrowException.ToString();
                return response;
            }

        }
     public   ResponseObject GetALL(int Pagesize = 4, int PageNumber = 1)
        {
            ResponseObject response = new ResponseObject();
            if (PageNumber <= 0 || Pagesize <= 0)
            {
                response.ErrorMessage = ErrorsCodes.ParameteresNotCorrect.ToString();
                return response;
            }
            var Data = _statusRepository.GetALL(Pagesize, PageNumber);
            if (Data.Any())
            {
                response.ErrorMessage = ErrorsCodes.Success.ToString();
                response.Data = Data;
                return response;
            }
            response.ErrorMessage = ErrorsCodes.NotFound.ToString();
            return response;
        }
        public ResponseObject Delete(int Id)
        {
            ResponseObject response = new ResponseObject();
            if (Id <= 0)
            {
                response.ErrorMessage = ErrorsCodes.IDNotValid.ToString();
                return response;
            }
            var entity = _statusRepository.Delete(Id);
            if (entity == null)
            {
                response.ErrorMessage = ErrorsCodes.NotFound.ToString();
                return response;
            }
            if (_unit.Commit() > 0)
            {
                response.ErrorMessage = ErrorsCodes.Success.ToString();
                response.Data = "Done";
                return response;
            }
            response.ErrorMessage = ErrorsCodes.InvalidDelete.ToString();
            response.Data = "Failed";
            return response;
        }
        public ResponseObject GetALLByLang(string Lang = "en", int Pagesize = 4, int PageNumber = 1)
        {
            ResponseObject response = new ResponseObject();
            if (String.IsNullOrEmpty(Lang) || PageNumber <= 0 || Pagesize <= 0)
            {
                response.ErrorMessage = ErrorsCodes.ParameteresNotCorrect.ToString();
                return response;
            }
            var all = _statusRepository.GetALLByLang(Lang, Pagesize, PageNumber);
            if (all.Any())
            {
                response.ErrorMessage = ErrorsCodes.Success.ToString();
                response.Data = all;
                return response;
            }
            response.ErrorMessage = ErrorsCodes.NotFound.ToString();
            return response;
        }
    }
}



