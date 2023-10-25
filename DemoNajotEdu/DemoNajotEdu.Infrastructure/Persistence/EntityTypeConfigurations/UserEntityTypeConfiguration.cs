using DemoNajotEdu.Domain.Entities;
using DemoNajotEdu.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoNajotEdu.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p=>p.UserName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(x => x.UserName)
                .IsUnique();

            builder.HasData(new User
            {
                Id = 1,
                UserName = "Admin",
                PasswordHash = 
                "2646720E1B4B3B960107335AC274F819510741B41A2254C7F17FF39110C89919D0F10F29E2A5BAC9976E2CA3358B1AC65BDC63AEAB83B59F792F188EDE1C9846",
                FullName ="Adminov admin",
                Role = UserRole.Admin

            });
        }
    }
}
