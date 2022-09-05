using ClinicSystem.BOL.IServices;
using ClinicSystem.Models.DTOS.MaritalStatus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MaritalStatusController : ControllerBase {
        private readonly IMaritalStatusService _maritalStatus;

        public MaritalStatusController(IMaritalStatusService maritalStatus)
        {
            _maritalStatus = maritalStatus;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromForm] MaritalStatusDTO maritalStatus)
        {
            return Ok(_maritalStatus.Create(maritalStatus));
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int Id, [FromForm] MaritalStatusDTO maritalStatus)
        {
            return Ok(_maritalStatus.Update(Id, maritalStatus));
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll(int PageSize = 4, int PageNumber = 1)
        {
            return Ok(_maritalStatus.GetALL(PageSize, PageNumber));
        }
        [HttpGet]
        [Route("GetAllByLang")]
        public IActionResult GetAllByLang(string Lang="en",int Pagesize=4,int pageNumber = 1)
        {
            return Ok(_maritalStatus.GetALLByLang(Lang, Pagesize, pageNumber));
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int Id)
        {
            return Ok(_maritalStatus.Delete(Id));
        }
        [HttpGet]
        [Route("FindById")]
        public IActionResult FindById(int Id)
        {
            return Ok(_maritalStatus.FindById(Id));
        }
        [HttpGet]
        [Route("FindbyName")]
        public IActionResult FindByName(string Name)
        {
            return Ok(_maritalStatus.FindByName(Name));
        }

    }
}


