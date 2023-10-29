
using DemoNajotEdu.Application.Models.CrudTeacherAction;

namespace DemoNajotEdu.Application.Abstractions
{
    public interface ITeacherService : ICrudService<int, CreateTeacherModel, UpdateTeacherModel, ViewTeacherModel>
    {
    }
}
