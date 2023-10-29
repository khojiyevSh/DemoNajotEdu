namespace DemoNajotEdu.Application.Models.CrudGroupAction
{
    public class CreateGroupModel
    {

        public string Name { get; set; } = string.Empty;

        public int TeacherId { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }


        public TimeSpan StartTimeLesson { get; set; }

        public TimeSpan EndTimeLesson { get; set; }
    }
}
