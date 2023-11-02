namespace DemoNajotEdu.Domain.Entities
{
    public class Lesson
    {
        public Lesson() 
        {
            AttendenceLessons = new HashSet<Attendence>();
        }
        public int Id { get; set; }

        public int GroupId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public bool isDone { get; set; }


        public Group? Group { get; set; }

        public ICollection<Attendence>? AttendenceLessons { get; set; }


    }
}
