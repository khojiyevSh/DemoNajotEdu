using DemoNajotEdu.Domain.Enums;

namespace DemoNajotEdu.Application.Models.CrudTeacherAction
{
    public class CreateTeacherModel
    {
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
    }
}
