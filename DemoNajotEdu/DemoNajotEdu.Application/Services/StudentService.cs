using AutoMapper;
using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.Models.CrudStudentAction;
using DemoNajotEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoNajotEdu.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IApplecationDbContext _dbContext;
        private readonly IMapper _mapper;

        public StudentService(IApplecationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateStudentModel model)
        {
            var entity2 = _mapper.Map<Student>(model);

            await _dbContext.Students.AddAsync(entity2);
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

            return _mapper.Map<ViewStudentModel>(entity);
        }

        public async Task UpdateAsync(UpdateStudentModel model)
        {
            var entity = await _dbContext.Students.FirstOrDefaultAsync(x=>x.Id == model.Id);


            entity = _mapper.Map<Student>(model);

            /*entity.FullName = model.FullName ?? entity.FullName;
            entity.PhoneNummber = model.PhoneNummber ?? entity.PhoneNummber;*/


            _dbContext.Students.Remove(entity);

           await _dbContext.Students.AddAsync(entity);


            await _dbContext.SaveChangesAsync();
        }
    }
}
