using DemoNajotEdu.Application.Models;

namespace DemoNajotEdu.Application.Abstractions
{
    public interface IStudentService
    {
        Task CreateAsync(CreateStudentModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(UpdateStudentModel model);
        Task<ViewStudentModel> GetByIdAsync(int id);
        Task<List<ViewStudentModel>> GetByallAsync();
    }
}
