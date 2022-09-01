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
        public IActionResult Create([FromForm]ServiceDTO service)
        {
            return Ok(_serviceService.Create(service));
        }
    }
}
