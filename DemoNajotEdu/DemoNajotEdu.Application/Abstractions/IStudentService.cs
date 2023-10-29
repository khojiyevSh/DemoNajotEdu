using DemoNajotEdu.Application.Models.CrudStudentAction;

namespace DemoNajotEdu.Application.Abstractions
{
    public interface IStudentService : ICrudService<int, CreateStudentModel, UpdateGroupModel,ViewGroupModel>
    {
    }
}
