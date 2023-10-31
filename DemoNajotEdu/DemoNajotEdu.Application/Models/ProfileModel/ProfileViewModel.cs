using DemoNajotEdu.Application.Models.CrudGroupAction;
using DemoNajotEdu.Domain.Enums;

namespace DemoNajotEdu.Application.Models.ProfileModel
{
    public class ProfileViewModel
    {
        public string UserName { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string? UploadFile { get; set; }


        public ICollection<ViewGroupModel> Groups { get; set; }
    }
}
