using ClinicSystem.BOL.IRepositories;
using ClinicSystem.BOL.IServices;
using ClinicSystem.Helpers.Enums;
using ClinicSystem.Models.DTOS.City;
using ClinicSystem.Models.ResponseObjects;
using ClinicSystem.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BLL.Services {
    public class CityService : ICityService {
        private readonly ICityRespostory _cityRespostory;
        private readonly IUnitOfWorkPattern _unit;
        public CityService(ICityRespostory cityRespostory, IUnitOfWorkPattern unit)
        {
            _cityRespostory = cityRespostory;
            _unit = unit;
        }

        public ResponseObject Create(CityDTO cityDTO)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                if (cityDTO == null)
                {
                    response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                    return response;
                }
                if (String.IsNullOrEmpty(cityDTO.ArName) || String.IsNullOrEmpty(cityDTO.EnName))
                {
                    response.ErrorMessage = ErrorsCodes.NamesAreNull.ToString();
                    return response;
                }
                var citydto = _cityRespostory.Create(cityDTO);
                if (citydto == null)
                {
                    response.ErrorMessage = ErrorsCodes.InvalidAdd.ToString();
                    return response;
                }
                if (_unit.Commit() > 0)
                {
                    response.ErrorMessage = ErrorsCodes.Success.ToString();
                    response.Data = citydto;
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
            try
            {
                if (Id <=0) {
                    response.ErrorMessage = ErrorsCodes.IDNotValid.ToString();
                    return response;
                }
                var result = _cityRespostory.Delete(Id);
                if(result != null)
                {
                    if (_unit.Commit() > 0)
                    {
                        response.ErrorMessage = ErrorsCodes.Success.ToString();
                        response.Data = result;
                        return response ;
                    }
                }
                response.ErrorMessage = ErrorsCodes.NotFound.ToString();
                return response;
            }
            catch (Exception)
            {
                response.ErrorMessage = ErrorsCodes.ThrowException.ToString();
                return response;
                
            }
        }

        public ResponseObject Update(int Id, CityUpdateDTO city)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                if (Id <= 0)
                {
                    response.ErrorMessage = ErrorsCodes.IDNotValid.ToString();
                    return response;
                
                }
                if (city == null)
                {
                    response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                    return response;
                }
                if (String.IsNullOrEmpty(city.ArName) || String.IsNullOrEmpty(city.EnName))
                {
                    response.ErrorMessage = ErrorsCodes.NamesAreNull.ToString();
                    return response;
                }
                var Updata=_cityRespostory.Update(Id, city);
                if(Updata != null)
                {
                    if (_unit.Commit() > 0)
                    {
                        response.ErrorMessage = ErrorsCodes.Success.ToString();
                        response.Data = Updata;
                        return response;
                    }
                }
                response.ErrorMessage = ErrorsCodes.NotFound.ToString();
                return response;
            }
            catch (Exception)
            {
                response.ErrorMessage = ErrorsCodes.ThrowException.ToString();
                return response;
            }
        }
    }
}
