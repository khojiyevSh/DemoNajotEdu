using AutoMapper;
using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.AutoMappers;
using DemoNajotEdu.Application.BackgroundServices;
using DemoNajotEdu.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DemoNajotEdu.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperForUser));

            services.AddSingleton(p => new MapperConfiguration(c =>
            {
                c.AddProfile(new AutoMapperForUser(p.GetService<IHashProvider>()));
            }).CreateMapper());

            services.AddScoped<ITeacherService,TeacherService>();
            services.AddScoped<IStudentService,StudentService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IAttendenceService, AttendenceService>();
            services.AddScoped<IProfileFileUploadService, ProfileFileUploadService>();
            services.AddHostedService<LessenStatusCheckService>();

            return services;
        }
    }
}
