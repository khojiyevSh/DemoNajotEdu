using DemoNajotEdu.Domain.Entities;
using DemoNajotEdu.Infrastructure.Abstractions;
using DemoNajotEdu.Infrastructure.Persistence;
using DemoNajotEdu.Infrastructure.Utills;
using Microsoft.EntityFrameworkCore;

namespace DemoNajotEdu.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDcontext _dbcontext;

        private readonly ITokenService _tokenService;

        public AuthService(ApplicationDcontext dbContext, ITokenService tokenService)
        {
            _dbcontext = dbContext;
            _tokenService = tokenService;
        }
        public async Task<string> LoginAsync(string userName, string password)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user == null)
            {
                throw new Exception("User Not found");
            }
            else if (user.PasswordHash != HashGenerator.Generator(password))
            {
                throw new Exception("Password is wrong");
            }
            return _tokenService.GenerateAccessToken(user);
        }
    }
}
