using AutoMapper;
using ClinicSystem.BOL.IRepositories;
using ClinicSystem.DAL.Context;
using ClinicSystem.DAL.Domains;
using ClinicSystem.Models.DTOS.Accounts;

using ClinicSystem.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Repositories.Repostories {
    public class AccountRepository : GenericRepository<ApplicationUser>, IAccountRepository {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        public AccountRepository(ClinicDbContext clinic, IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : base(clinic)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<RegisterVM> Create(RegisterVM model, string Path)
        {
            try
            {
                ApplicationUser user = _mapper.Map<ApplicationUser>(model);
                if (user != null)
                {
                    user.ImgUrl = Path;
                    if (!EmailExist(user.Email).Result)
                    {
                        IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                        if (result.Succeeded)
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return model;
                        }
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private async Task<bool> EmailExist(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email); // Null
            if (user != null) 
            {
                return true;
            }
            return false;
        }
    }
}




