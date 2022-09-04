using ClinicSystem.BOL.IRepositories;
using ClinicSystem.BOL.IServices;
using ClinicSystem.Helpers.Enums;
using ClinicSystem.Models.DTOS.Gender;
using ClinicSystem.Models.ResponseObjects;
using ClinicSystem.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BLL.Services {
    public class GenderService : IGenderService {
        private readonly IGenderRepository _genderRepository;
        private readonly IUnitOfWorkPattern _unit;
        public GenderService(IGenderRepository genderRepository, IUnitOfWorkPattern unit)
        {
            _genderRepository = genderRepository;
            _unit = unit;
        }

        public ResponseObject Create(GenderDTO gender)
        {
            ResponseObject response = new ResponseObject();
            if (gender == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                return response;
            }
            if (string.IsNullOrEmpty(gender.ArGender) || string.IsNullOrEmpty(gender.EnGender))
            {
                response.ErrorMessage = ErrorsCodes.NamesAreNull.ToString();
                return response;
            }
            try
            {
                var entity = _genderRepository.Create(gender);
                if (entity == null)
                {
                    response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                    return response;
                }
                if (_unit.Commit() > 0)
                {
                    response.ErrorMessage = ErrorsCodes.Success.ToString();
                    response.Data = entity;
                    return response;
                }
                response.ErrorMessage = ErrorsCodes.InvalidAdd.ToString();
                return response;
            }
            catch (Exception)
            {
                response.ErrorMessage = ErrorsCodes.ThrowException.ToString();
                return response;
            }

        }

        public ResponseObject Update(int Id, GenderDTO gender)
        {
            ResponseObject response = new ResponseObject();
            if (Id <= 0)
            {
                response.ErrorMessage = ErrorsCodes.IDNotValid.ToString();
                return response;
            }
            if (gender == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                return response;
            }
            try
            {
                var entity = _genderRepository.Update(Id, gender);
                if (entity == null)
                {
                    response.ErrorMessage = ErrorsCodes.NotFound.ToString();
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
        public ResponseObject Delete(int Id)
        {
            ResponseObject response = new ResponseObject();
            if (Id <= 0)
            {
                response.ErrorMessage = ErrorsCodes.IDNotValid.ToString();
                return response;
            }
            var data = _genderRepository.Delete(Id);
            if (data == null)
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
            response.Data = "Falied";
            return response;
        }
        public ResponseObject GetAllGender(int PageSize = 4, int PageNumber = 1)
        {
            ResponseObject response = new ResponseObject();
            if (PageNumber <= 0 || PageNumber <= 0)
            {
                response.ErrorMessage = ErrorsCodes.IDNotValid.ToString();
                return response;
            }
            var allgenders = _genderRepository.GetAllGenders(PageSize, PageNumber);
            if (allgenders.Any())
            {
                response.ErrorMessage = ErrorsCodes.Success.ToString();
                response.Data = allgenders;
                return response;
            }

            response.ErrorMessage = ErrorsCodes.NotFound.ToString();
            return response;

        }
        public ResponseObject GetAllByLange(string Lang = "en", int PageSize = 4, int PageNumber = 1)
        {
            ResponseObject response = new ResponseObject();
            if (String.IsNullOrEmpty(Lang) || PageNumber <= 0 || PageSize <= 0)
            {
                response.ErrorMessage = ErrorsCodes.ParameteresNotCorrect.ToString();
                return response;
            }
            var allGender = _genderRepository.GetAllByLange(Lang, PageSize, PageNumber);
            if (allGender.Any())
            {
                response.ErrorMessage = ErrorsCodes.Success.ToString();
                response.Data = allGender;
                return response;
            }
            response.ErrorMessage = ErrorsCodes.NotFound.ToString();
            return response;
        }
        public ResponseObject FindByName(string Name)
        {
            ResponseObject response = new ResponseObject();
            if (String.IsNullOrEmpty(Name)) { 
              response.ErrorMessage=ErrorsCodes.NamesAreNull.ToString();
                return response;
            }
            var entity = _genderRepository.FindByName(Name);
            if(entity != null)
            {
                response.ErrorMessage = ErrorsCodes.Success.ToString();
                response.Data = entity;
                return response;
            }
            response.ErrorMessage = ErrorsCodes.NotFound.ToString();
            return response;
        }
        public ResponseObject FindById(int Id)
        {
            ResponseObject response= new ResponseObject();
            if (Id <= 0)
            {
                response.ErrorMessage = ErrorsCodes.IDNotValid.ToString();
                return response;
            }
            var data=_genderRepository.FindById(Id);
            if(data != null)
            {
                response.ErrorMessage = ErrorsCodes.Success.ToString();
                response.Data = data;
                return response;
            }
            response.ErrorMessage = ErrorsCodes.NotFound.ToString();
            return response;
        }
    }
}


