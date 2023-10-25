using DemoNajotEdu.Domain.Entities;

namespace DemoNajotEdu.Infrastructure.Abstractions
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
    }
}
