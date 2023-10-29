using DemoNajotEdu.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DemoNajotEdu.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public int UserId { get; set; }

        public CurrentUserService(IHttpContextAccessor  contextAccessor)
        {
            var claims = contextAccessor.HttpContext!.User.Claims;

            var idClaim = claims.FirstOrDefault(x=>x.Type == ClaimTypes.Name);

            if (idClaim !=null && int.TryParse(idClaim.Value,out int value))
            {
                UserId =value;
            }
        }
        
    }
}
