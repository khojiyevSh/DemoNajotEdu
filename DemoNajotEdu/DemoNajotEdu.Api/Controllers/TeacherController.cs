using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.Models.CrudTeacherAction;
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
        private readonly ITeacherService _teacherservice;

        public TeacherController(ITeacherService teacherservice)
        {
            _teacherservice = teacherservice;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherModel model)
        {
            await _teacherservice.CreateAsync(model);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(int id)
        {
            return Ok(await _teacherservice.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetBy()
        {
            return Ok(await _teacherservice.GetByallAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teacherservice.DeleteAsync(id);

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTeacherModel model)
        {
            await _teacherservice.UpdateAsync(model);

            return Ok();
        }
    }
}
            