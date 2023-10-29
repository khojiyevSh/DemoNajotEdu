using DemoNajotEdu.Application.Models.CrudAttendenceAction;

namespace DemoNajotEdu.Application.Abstractions
{
    public interface IAttendenceService
    {
        Task CheckAsync(DoAttendeceCheckModel model);
    }
}
