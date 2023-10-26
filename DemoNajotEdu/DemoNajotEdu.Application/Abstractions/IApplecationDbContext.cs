using DemoNajotEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoNajotEdu.Application.Abstractions
{
    public interface IApplecationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<StudentGroup> StudentGroups { get; set; }
        DbSet<Lesson> Lessons { get; set; }
        DbSet<Attendence> Attenants { get; set; }
        DbSet<Group> Groups { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
