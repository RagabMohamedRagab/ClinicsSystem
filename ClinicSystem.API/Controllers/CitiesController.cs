using ClinicSystem.BOL.IServices;
using ClinicSystem.Models.DTOS.City;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromForm]CityDTO model)
        {
            var result = _cityService.Create(model);
            return Ok(result);
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int Id)
        {
            var result=_cityService.Delete(Id);
            return Ok(result);
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int Id, [FromForm] CityUpdateDTO model)
        {
            var result = _cityService.Update(Id, model);    
            return Ok(result);
        }
    }
}



