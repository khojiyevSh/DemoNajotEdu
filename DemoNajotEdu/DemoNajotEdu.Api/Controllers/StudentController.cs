using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.Models.CrudStudentAction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoNajotEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy ="AdminsAction")]

    public class StudentController : ControllerBase
    {

        private readonly IStudentService _studentservice;

        public StudentController(IStudentService studentservice)
        {
            _studentservice = studentservice;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentModel model)
        {
            await _studentservice.CreateAsync(model);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(int id)
        {
            return Ok(await _studentservice.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetByAll()
        {
            return Ok(await _studentservice.GetByallAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentservice.DeleteAsync(id);

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateGroupModel model)
        {
            await _studentservice.UpdateAsync(model);

            return Ok();
        }
    }
}
