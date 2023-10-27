using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoNajotEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy ="TeachersAction")]
    [Authorize(Policy ="AdminsAction")]
    public class StudentController : ControllerBase
    {

        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentModel model)
        {
            await _service.CreateAsync(model);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(int id)
        {
            await _service.GetByIdAsync(id);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetBy()
        {
            await _service.GetByallAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentModel model)
        {
            await _service.UpdateAsync(model);

            return Ok();
        }
    }
}
