using ClinicSystem.BOL.IServices;
using ClinicSystem.Models.DTOS.Gender;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase {
        private readonly IGenderService _genderService;
        public GendersController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromForm]GenderDTO gender)
        {
            return Ok(_genderService.Create(gender));   
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int Id,[FromForm]GenderDTO gender)
        {
            return Ok(_genderService.Update(Id, gender));
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int Id)
        {
            return Ok(_genderService.Delete(Id));
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll(int PageSize=4,int PageNumber = 1)
        {
            return Ok(_genderService.GetAllGender(PageSize,PageNumber));
        }
        [HttpGet]
        [Route("GetAllByLang")]
        public IActionResult GetAllByLang(string lang="en",int PageSize=4,int PageNumber=1)
        {
            return Ok(_genderService.GetAllByLange(lang, PageSize, PageNumber));
        }
        [HttpGet]
        [Route("FindByName")]
        public IActionResult FindByName(string Name)
        {
            return Ok(_genderService.FindByName(Name));
        }
        [HttpGet]
        [Route("FindById")]
        public IActionResult FindById(int Id)
        {
            return Ok(_genderService.FindById(Id));
        }
    }
}






