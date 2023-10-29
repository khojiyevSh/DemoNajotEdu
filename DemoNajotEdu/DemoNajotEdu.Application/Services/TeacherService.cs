using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.Models.CrudTeacherAction;
using DemoNajotEdu.Domain.Entities;
using DemoNajotEdu.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DemoNajotEdu.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IApplecationDbContext _dbContext;
        private readonly IHashProvider _hashProvider;

        public TeacherService(IApplecationDbContext dbContext,IHashProvider hashProvider)
        {
            _dbContext = dbContext;
            _hashProvider = hashProvider;
        }

        public async Task CreateAsync(CreateTeacherModel model)
        {
            var entity = new User()
            {
                FullName = model.FullName,
                UserName = model.UserName,
                PasswordHash = _hashProvider.GetHash(model.Password),
                Role = UserRole.Teacher
            };

            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(x=> x.Id == id && x.Role == UserRole.Teacher);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }

            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ViewTeacherModel>> GetByallAsync()
        {
            return await _dbContext.Users
                .Where(x => x.Role == UserRole.Teacher)
                .Select(x => new ViewTeacherModel()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    UserName = x.UserName,

                })
                .ToListAsync();
        }

        public async Task<ViewTeacherModel> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id && x.Role == UserRole.Teacher);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }

            return new ViewTeacherModel()
            {
                Id = entity.Id,
                FullName = entity.UserName,
                UserName = entity.UserName,
            };
            
        }

        public async Task UpdateAsync(UpdateTeacherModel model)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id ==model.Id && x.Role == UserRole.Teacher);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }

            entity.FullName = model.FullName ?? entity.FullName;
            entity.UserName = model.UserName ?? entity.UserName;
            entity.PasswordHash = model.Password == null ? entity.PasswordHash :_hashProvider.GetHash(model.Password); 

            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
