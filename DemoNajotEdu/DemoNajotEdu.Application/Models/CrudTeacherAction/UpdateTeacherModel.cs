namespace DemoNajotEdu.Application.Models.CrudTeacherAction
{
    public class UpdateTeacherModel
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
    }
}
