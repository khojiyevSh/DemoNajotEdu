using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.Models;
using DemoNajotEdu.Domain.Entities;
using DemoNajotEdu.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DemoNajotEdu.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IApplecationDbContext _dbContext;
        private readonly IHashProvider _hashProvider;

        public StudentService(IApplecationDbContext dbContext, IHashProvider hashProvider)
        {
            _dbContext = dbContext;
            _hashProvider = hashProvider;
        }

        public async Task CreateAsync(CreateStudentModel model)
        {
            var entity = new Student()
            {
                FullName = model.FullName,
                PhoneNummber = model.PhoneNummber,
                Bithday = model.Bithday,
            };

            await _dbContext.Students.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }

            _dbContext.Students.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ViewStudentModel>> GetByallAsync()
        {
            return await _dbContext.Students
               .Select(x => new ViewStudentModel()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    PhoneNummber = x.PhoneNummber,
                    Bithday = x.Bithday,
                    CreatedDate = x.CreatedDate,
                })
                .ToListAsync();
        }

        public async Task<ViewStudentModel> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }

            return new ViewStudentModel()
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Bithday = entity.Bithday,
                CreatedDate = entity.CreatedDate,
                PhoneNummber =entity.PhoneNummber,
            };

        }

        public async Task UpdateAsync(UpdateStudentModel model)
        {
            var entity = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }

            entity.FullName = model.FullName ?? entity.FullName;
            entity.PhoneNummber = model.PhoneNummber ?? entity.PhoneNummber;


            _dbContext.Students.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
