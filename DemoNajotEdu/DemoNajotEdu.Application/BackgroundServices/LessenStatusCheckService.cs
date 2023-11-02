using DemoNajotEdu.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoNajotEdu.Application.BackgroundServices
{
    public class LessenStatusCheckService : BackgroundService //IHostedService
    {
        private readonly IServiceProvider _provider;

        public LessenStatusCheckService(IServiceProvider provider)
        {
            _provider = provider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var period = new PeriodicTimer(TimeSpan.FromSeconds(20));

            while (await period.WaitForNextTickAsync(stoppingToken))
            {
                var scop =  _provider.CreateScope();
                var context = scop.ServiceProvider.GetRequiredService<IApplecationDbContext>();

                var lessons = await context.Lessons
                       .Include(x => x.AttendenceLessons)
                       .Where(X => X.EndDateTime.Date == DateTime.Now.Date && X.EndDateTime < DateTime.Now)
                       .ToListAsync(stoppingToken);
                foreach (var lesson in lessons)
                {
                    lesson.isDone = lesson.AttendenceLessons.Any();
                    context.Lessons.Update(lesson);
                }

                await context.SaveChangesAsync(stoppingToken);
            }
        }
    }
}
