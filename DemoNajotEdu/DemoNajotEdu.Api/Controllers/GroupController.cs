using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.Models.CrudGroupAction;
using DemoNajotEdu.Application.Models.CrudStudentGroupAction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoNajotEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupservice;

        public GroupController(IGroupService groupservice)
        {
            _groupservice = groupservice;
        }

        [HttpPost]
        [Authorize(Policy = "AdminsAction")]
        public async Task<IActionResult> Create(CreateGroupModel model)
        {
            await _groupservice.CreateAsync(model);
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetBy(int id)
        {
            return Ok(await _groupservice.GetByIdAsync(id));
        }

        [HttpGet("{groupId}/lessons")]
        [Authorize]
        public async Task<IActionResult> GetLesson(int groupId)
        {
            var groups = await _groupservice.GetlessonsAsync(groupId);
            return Ok(groups);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetByAll()
        {
            return Ok(await _groupservice.GetByallAsync());
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminsAction")]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupservice.DeleteAsync(id);

            return Ok();
        }
        [HttpPut]
        [Authorize(Policy = "AdminsAction")]
        public async Task<IActionResult> Update(UpdateGroupModel model)
        {
            await _groupservice.UpdateAsync(model);

            return Ok();
        }

        [HttpPost("{groupId}/studentId")]
        [Authorize(Policy = "AdminsAction")]
        public async Task<IActionResult> AddStudent([FromRoute] int groupId, [FromBody] StudentGroupModel model)
        {
            await _groupservice.AddGroupStudentAsync(groupId, model);

            return Ok();
        }

        [HttpDelete("{groupId}/studentId")]
        [Authorize(Policy = "AdminsAction")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int groupId, [FromBody] int studentId)
        {
            await _groupservice.DeleteGroupStudentAsync(groupId, studentId);

            return Ok();
        }

    }
}
