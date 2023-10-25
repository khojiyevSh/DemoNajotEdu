namespace DemoNajotEdu.Domain.Entities
{
    public class Attendence
    {
        public int Id { get; set; }

        public bool Participated { get; set; }

        public int LessonId { get; set; }

        public int StudentId { get; set; }


        public Student? Student { get; set; }

        public Lesson? Lesson { get; set; }
    }
}
