using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.Models.CrudAttendenceAction;
using DemoNajotEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoNajotEdu.Application.Services
{
    public class AttendenceService : IAttendenceService
    {
        private readonly IApplecationDbContext _dbcontext;
    private readonly ICurrentUserService _currentUserService;
        public AttendenceService(IApplecationDbContext dbcontext, ICurrentUserService currentUserService)
        {
            _dbcontext = dbcontext;
            _currentUserService = currentUserService;
        }

        public async Task CheckAsync(DoAttendeceCheckModel model)
        {
            var lesson = await _dbcontext.Lessons
                                         .Include(x => x.Group)
                                         .FirstOrDefaultAsync(x => x.Id == model.LessonId);

                if(lesson == null || lesson.Group.TeacherId == _currentUserService.UserId )
                {
                throw new Exception("Not Found");
                }

            var groubStudents = await _dbcontext.Lessons
                .Where(x=>x.Id == model.LessonId)
                .Include(x => x.Group)
                .ThenInclude(x => x.GroupStudents)
                .SelectMany(x => x.Group.GroupStudents)
                .Select(x => x.StudentId).ToListAsync();

            var attendences = new List<Attendence>();
            foreach (var studentId in groubStudents)
            {
                var check = model.Check.FirstOrDefault(x => x.StudentId == studentId);

                var attendence = new Attendence()
                {
                    StudentId = studentId,
                    LessonId = model.LessonId,
                    Participated = false
                };

                if(check != null)
                {
                    attendence.Participated = check.Participated;
                }
                attendences.Add(attendence);
            }
            _dbcontext.Attenants.AddRange(attendences); 

           await _dbcontext.SaveChangesAsync();
        }
    }
}
