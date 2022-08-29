using ClinicSystem.BOL.IServices;
using ClinicSystem.Models.DTOS.Country;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromForm]CountryCreateDTO model)
        {
            var result=_countryService.Create(model);
            return Ok(result);
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete([FromQuery]int Id)
        {
            var result=_countryService.Delete(Id);
            return Ok(result);
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int Id, [FromForm] CountryCreateDTO model)
        {
            var result = _countryService.Update(Id, model);
            return Ok(result);
        }
    }
}
