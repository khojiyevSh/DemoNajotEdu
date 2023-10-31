using DemoNajotEdu.Domain.Enums;

namespace DemoNajotEdu.Domain.Entities
{
    public class User
    {
        public User()
        {
            Groups = new HashSet<Group>(); 
        }
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string PasswordHash { get; set; } =string.Empty;

        public string FullName { get; set; }= string.Empty;

        public UserRole Role { get; set; }

        public string? UploadFile { get; set; } 


        public ICollection<Group>? Groups { get; set; }


    }
}
