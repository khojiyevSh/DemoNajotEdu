using DemoNajotEdu.Application.Models.ProfileModel;
using Microsoft.AspNetCore.Http;

namespace DemoNajotEdu.Application.Abstractions
{
    public interface IProfileFileUploadService
    {
        Task SetPhoto(IFormFile formFile);
        
        Task<ProfileViewModel> GetAsync();
    }
}
