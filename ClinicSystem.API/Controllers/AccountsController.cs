using ClinicSystem.BOL.IServices;
using ClinicSystem.Models.DTOS.Accounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromForm]RegisterVM register)
        {
            return Ok(_accountService.Create(register));
        }
    }
}
