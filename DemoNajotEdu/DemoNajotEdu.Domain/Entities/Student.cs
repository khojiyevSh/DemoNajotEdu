    namespace DemoNajotEdu.Domain.Entities
{
    public class Student
    {
        public Student() 
        {
            AttendenceStudents = new HashSet<Attendence>();
            StudentGroups = new HashSet<StudentGroup>();
        }    
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public DateTime Bithday { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public string PhoneNummber { get; set; }=string.Empty;


        public ICollection<Attendence>? AttendenceStudents { get; set; }

        public ICollection<StudentGroup>? StudentGroups { get; set; }
    }
}
