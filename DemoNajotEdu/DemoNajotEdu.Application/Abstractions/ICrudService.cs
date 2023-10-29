using DemoNajotEdu.Application.Models;

namespace DemoNajotEdu.Application.Abstractions
{
    public interface ICrudService<D,C,U,V>
    {
        Task CreateAsync(C model);
        Task DeleteAsync(D id);
        Task UpdateAsync(U model);
        Task<V> GetByIdAsync(D id);
        Task<List<V>> GetByallAsync();
    }
}
