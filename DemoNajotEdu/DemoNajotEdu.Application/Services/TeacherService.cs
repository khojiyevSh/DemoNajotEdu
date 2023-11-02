using AutoMapper;
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
        private readonly IMapper _mapper;

        public TeacherService(IApplecationDbContext dbContext,IHashProvider hashProvider , IMapper mapper)
        {
            _dbContext = dbContext;
            _hashProvider = hashProvider;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateTeacherModel model)
        {
            var entity = _mapper.Map<User>(model);

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
            var view = await _dbContext.Users
                .Where(x => x.Role == UserRole.Teacher)
                .ToListAsync();

            return _mapper.Map<List<ViewTeacherModel>>(view);
        }

        public async Task<ViewTeacherModel> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id && x.Role == UserRole.Teacher);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }

            return _mapper.Map<ViewTeacherModel>(entity);
        }

        public async Task UpdateAsync(UpdateTeacherModel model)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id ==model.Id && x.Role == UserRole.Teacher);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }

            _mapper.Map<User>(entity);

            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
