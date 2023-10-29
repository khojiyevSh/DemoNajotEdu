namespace DemoNajotEdu.Application.Models.CrudGroupAction
{
    public class UpdateGroupModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int? TeacherId { get; set; }

    }
}