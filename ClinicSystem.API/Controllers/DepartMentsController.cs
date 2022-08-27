using ClinicSystem.BOL.IServices;
using ClinicSystem.Models.DTOS.Department;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DepartMentsController : ControllerBase {
        private readonly IDepartMentService _departService;

        public DepartMentsController(IDepartMentService departService)
        {
            _departService = departService;
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromQuery]DepartMentDTO model)
        {
            var result = _departService.Create(model);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll(string lang="en",int Pagesize=4,int Pagenumber=1)
        {
            var result = _departService.GetALLDepart(lang, Pagesize, Pagenumber);
            return Ok(result);
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int Id, [FromForm]DepartMentDTO model)
        {
            var result=_departService.Update(Id, model);
            return Ok(result);
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int Id)
        {
            var result = _departService.Delete(Id);
            return Ok(result);
        }



    }
}
