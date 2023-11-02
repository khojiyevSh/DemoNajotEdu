using AutoMapper;
using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Application.Models.CrudGroupAction;
using DemoNajotEdu.Application.Models.CrudStudentAction;
using DemoNajotEdu.Application.Models.CrudTeacherAction;
using DemoNajotEdu.Application.Models.LessonModel;
using DemoNajotEdu.Domain.Entities;
using DemoNajotEdu.Domain.Enums;
using System.Text.RegularExpressions;

namespace DemoNajotEdu.Application.AutoMappers
{
    public class AutoMapperForUser : Profile
    {
        public AutoMapperForUser(IHashProvider hashProvider) 
        {
            //--> Groups
            CreateMap<UpdateGroupModel,Domain.Entities.Group>();

            CreateMap<Lesson, LessonViewModel>();

            CreateMap<CreateGroupModel,Domain.Entities.Group>()
                .AfterMap((model, entity) => entity.StartDate = model.StartDateModel.ToDateTime(TimeOnly.MinValue).ToLocalTime())
                .AfterMap((model, entity) => entity.EndDate = model.EndDateModel.ToDateTime(TimeOnly.MinValue).ToLocalTime());

            //---> Teachers

            CreateMap<CreateTeacherModel,User>()
                .ForMember(d => d.PasswordHash, o => o.MapFrom(s => hashProvider.GetHash(s.Password)))
                .ForMember(d=>d.Role,o=>o.MapFrom(s=>UserRole.Teacher));

            CreateMap<User, ViewTeacherModel>();

            CreateMap<UpdateTeacherModel ,User>()
            .AfterMap((model,entity)=>entity.PasswordHash = model.Password == null ? entity.PasswordHash :hashProvider.GetHash(model.Password));

            //---> Students

            CreateMap<CreateStudentModel, Student>();

            CreateMap<Student, ViewStudentModel>();

            CreateMap<UpdateStudentModel, Student>()
                .AfterMap((model, entity) =>
                {
                    entity.FullName = model.FullName ?? entity.FullName;
                    entity.PhoneNummber = model.PhoneNummber ?? entity.PhoneNummber;
                  
                });
        }
    }
}
