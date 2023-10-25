namespace DemoNajotEdu.Domain.Entities
{
    public class StudentGroup
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public int StudentId { get; set; }

        public bool IsPayed { get; set; }

        public DateTime JoinedData { get; set; }


        public Group? Group { get; set; }

        public Student? Student { get; set; }
    }
}
