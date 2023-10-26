using DemoNajotEdu.Application.Models;

namespace DemoNajotEdu.Application.Abstractions
{
    public interface ITeacherService
    {
        Task CreateAsync(CreateTeacherModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(UpdateTeacherModel model);
        Task<List<ViewTeacherModel>> GetByallAsync();
        Task<ViewTeacherModel> GetByAsync(int id);
    }
}
