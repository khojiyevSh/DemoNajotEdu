using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DemoNajotEdu.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService,TeacherService>();
            services.AddScoped<IStudentService,StudentService>();
            services.AddScoped<IGroupService, GroupService>();

         
            return services;
        }
    }
}
