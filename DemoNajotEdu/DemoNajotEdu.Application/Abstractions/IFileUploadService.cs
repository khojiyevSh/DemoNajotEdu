using Microsoft.AspNetCore.Http;

namespace DemoNajotEdu.Application.Abstractions
{
    public interface IFileUploadService
    {
        Task<string> FileAploadAsync(IFormFile formFile);
    }
}
