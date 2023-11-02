using DemoNajotEdu.Application.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DemoNajotEdu.Infrastructure.Services
{
    public class FileUploadServie : IFileUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploadServie(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> FileAploadAsync(IFormFile formFile)
        {
            var fileNameIteam = formFile.FileName.Split(".");
            var extension = fileNameIteam[fileNameIteam.Length - 1];
            var fileName = formFile.FileName.Remove(formFile.FileName.IndexOf(extension, StringComparison.InvariantCultureIgnoreCase)-1);

            var path = $"/files/{fileName}-{Guid.NewGuid()}.{extension}";

            var fullPath = _webHostEnvironment.WebRootPath + path;
            using (var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                await formFile.CopyToAsync(fileStream);
            }

            return path;
        }
    }
}
