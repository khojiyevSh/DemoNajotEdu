namespace DemoNajotEdu.Application.Models.CrudStudentAction
{
    public class ViewStudentModel
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public DateTime? Bithday { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string PhoneNummber { get; set; } = string.Empty;
    }
}
