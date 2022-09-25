using ClinicSystem.BOL.IRepositories;
using ClinicSystem.BOL.IServices;
using ClinicSystem.Helpers.Enums;
using ClinicSystem.Models.DTOS.Accounts;

using ClinicSystem.Models.ResponseObjects;
using ClinicSystem.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BLL.Services {
    public class AccountService : IAccountService {
        private readonly IUnitOfWorkPattern _unit;
        private readonly IAccountRepository _accountRepository;
        private readonly IFileService _fileService;
        public AccountService(IUnitOfWorkPattern unit, IAccountRepository accountRepository, IFileService fileService)
        {
            _unit = unit;
            _accountRepository = accountRepository;
            _fileService = fileService;
        }

        public  ResponseObject  Create(RegisterVM model)
        {
            ResponseObject response = new();
            if(model == null)
            {
                response.ErrorMessage = ErrorsCodes.InvalidObject.ToString();
                return response;
            }
            try
            {
                string path=   _fileService.Create(model.Photo, Folder.Accounts);
                var user = _accountRepository.Create(model,path);
                if (user != null)
                {
                    if (_unit.Commit() > 0)
                    {
                        response.ErrorMessage = ErrorsCodes.Success.ToString();
                        response.Data = user;
                        return response;
                    }
                }      response.ErrorMessage = ErrorsCodes.InCorrectDataInsering.ToString();
                return response;
              
            }
            catch (Exception)
            {
            response.ErrorMessage=ErrorsCodes.NotSaveChangesInDatabase.ToString();
                return response;
            }
        }


       
    }
}
