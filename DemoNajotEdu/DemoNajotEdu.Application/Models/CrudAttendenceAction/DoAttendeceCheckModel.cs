namespace DemoNajotEdu.Application.Models.CrudAttendenceAction
{
    public class DoAttendeceCheckModel
    {
        public int LessonId { get; set; }

        public List<AttendenceCheckModel> Check { get; set; }
    }
}
