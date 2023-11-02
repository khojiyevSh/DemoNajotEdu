using AutoMapper;
using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.Models.CrudGroupAction;
using DemoNajotEdu.Application.Models.CrudStudentGroupAction;
using DemoNajotEdu.Application.Models.LessonModel;
using DemoNajotEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoNajotEdu.Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IApplecationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GroupService(IApplecationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateGroupModel model)
        {
            var entity = _mapper.Map<Group>(model);


            _dbContext.Groups.Add(entity);

            var lessenes = AddGroupLesson(entity, model.StartTimeLesson, model.EndTimeLesson);

            _dbContext.Lessons.AddRange(lessenes);

            await _dbContext.SaveChangesAsync();
        }
         
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Groups.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }

            _dbContext.Groups.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ViewGroupModel>> GetByallAsync()
        {
             return await _dbContext.Groups
               .Select(x => new ViewGroupModel()
               {
                   Id = x.Id,
                   Name = x.Name,
                   StartDate = x.StartDate,
                   EndDate = x.EndDate,
                   TeacherId =x.TeacherId
               })
                .ToListAsync();
        }

        public async Task<ViewGroupModel> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Groups.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }

            return new ViewGroupModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                TeacherId=entity.TeacherId
            };
        }

        public async Task UpdateAsync(UpdateGroupModel model)
        {
            var entity = await _dbContext.Groups.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity == null)
            {
                throw new Exception("Not Found");
            }

          _mapper.Map<UpdateGroupModel>(entity);

            _dbContext.Groups.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        private List<Lesson> AddGroupLesson(Group entity, TimeSpan startTimeLesson, TimeSpan endTimeLesson)
        {
            var lessenes = new List<Lesson>();

            var totalDay = (entity.EndDate - entity.StartDate).Days;

            var currentDay = entity.StartDate;
            for (int i = 1; i <= totalDay; i++)
            {
                if (currentDay.DayOfWeek != DayOfWeek.Saturday && currentDay.DayOfWeek != DayOfWeek.Sunday)
                {
                    var lesson = new Lesson()
                    {
                        Group = entity,
                        StartDateTime = (currentDay.Date + startTimeLesson).ToLocalTime(),
                        EndDateTime = (currentDay.Date + endTimeLesson).ToLocalTime(),
                    };
                    lessenes.Add(lesson);
                }
                currentDay = currentDay.AddDays(1);
            }
            return lessenes;
        }

        public async Task AddGroupStudentAsync(int groubId , StudentGroupModel model)
        {
            if (!await _dbContext.Students.AnyAsync(x => x.Id == model.StudentId))
            {
                throw new Exception("Not Found Sudent");
            }
            if (!await _dbContext.Groups.AnyAsync(x => x.Id == groubId))
            {
                throw new Exception(" Not Found Group");
            }

            var studentGroup = new StudentGroup()
            {
                StudentId = model.StudentId,
                GroupId = groubId,
                IsPayed = false,
                JoinedData = DateTime.UtcNow
            };

            await _dbContext.StudentGroups.AddAsync(studentGroup);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<LessonViewModel>> GetlessonsAsync(int groupId)
        {
           var lessons =await _dbContext.Lessons.Where(x => x.GroupId == groupId)
                .ToListAsync();

            return _mapper.Map<List<LessonViewModel>>(lessons);
        }

        public async Task DeleteGroupStudentAsync(int groubId, int studentId)
        {
            var studentGroup =
                await _dbContext.StudentGroups
                                .FirstOrDefaultAsync(x => x.StudentId == studentId && x.GroupId == groubId);

            _dbContext.StudentGroups.Remove(studentGroup);

            await _dbContext.SaveChangesAsync();
        }
    }
}


