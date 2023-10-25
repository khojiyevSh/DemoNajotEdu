using DemoNajotEdu.Domain.Entities;
using DemoNajotEdu.Infrastructure.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DemoNajotEdu.Infrastructure.Persistence
{
    public class ApplicationDbcontext : DbContext
    {
        public DbSet<User>? users { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<StudentGroup>? StudentGroups { get; set; }
        public DbSet<Lesson>? Lessons { get; set; }
        public DbSet<Attendence>? Attenants { get; set; }
        public DbSet<Group>? Groups { get; set; }

        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
         :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudentGroupEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AttendenceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LessonEntityTypeConfiguration());
        }
    }
}
