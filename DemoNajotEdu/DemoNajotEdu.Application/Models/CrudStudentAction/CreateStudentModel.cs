namespace DemoNajotEdu.Application.Models.CrudStudentAction
{
    public class CreateStudentModel
    {
        public string FullName { get; set; } = string.Empty;

        public DateTime Bithday { get; set; }

        public string PhoneNummber { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
