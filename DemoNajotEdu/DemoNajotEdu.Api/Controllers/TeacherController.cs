using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoNajotEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminsAction")]

    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherModel model)
        {
            await _service.CreateAsync(model);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(int id)
        {
            await _service.GetByAsync(id);

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
        public async Task<IActionResult> Update(UpdateTeacherModel model)
        {
            await _service.UpdateAsync(model);

            return Ok();
        }
    }
}
            