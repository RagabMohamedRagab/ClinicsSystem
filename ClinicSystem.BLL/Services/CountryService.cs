using ClinicSystem.BOL.IRepositories;
using ClinicSystem.BOL.IServices;
using ClinicSystem.Helpers.Enum;
using ClinicSystem.Models.DTOS.Country;
using ClinicSystem.Models.ResponseObjects;
using ClinicSystem.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BLL.Services {
    public class CountryService : ICountryService {
        private readonly ICountryRepository _countryrepo;
        private readonly IUnitOfWorkPattern _unit;
        private readonly IFileService _fileService;

        public CountryService(ICountryRepository countryrepo, IUnitOfWorkPattern unit, IFileService fileService)
        {
            _countryrepo = countryrepo;
            _unit = unit;
            _fileService = fileService;
        }

        public ResponseObject Create(CountryCreateDTO country)
        {
            ResponseObject response = new ResponseObject();
            string path = String.Empty;
            if (country == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                return response;
            }
            if (String.IsNullOrEmpty(country.ArName) || String.IsNullOrEmpty(country.EnName))
            {
                response.ErrorMessage = ErrorsCodes.NamesAreNull.ToString();
                return response;
            }
            if (country.Logo == null)
            {
                response.ErrorMessage = ErrorsCodes.ImageIsNotValid.ToString();
                return response;
            }
            else
            {
                path = _fileService.Create(country.Logo, Folder.Countries);
            }
            try
            {
                var countrydto = _countryrepo.Create(country, path);
                if (countrydto == null)
                {
                    response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                    return response;
                }
                if (_unit.Commit() > 0)
                {
                    response.ErrorMessage = ErrorsCodes.Success.ToString();
                    response.Data = countrydto;
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
            var data = _countryrepo.Delete(Id);
            if (data == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidDelete.ToString();
                return response;
            }
            if (_fileService.Remove(data.Logo, Folder.Countries))
            {
                if (_unit.Commit() > 0)
                {
                    response.ErrorMessage = ErrorsCodes.Success.ToString();
                    response.Data = data;
                    return response;
                }
            }
            response.ErrorMessage = ErrorsCodes.InvalidDelete.ToString();
            return response;
        }

        public ResponseObject GetAllByLang(string Lang = "en", int Pagesize = 4, int PageNumber = 1)
        {
            ResponseObject response = new ResponseObject();
            if (String.IsNullOrEmpty(Lang) || PageNumber <= 0 || Pagesize <= 0)
            {
                response.ErrorMessage = ErrorsCodes.ParameteresNotCorrect.ToString();
                return response;
            }
            var allcountries = _countryrepo.GetAllByLang(Lang, Pagesize, PageNumber);
            if (allcountries.Any())
            {
                response.ErrorMessage = ErrorsCodes.Success.ToString();
                response.Data = allcountries;
                return response;
            }
            response.ErrorMessage = ErrorsCodes.NotFound.ToString();
            return response;
        }

        public ResponseObject GetAllWithoutLang(int Pagesize = 4, int PageNumber = 1)
        {
            ResponseObject response = new ResponseObject();
            if (PageNumber <= 0 || Pagesize < 0)
            {
                response.ErrorMessage = ErrorsCodes.ParameteresNotCorrect.ToString();
                return response;
            }
            var allCountries = _countryrepo.GetAllWithoutLang(Pagesize, PageNumber);
            if (allCountries == null)
            {
                response.ErrorMessage = ErrorsCodes.NotFound.ToString();
                return response;
            }
            response.ErrorMessage = ErrorsCodes.Success.ToString();
            response.Data = allCountries;
            return response;
        }

        public ResponseObject Update(int Id, CountryCreateDTO country)
        {
            ResponseObject response = new ResponseObject();
            string OldPath = string.Empty,
                     NewPath = string.Empty;
            if (Id < 0)
            {
                response.ErrorMessage = ErrorsCodes.IDNotValid.ToString();
                return response;
            }
            if (country == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                return response;
            }
            var OldEntity = _countryrepo.Find(Id);
            if (OldEntity == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                return response;
            }
            OldPath = OldEntity.Logo;
            if (country.Logo == null)
            {
                NewPath = null;
            }
            else
            {
                NewPath = country.Logo.FileName;
            }
            try
            {
                var result = _countryrepo.Update(Id, country, NewPath);
                if (result != null)
                {
                    if (NewPath != null)
                    {
                        if (_fileService.Remove(OldPath, Folder.Countries))
                        {
                            _fileService.Create(country.Logo, Folder.Countries);
                        }
                    }
                    if (_unit.Commit() > 0)
                    {
                        response.ErrorMessage = ErrorsCodes.Success.ToString();
                        response.Data = result;
                        return response;
                    }
                }
                response.ErrorMessage = ErrorsCodes.InvalidUpadte.ToString();
                return response;
            }
            catch (Exception)
            {
                response.ErrorMessage = ErrorsCodes.InvalidUpadte.ToString();
                return response;
            }
        }
        public ResponseObject SearchByName(string Name)
        {
            ResponseObject response = new ResponseObject();
            if (String.IsNullOrEmpty(Name))
            {
                response.ErrorMessage = ErrorsCodes.NamesAreNull.ToString();
                return response;
            }
            var entitydto = _countryrepo.SearchByName(Name);
            if (entitydto != null)
            {
                response.ErrorMessage = ErrorsCodes.Success.ToString();
                response.Data = entitydto;
                return response;
            }
            response.ErrorMessage = ErrorsCodes.NotFound.ToString();
            return response;

        }
        public ResponseObject SearchById(int Id)
        {
            ResponseObject response = new ResponseObject();
            if (Id <= 0)
            {
                response.ErrorMessage = ErrorsCodes.IDNotValid.ToString();
                return response;
            }
         var ok= _countryrepo.Find(Id);
            if (ok == null)
            {
                response.ErrorMessage = ErrorsCodes.NotFound.ToString();
                return response;
            }
            response.ErrorMessage = ErrorsCodes.Success.ToString();
            response.Data = ok;
            return response;
        }
    }
}

