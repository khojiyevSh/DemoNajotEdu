using DemoNajotEdu.Api.Models;
using DemoNajotEdu.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoNajotEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(UserRequest request)
        {
           var token = await _authService.LoginAsync(request.UserName, request.Password);

            return Ok(token); 
        }
    }
}
