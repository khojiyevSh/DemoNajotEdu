using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.Models.ProfileModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace DemoNajotEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IProfileFileUploadService _uploadService;

        public FileUploadController(IProfileFileUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpPut("file")]
        public async Task<IActionResult> FileAploadAsync(IFormFile formFile)
        {
            await _uploadService.SetPhoto(formFile);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _uploadService.GetAsync());
        }
    }
}
