using DemoNajotEdu.Application.Models.CrudGroupAction;
using DemoNajotEdu.Application.Models.CrudStudentGroupAction;

namespace DemoNajotEdu.Application.Abstractions
{
    public interface IGroupService : ICrudService<int, CreateGroupModel, UpdateGroupModel, ViewGroupModel>
    {
        Task AddGroupStudentAsync( int groubId, StudentGroupModel model);
        Task DeleteGroupStudentAsync(int groubId, int studentId);
    }
}
