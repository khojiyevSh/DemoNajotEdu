using DemoNajotEdu.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DemoNajotEdu.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class AttendenceEntityTypeConfiguration : IEntityTypeConfiguration<Attendence>
    {
        public void Configure(EntityTypeBuilder<Attendence> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Lesson)
                 .WithMany(x => x.AttendenceLessons)
                 .HasForeignKey(x => x.LessonId);

            builder.HasOne(x => x.Student)
                .WithMany(x => x.AttendenceStudents)
                .HasForeignKey(x => x.StudentId);
        }
    }
}
