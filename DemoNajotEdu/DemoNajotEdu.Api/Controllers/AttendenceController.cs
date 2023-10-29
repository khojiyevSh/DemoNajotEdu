using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.Models.CrudAttendenceAction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoNajotEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class AttendenceController : ControllerBase
    {
        private readonly IAttendenceService _attendenceService;

        public AttendenceController(IAttendenceService attendenceService)
        {
            _attendenceService = attendenceService;
        }
        [HttpPost("check")]
        public async Task<IActionResult>  CheckAsync(DoAttendeceCheckModel model)
        {
              await _attendenceService.CheckAsync(model);

            return Ok();
        }
    }
}
