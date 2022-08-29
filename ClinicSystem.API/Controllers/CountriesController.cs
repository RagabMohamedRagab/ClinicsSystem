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
        public IActionResult Create([FromForm] CountryCreateDTO model)
        {
            var result = _countryService.Create(model);
            return Ok(result);
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete([FromQuery] int Id)
        {
            var result = _countryService.Delete(Id);
            return Ok(result);
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int Id, [FromForm] CountryCreateDTO model)
        {
            var result = _countryService.Update(Id, model);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll(int PageSize = 4, int PageNumber = 1)
        {
            var result = _countryService.GetAllWithoutLang(PageSize, PageNumber);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllByLang")]
        public IActionResult GetAllByLang(string Lang = "en", int PageSize = 4, int PageNumber = 1)
        {
            var result = _countryService.GetAllByLang(Lang, PageSize, PageNumber);
            return Ok(result);
        }
        [HttpGet]
        [Route("SearchByName")]
        public IActionResult Search(string Name)
        {
            var result=_countryService.SearchByName(Name);
            return Ok(result);
        }
        [HttpGet]
        [Route("SearchById")]
        public IActionResult Search(int Id) {
        var result=_countryService.SearchById(Id);
            return Ok(result);
        }
    }
}

