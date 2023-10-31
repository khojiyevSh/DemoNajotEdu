using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.Models.CrudGroupAction;
using DemoNajotEdu.Application.Models.ProfileModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DemoNajotEdu.Application.Services
{
    public class ProfileFileUploadService : IProfileFileUploadService
    {
        private readonly IApplecationDbContext _context;
        private readonly IFileUploadService _uploadService;
        private readonly ICurrentUserService _currentUserService;

        public ProfileFileUploadService(IApplecationDbContext context,IFileUploadService uploadService,ICurrentUserService currentUserService)
        {
            _context = context;
            _uploadService = uploadService;
            _currentUserService = currentUserService;
        }

        public async Task<ProfileViewModel> GetAsync()
        {
            var userId = _currentUserService.UserId;
            var user =await _context.Users.Include(x=>x.Groups).FirstOrDefaultAsync(x => x.Id == userId);

            return new ProfileViewModel
            {
                FullName = user.FullName,
                UserName = user.UserName,
                UploadFile = user.UploadFile,
                Groups = new List<ViewGroupModel>(user.Groups.Select(x => new ViewGroupModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    EndDate = x.EndDate,
                    StartDate = x.StartDate,
                    TeacherId = x.TeacherId,
                }))
            };
        }

        public async Task SetPhoto(IFormFile formFile)
        {
            var userId = _currentUserService.UserId;
            var user =await _context.Users.FirstOrDefaultAsync(x=>x.Id == userId);

            if (user == null)
            {
                throw new Exception("Not User Found");
            }
            var path = await _uploadService.FileAploadAsync(formFile);

            user.UploadFile = path;

            _context.Users.Update(user);

            await _context.SaveChangesAsync();

        }
    }
}
