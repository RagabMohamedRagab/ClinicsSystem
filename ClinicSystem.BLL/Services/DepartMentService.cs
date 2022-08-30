using ClinicSystem.BOL.IRepositories;
using ClinicSystem.BOL.IServices;
using ClinicSystem.Helpers.Enums;
using ClinicSystem.Models.DTOS.Department;
using ClinicSystem.Models.ResponseObjects;
using ClinicSystem.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BLL.Services {
    public class DepartMentService : IDepartMentService {
        private readonly IDepartmentRepository _department;
        private readonly IUnitOfWorkPattern _unit;
        public DepartMentService(IDepartmentRepository department, IUnitOfWorkPattern unit)
        {
            _department = department;
            _unit = unit;
        }
        public ResponseObject Create(DepartMentDTO departMentDTO)
        {
            ResponseObject responseObject = new ResponseObject();
            if (departMentDTO == null)
            {
                responseObject.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                return responseObject;
            }
            if (String.IsNullOrEmpty(departMentDTO.ArName) && String.IsNullOrEmpty(departMentDTO.EnName))
            {
                responseObject.ErrorMessage = ErrorsCodes.NamesAreNull.ToString();
                return responseObject;
            }
            try
            {
                if (_department.Create(departMentDTO) != null)
                {
                    if (_unit.Commit() > 0)
                    {
                        responseObject.ErrorMessage = ErrorsCodes.Success.ToString();
                        responseObject.Data = departMentDTO;
                        return responseObject;
                    }
                }
            }
            catch (Exception)
            {
                responseObject.ErrorMessage = ErrorsCodes.NotSaveChangesInDatabase.ToString();
                return responseObject;
            }
            responseObject.ErrorMessage = ErrorsCodes.NotSaveChangesInDatabase.ToString();
            return responseObject;
        }
        public ResponseObject Delete(int Id)
        {
            ResponseObject responseObject = new ResponseObject();
            if (Id <= 0)
            {
                responseObject.ErrorMessage = ErrorsCodes.IDNotValid.ToString();
                return responseObject;
            }
            var department = _department.Delete(Id);
            if (department == null)
            {
                responseObject.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                return responseObject;
            }
            try
            {
                if (_unit.Commit() > 0)
                {
                    responseObject.ErrorMessage = ErrorsCodes.Success.ToString();
                    responseObject.Data = department;
                    return responseObject;
                }

            }
            catch (Exception)
            {
                responseObject.ErrorMessage = ErrorsCodes.ThrowException.ToString();
                return responseObject;
            }

            responseObject.ErrorMessage = ErrorsCodes.NotSaveChangesInDatabase.ToString();
            return responseObject;
        }

        public ResponseObject Find(string Name)
        {
            ResponseObject responseObject = new ResponseObject();
            if (String.IsNullOrEmpty(Name))
            {
                responseObject.ErrorMessage = ErrorsCodes.ParameteresNotCorrect.ToString();
                return null;
            }
              var depart=_department.Find(Name);
            if(depart != null)
            {
                responseObject.ErrorMessage = ErrorsCodes.Success.ToString();
                responseObject.Data = depart;
                return responseObject;
            }
            responseObject.ErrorMessage = ErrorsCodes.NotFound.ToString();
            return responseObject;
        }

        public ResponseObject GetALLDepart(string lan= "en", int Pagesize=4,int Pagenumber = 1) 
        {
            ResponseObject response = new ResponseObject();
            if (String.IsNullOrEmpty(lan)|| Pagenumber == 0 || Pagesize == 0)
            {
               response.ErrorMessage=ErrorsCodes.ParameteresNotCorrect.ToString();
                return response;
            }
           
            var departments = _department.GetALLByLang(lan, Pagesize, Pagenumber);
            if (departments == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                return response;
            }
            response.Data = departments;
            return response;
        }

        public ResponseObject GetAllWithOutLang(int Pagesize = 4, int Pagenumber = 1)
        {
            ResponseObject response = new ResponseObject();
            if ( Pagenumber == 0 || Pagesize == 0)
            {
                response.ErrorMessage = ErrorsCodes.ParameteresNotCorrect.ToString();
                return response;
            }

            var departments = _department.GetAllWithOutLang(Pagesize, Pagenumber);
            if (departments == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                return response;
            }
            response.Data = departments;
            return response;
        }

        public ResponseObject Update(int Id,DepartMentDTO dTO)
        {
            ResponseObject response = new ResponseObject();
            if (Id <= 0)
            {
                response.ErrorMessage = ErrorsCodes.ParameteresNotCorrect.ToString();
                return response;
            }
            if (dTO == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                return response;
            }
            var UpdateDepart = _department.Update(Id,dTO);
            if (UpdateDepart == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidUpadte.ToString();
                return response;
            }
            try
            {
                if (_unit.Commit() > 0)
                {
                    response.ErrorMessage = ErrorsCodes.Success.ToString();
                    response.Data = UpdateDepart;
                    return response;
                }
            }
            catch (Exception)
            {

                response.ErrorMessage = ErrorsCodes.ThrowException.ToString();
                return response;
            }
            response.ErrorMessage = ErrorsCodes.NotSaveChangesInDatabase.ToString();
            return response;
        }
      public  ResponseObject FindById(int Id)
        {
            ResponseObject response=new ResponseObject();
            if(Id <= 0)
            {
                response.ErrorMessage = ErrorsCodes.IDNotValid.ToString();
                return response;
            }
            var depart= _department.FindById(Id);
            if(depart == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                return response;
            }
            response.ErrorMessage = ErrorsCodes.Success.ToString();
            response.Data = depart;
            return response;
        }
    }
}







