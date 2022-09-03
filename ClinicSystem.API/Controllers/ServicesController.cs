using ClinicSystem.BOL.IServices;
using ClinicSystem.Models.DTOS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromForm] ServiceDTO service)
        {
            return Ok(_serviceService.Create(service));
        }
        [HttpPatch]
        [Route("Update")]
        public IActionResult Update(int Id, [FromForm] ServiceUpdateDTO service)
        {

            return Ok(_serviceService.Update(Id, service));
        }
        [HttpGet]
        [Route("FindById")]
        public IActionResult FindById(int Id)
        {
            return Ok(_serviceService.FindById(Id));
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int Id)
        {
            return Ok(_serviceService.Delete(Id));
        }
        [HttpGet]
        [Route("GetAllByLang")]
        public IActionResult GetAllWithLang(string lang = "en", int PageSize = 4, int PageNumber = 1)
        {
            return Ok(_serviceService.GetAllLang(lang, PageSize, PageNumber));
        }
        [HttpGet]
        [Route("GetAllWithLang")]
        public IActionResult GetAll(int PageSize = 4, int PageNumber = 1)
        {
            return Ok(_serviceService.GetAllWithoutLang(PageSize, PageNumber));
        }
        [HttpGet]
        [Route("FindByName")]
        public IActionResult FindByName(string Name)
        {
            return Ok(_serviceService.FindByName(Name));
        }

    }
}




